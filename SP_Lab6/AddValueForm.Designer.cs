namespace SP_Lab6
{
    partial class AddValueForm
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
            value = new TextBox();
            label2 = new Label();
            valueName = new TextBox();
            label1 = new Label();
            label3 = new Label();
            AddValue = new Button();
            valueType = new ComboBox();
            SuspendLayout();
            // 
            // value
            // 
            value.Location = new Point(15, 152);
            value.Name = "value";
            value.Size = new Size(396, 26);
            value.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 130);
            label2.Name = "label2";
            label2.Size = new Size(76, 20);
            label2.TabIndex = 6;
            label2.Text = "Значение";
            // 
            // valueName
            // 
            valueName.Location = new Point(15, 43);
            valueName.Name = "valueName";
            valueName.Size = new Size(396, 26);
            valueName.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 21);
            label1.Name = "label1";
            label1.Size = new Size(157, 20);
            label1.TabIndex = 4;
            label1.Text = "Название параметра";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 76);
            label3.Name = "label3";
            label3.Size = new Size(115, 20);
            label3.TabIndex = 8;
            label3.Text = "Тип параметра";
            // 
            // AddValue
            // 
            AddValue.Location = new Point(162, 192);
            AddValue.Name = "AddValue";
            AddValue.Size = new Size(90, 28);
            AddValue.TabIndex = 10;
            AddValue.Text = "Добавить";
            AddValue.UseVisualStyleBackColor = true;
            AddValue.Click += AddValue_Click;
            // 
            // valueType
            // 
            valueType.DropDownStyle = ComboBoxStyle.DropDownList;
            valueType.FormattingEnabled = true;
            valueType.Items.AddRange(new object[] { "REG_SZ(строковый)", "REG_QWORD(64-разрядное число)", "REG_BINARY(двоичный)" });
            valueType.Location = new Point(15, 99);
            valueType.Name = "valueType";
            valueType.Size = new Size(396, 27);
            valueType.TabIndex = 11;
            // 
            // AddValueForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(425, 232);
            Controls.Add(valueType);
            Controls.Add(AddValue);
            Controls.Add(label3);
            Controls.Add(value);
            Controls.Add(label2);
            Controls.Add(valueName);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddValueForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Добавление параметра";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox value;
        private Label label2;
        private TextBox valueName;
        private Label label1;
        private Label label3;
        private Button AddValue;
        private ComboBox valueType;
    }
}