namespace SP_Lab6
{
    partial class RegistryEditorForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistryEditorForm));
            LogicalStructureOfRegistryTreeView = new TreeView();
            ValuesListView = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            path = new TextBox();
            AddValue = new Button();
            AddSubKey = new Button();
            SaveToFileButton = new Button();
            saveRegistryData = new SaveFileDialog();
            SuspendLayout();
            // 
            // LogicalStructureOfRegistryTreeView
            // 
            LogicalStructureOfRegistryTreeView.Location = new Point(14, 40);
            LogicalStructureOfRegistryTreeView.Name = "LogicalStructureOfRegistryTreeView";
            LogicalStructureOfRegistryTreeView.Size = new Size(319, 501);
            LogicalStructureOfRegistryTreeView.TabIndex = 0;
            LogicalStructureOfRegistryTreeView.AfterSelect += LogicalStructureOfRegistryTreeView_AfterSelect;
            // 
            // ValuesListView
            // 
            ValuesListView.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            ValuesListView.Location = new Point(350, 40);
            ValuesListView.Name = "ValuesListView";
            ValuesListView.Size = new Size(677, 501);
            ValuesListView.TabIndex = 1;
            ValuesListView.UseCompatibleStateImageBehavior = false;
            ValuesListView.View = View.Details;
            ValuesListView.MouseDoubleClick += ValuesListView_MouseDoubleClick;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Имя";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Тип";
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Значение";
            // 
            // path
            // 
            path.Location = new Point(14, 8);
            path.Name = "path";
            path.ReadOnly = true;
            path.Size = new Size(1013, 26);
            path.TabIndex = 2;
            // 
            // AddValue
            // 
            AddValue.Location = new Point(597, 547);
            AddValue.Name = "AddValue";
            AddValue.Size = new Size(159, 28);
            AddValue.TabIndex = 3;
            AddValue.Text = "Добавить значение";
            AddValue.UseVisualStyleBackColor = true;
            AddValue.Click += AddValue_Click;
            // 
            // AddSubKey
            // 
            AddSubKey.Location = new Point(174, 547);
            AddSubKey.Name = "AddSubKey";
            AddSubKey.Size = new Size(159, 28);
            AddSubKey.TabIndex = 4;
            AddSubKey.Text = "Добавить подключ";
            AddSubKey.UseVisualStyleBackColor = true;
            AddSubKey.Click += AddSubKey_Click;
            // 
            // SaveToFileButton
            // 
            SaveToFileButton.Location = new Point(12, 547);
            SaveToFileButton.Name = "SaveToFileButton";
            SaveToFileButton.Size = new Size(146, 28);
            SaveToFileButton.TabIndex = 5;
            SaveToFileButton.Text = "Сохранить в файл";
            SaveToFileButton.UseVisualStyleBackColor = true;
            SaveToFileButton.Click += SaveToFileButton_Click;
            // 
            // RegistryEditorForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1042, 583);
            Controls.Add(SaveToFileButton);
            Controls.Add(AddSubKey);
            Controls.Add(AddValue);
            Controls.Add(path);
            Controls.Add(ValuesListView);
            Controls.Add(LogicalStructureOfRegistryTreeView);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "RegistryEditorForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Редактор реестра";
            Load += RegistryEditorForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TreeView LogicalStructureOfRegistryTreeView;
        private ListView ValuesListView;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private TextBox path;
        private Button AddValue;
        private Button AddSubKey;
        private Button SaveToFileButton;
        private SaveFileDialog saveRegistryData;
    }
}