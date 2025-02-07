using CarSales.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarSales
{
    public partial class AddRecordForm : Form
    {
        public Car newCar { get; private set; }
        public AddRecordForm()
        {

            HashSet<string> uniqueModels = new HashSet<string>();

            foreach (Car car in CarProvider.loadedCars)
            {
                uniqueModels.Add(car.Model);
            }
            uniqueModels.Add("Nový model");

            InitializeComponent();
            comboBoxModel.Items.AddRange(uniqueModels.ToArray());
        }

        public void ComboBoxModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedModel = comboBoxModel.SelectedItem?.ToString();
            if (selectedModel.Equals("Nový model"))
            {
                textBox1.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
                textBox1.Text = "";
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            List<string> validationMessages = new List<string>();
            string selectedModel = comboBoxModel.SelectedItem?.ToString();
            if (selectedModel.Equals("Nový model"))
            {
                selectedModel = textBox1.Text;
            }
            DateTime dateTime = dateTimePickerDate.Value.Date;

            double price = (double)numericUpDownPrice.Value;
            double vat = (double)numericUpDownVAT.Value;

            if (selectedModel.Length <= 4)
            {
                validationMessages.Add("Název modelu musí být delší než 4 znaky.");
            }
            if (dateTime > DateTime.Now.Date)
            {
                validationMessages.Add("Datum nesmí být v budoucnosti.");
            }
            if (price <= 0 || price >= 10000000)
            {
                validationMessages.Add("Cena musí být v intervalu 1-10000000.");
            }
            if (vat < 0 || vat >= 100)
            {
                validationMessages.Add("DPH musí být uvedeno v % (0-99).");
            }


            if (validationMessages.Any())
            {
                MessageBox.Show(string.Join("\n", validationMessages), "Chyba validace", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            newCar = new Car(selectedModel, dateTime, price, vat);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
