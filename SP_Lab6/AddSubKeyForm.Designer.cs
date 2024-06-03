namespace SP_Lab6
{
    partial class AddSubKeyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            subKeyName = new TextBox();
            label2 = new Label();
            registryPath = new TextBox();
            label1 = new Label();
            Add = new Button();
            SuspendLayout();
            // 
            // subKeyName
            // 
            subKeyName.Location = new Point(16, 105);
            subKeyName.Name = "subKeyName";
            subKeyName.Size = new Size(396, 26);
            subKeyName.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 83);
            label2.Name = "label2";
            label2.Size = new Size(150, 20);
            label2.TabIndex = 6;
            label2.Text = "Название подключа";
            // 
            // registryPath
            // 
            registryPath.Location = new Point(16, 47);
            registryPath.Name = "registryPath";
            registryPath.ReadOnly = true;
            registryPath.Size = new Size(396, 26);
            registryPath.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 25);
            label1.Name = "label1";
            label1.Size = new Size(41, 20);
            label1.TabIndex = 4;
            label1.Text = "Путь";
            // 
            // Add
            // 
            Add.Location = new Point(162, 147);
            Add.Name = "Add";
            Add.Size = new Size(90, 28);
            Add.TabIndex = 8;
            Add.Text = "Добавить";
            Add.UseVisualStyleBackColor = true;
            Add.Click += Add_Click;
            // 
            // AddSubKeyForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(425, 187);
            Controls.Add(Add);
            Controls.Add(subKeyName);
            Controls.Add(label2);
            Controls.Add(registryPath);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddSubKeyForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Добавление подключа";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox subKeyName;
        private Label label2;
        private TextBox registryPath;
        private Label label1;
        private Button Add;
    }
}