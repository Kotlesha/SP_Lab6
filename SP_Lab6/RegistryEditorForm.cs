using Microsoft.Win32;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Windows.Forms;

namespace SP_Lab6
{
    public partial class RegistryEditorForm : Form
    {
        private readonly RegistryKey[] registryKeys;

        public RegistryEditorForm()
        {
            InitializeComponent();
            LogicalStructureOfRegistryTreeView.ShowPlusMinus = false;

            registryKeys = new RegistryKey[]
            {
                Registry.ClassesRoot,
                Registry.CurrentUser,
                Registry.LocalMachine,
                Registry.Users,
                Registry.CurrentConfig
            };

            ValuesListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void RegistryEditorForm_Load(object sender, EventArgs e)
        {
            foreach (var key in registryKeys)
            {
                TreeNode node = new(key.Name) { Tag = key, Name = key.Name };
                LogicalStructureOfRegistryTreeView.Nodes.Add(node);
            }
        }

        private void LogicalStructureOfRegistryTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var registryKey = e.Node.Tag as RegistryKey;
            path.Clear();
            path.Text = string.Concat(registryKey.Name, @"\", path.Text);
            ValuesListView.Items.Clear();

            foreach (var valueName in registryKey.GetValueNames())
            {
                if (registryKeys.Contains(registryKey)) break;
                var row = GetValueRow(registryKey, valueName);
                var item = new ListViewItem(row);
                ValuesListView.Items.Add(item);
                ValuesListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }

            foreach (var subKeyName in registryKey.GetSubKeyNames())
            {
                if (e.Node.Nodes.ContainsKey(subKeyName)) continue;

                RegistryKey subKey = default;
                try { subKey = registryKey.OpenSubKey(subKeyName); } catch { }
                TreeNode subNode = new(subKeyName) { Tag = subKey, Name = subKeyName };
                e.Node.Nodes.Add(subNode);
            }
        }

        private string[] GetValueRow(RegistryKey registryKey, string valueName)
        {
            string resultName = valueName == string.Empty ? "(По умолчанию)" : valueName;
            RegistryValueKind type = registryKey.GetValueKind(valueName);
            string resultType = RegistryKeyOperations.GetRegistryType(type);
            object value = registryKey.GetValue(valueName);
            string resultValue = RegistryKeyOperations.GetRegistryValue(value, type);
            return new string[] { resultName, resultType, resultValue };
        }

        private void SaveToFile(RegistryKey registryKey, string outputFilePath)
        {
            using StreamWriter outputFile = new(outputFilePath);
            using JsonTextWriter writer = new(outputFile);
            writer.Formatting = Formatting.Indented;
            TraverseRegistry(registryKey, writer);
        }

        private void ValuesListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = ValuesListView.HitTest(e.X, e.Y);
            ListViewItem item = info.Item;

            if (item != null)
            {
                ViewValueForm form = new(item.SubItems[0].Text, item.SubItems[2].Text);
                form.ShowDialog();
            }
        }

        public void TraverseRegistry(RegistryKey key, JsonTextWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("Name");
            writer.WriteValue(key.Name);
            writer.WritePropertyName("Values");
            writer.WriteStartArray();

            foreach (var name in key.GetValueNames())
            {
                var data = GetValueRow(key, name);
                writer.WriteStartObject();
                writer.WritePropertyName("Name");
                writer.WriteValue(data[0]);
                writer.WritePropertyName("Type");
                writer.WriteValue(data[1]);
                writer.WritePropertyName("Value");
                writer.WriteValue(data[2]);
                writer.WriteEndObject();
            }
            writer.WriteEndArray();

            writer.WritePropertyName("ChildNodes");
            writer.WriteStartArray();

            foreach (var subKeyName in key.GetSubKeyNames())
            {
                var subKey = key.OpenSubKey(subKeyName);

                if (subKey != null)
                {
                    TraverseRegistry(subKey, writer);
                }
            }

            writer.WriteEndArray();
            writer.WriteEndObject();
        }

        private async void SaveToFileButton_Click(object sender, EventArgs e)
        {
            saveRegistryData.Filter = "JSON-файлы (*.json)|*.json|Текстовые файлы (*.txt)|*.txt";
            saveRegistryData.FilterIndex = 1;
            var choice = saveRegistryData.ShowDialog();

            if (choice == DialogResult.OK)
            {
                SaveToFileButton.Enabled = false;
                var registryKey = LogicalStructureOfRegistryTreeView.SelectedNode.Tag as RegistryKey;
                await Task.Run(() => SaveToFile(registryKey, saveRegistryData.FileName));
                MessageBox.Show("Файл сохранён!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SaveToFileButton.Enabled = true;
            }
        }

        private void AddSubKey_Click(object sender, EventArgs e)
        {
            var registryKey = LogicalStructureOfRegistryTreeView.SelectedNode.Tag as RegistryKey;
            AddSubKeyForm form = new(path.Text, registryKey.Name);
            form.ShowDialog();

            foreach (var subkey in form.SubKeys)
            {
                TreeNode subNode = new(subkey.Item2) { Tag = subkey.Item1, Name = subkey.Item2 };
                LogicalStructureOfRegistryTreeView.SelectedNode.Nodes.Add(subNode);
            }
        }

        private void AddValue_Click(object sender, EventArgs e)
        {
            var registryKey = LogicalStructureOfRegistryTreeView.SelectedNode.Tag as RegistryKey;
            AddValueForm form = new(registryKey.Name);
            form.ShowDialog();

            foreach (var row in form.Values)
            {
                var item = new ListViewItem(row);
                ValuesListView.Items.Add(item);
            }
        }
    }
}