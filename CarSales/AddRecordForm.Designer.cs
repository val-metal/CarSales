namespace CarSales
{
    partial class AddRecordForm
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
            labelModel = new Label();
            comboBoxModel = new ComboBox();
            labelDate = new Label();
            dateTimePickerDate = new DateTimePicker();
            labelPrice = new Label();
            textBoxPrice = new TextBox();
            labelVAT = new Label();
            textBoxVAT = new TextBox();
            buttonSave = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            numericUpDownPrice = new NumericUpDown();
            numericUpDownVAT = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownVAT).BeginInit();
            SuspendLayout();
            // 
            // labelModel
            // 
            labelModel.AutoSize = true;
            labelModel.Location = new Point(57, 20);
            labelModel.Name = "labelModel";
            labelModel.Size = new Size(124, 25);
            labelModel.TabIndex = 0;
            labelModel.Text = "Vybrat model:";
            // 
            // comboBoxModel
            // 
            comboBoxModel.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxModel.FormattingEnabled = true;
            comboBoxModel.Location = new Point(187, 17);
            comboBoxModel.Name = "comboBoxModel";
            comboBoxModel.Size = new Size(200, 33);
            comboBoxModel.TabIndex = 1;
            comboBoxModel.SelectedIndexChanged += ComboBoxModel_SelectedIndexChanged;
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Location = new Point(45, 98);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(136, 25);
            labelDate.TabIndex = 2;
            labelDate.Text = "Datum prodeje:";
            // 
            // dateTimePickerDate
            // 
            dateTimePickerDate.Format = DateTimePickerFormat.Short;
            dateTimePickerDate.Location = new Point(187, 93);
            dateTimePickerDate.Name = "dateTimePickerDate";
            dateTimePickerDate.Size = new Size(200, 31);
            dateTimePickerDate.TabIndex = 3;
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Location = new Point(126, 133);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(55, 25);
            labelPrice.TabIndex = 4;
            labelPrice.Text = "Cena:";
            // 
            // labelVAT
            // 
            labelVAT.AutoSize = true;
            labelVAT.Location = new Point(99, 170);
            labelVAT.Name = "labelVAT";
            labelVAT.Size = new Size(82, 25);
            labelVAT.TabIndex = 6;
            labelVAT.Text = "DPH (%):";
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(117, 246);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(200, 30);
            buttonSave.TabIndex = 8;
            buttonSave.Text = "Uložit";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // textBox1
            // 
            textBox1.Enabled = false;
            textBox1.Location = new Point(187, 56);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(200, 31);
            textBox1.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(67, 59);
            label1.Name = "label1";
            label1.Size = new Size(114, 25);
            label1.TabIndex = 9;
            label1.Text = "Nový model:";
            // 
            // numericUpDownPrice
            // 
            numericUpDownPrice = new NumericUpDown();
            numericUpDownPrice.Location = new Point(187, 130);
            numericUpDownPrice.Name = "numericUpDownPrice";
            numericUpDownPrice.Size = new Size(200, 31);
            numericUpDownPrice.Minimum = 1;
            numericUpDownPrice.Maximum = 10000000;
            numericUpDownPrice.Value = 100000;
            numericUpDownPrice.DecimalPlaces = 2; 
            numericUpDownPrice.Increment = 10000; 

            // 
            // numericUpDownVAT
            // 
            numericUpDownVAT = new NumericUpDown();
            numericUpDownVAT.Location = new Point(187, 167);
            numericUpDownVAT.Name = "numericUpDownVAT";
            numericUpDownVAT.Size = new Size(200, 31);
            numericUpDownVAT.Value = 20;
            numericUpDownVAT.Minimum = 0; 
            numericUpDownVAT.Maximum = 100; 
            numericUpDownVAT.DecimalPlaces = 2;
            numericUpDownVAT.Increment = 1; 
            // 
            // AddRecordForm
            // 
            ClientSize = new Size(429, 297);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(buttonSave);
            Controls.Add(labelVAT);
            Controls.Add(labelPrice);
            Controls.Add(dateTimePickerDate);
            Controls.Add(labelDate);
            Controls.Add(comboBoxModel);
            Controls.Add(labelModel);
            Controls.Add(numericUpDownPrice);
            Controls.Add(numericUpDownVAT);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "AddRecordForm";
            Text = "Přidat nový záznam";
            ((System.ComponentModel.ISupportInitialize)numericUpDownPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownVAT).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelModel;
        private System.Windows.Forms.ComboBox comboBoxModel;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerDate;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Label labelVAT;
        private System.Windows.Forms.TextBox textBoxVAT;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.NumericUpDown numericUpDownPrice;
        private System.Windows.Forms.NumericUpDown numericUpDownVAT;


        private void ButtonSave_Click(object sender, EventArgs e)
        {
            string model = comboBoxModel.SelectedItem.ToString();
            DateTime saleDate = dateTimePickerDate.Value;
            double price;
            double vat;

            if (double.TryParse(textBoxPrice.Text, out price) && price > 0 &&
                double.TryParse(textBoxVAT.Text, out vat) && vat >= 0 && vat <= 100)
            {
                MessageBox.Show($"Model: {model}\nDatum prodeje: {saleDate.ToShortDateString()}\nCena: {price}\nDPH: {vat}%", "Záznam uložen");
            }
            else
            {
                MessageBox.Show("Prosím, zadejte platné údaje.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private TextBox textBox1;
        private Label label1;
    }
}
