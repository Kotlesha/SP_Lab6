using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SP_Lab6
{
    public partial class AddSubKeyForm : Form
    {
        private readonly string registrySubKeyName;
        public List<(RegistryKey, string)> SubKeys { get; private set; }

        public AddSubKeyForm(string path, string registrySubKeyName)
        {
            InitializeComponent();
            registryPath.Text = path;
            SubKeys = new();
            this.registrySubKeyName = registrySubKeyName;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(subKeyName.Text) || string.IsNullOrWhiteSpace(subKeyName.Text))
            {
                MessageBox.Show("Название подключа не может быть пустой строкой!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            RegistryHive? baseKey = RegistryKeyOperations.GetBaseKeyFromSubKey(registrySubKeyName);
            RegistryKey key = RegistryKey.OpenBaseKey(baseKey.Value, RegistryView.Registry64);
            string path = RegistryKeyOperations.GetPath(registrySubKeyName) + '\\';
            RegistryKey subKey = key.OpenSubKey(path, true);

            try
            {
                var newKey = subKey ?? key.CreateSubKey(subKeyName.Text);
                MessageBox.Show($"Подключ с названием {subKeyName.Text} по пути {newKey.Name} успешно создан!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SubKeys.Add((newKey,  subKeyName.Text));
                Close();
            }
            catch {
                MessageBox.Show($"Подключ с названием {subKeyName.Text} невозможно создать!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
