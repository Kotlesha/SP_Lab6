using Microsoft.Win32;
using System.Text;

namespace SP_Lab6
{
    public partial class AddValueForm : Form
    {
        private readonly string registryKeyPath;
        public List<string[]> Values { get; private set; }

        public AddValueForm(string registryKeyPath)
        {
            InitializeComponent();
            this.registryKeyPath = registryKeyPath;
            valueType.SelectedIndex = 0;
            Values = new();
        }

        private RegistryValueKind GetValueType(string type) => type switch
        {
            "REG_SZ(строковый)" => RegistryValueKind.String,
            "REG_QWORD(64-разрядное число)" => RegistryValueKind.QWord,
            "REG_BINARY(двоичный)" => RegistryValueKind.Binary,
        };

        private void AddValue_Click(object sender, EventArgs e)
        {
            RegistryHive baseKey = RegistryKeyOperations.GetBaseKeyFromSubKey(registryKeyPath);
            RegistryKey key = RegistryKey.OpenBaseKey(baseKey, RegistryView.Registry64);
            string path = RegistryKeyOperations.GetPath(registryKeyPath);
            RegistryKey subKey = key.OpenSubKey(path, true);

            RegistryValueKind subKeyValueType = GetValueType(valueType.Text);
            object? subKeyValue = GetValue(value.Text, subKeyValueType);

            if (subKeyValue == null)
            {
                MessageBox.Show("Значение не является 64-разрядным числом", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                subKey.SetValue(valueName.Text, subKeyValue, subKeyValueType);
            }
            catch
            {
                MessageBox.Show($"Параметр с названием {valueName.Text} невозможно добавить!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string valueFormatted = RegistryKeyOperations.GetRegistryValue(subKeyValue, subKeyValueType);
            string valueTypeFormatted = RegistryKeyOperations.GetRegistryType(subKeyValueType);
            string[] row = { valueName.Text, valueTypeFormatted, valueFormatted };
            Values.Add(row);
            MessageBox.Show($"Параметр с названием {valueName.Text} успешно добавлен!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private object? GetValue(string data, RegistryValueKind valueType)
        {
            if (valueType == RegistryValueKind.String)
            {
                return data;
            }

            if (valueType == RegistryValueKind.QWord)
            {
                if (!int.TryParse(data, out int result))
                {
                    return null;
                }

                return result;
            }

            byte[] bytes = Encoding.UTF8.GetBytes(data);
            return bytes;
        }
    }
}
