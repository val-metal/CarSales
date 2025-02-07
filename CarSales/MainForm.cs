using CarSales.Components;
using CarSales.Entites;
using System.ComponentModel;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace CarSales
{
    public partial class MainForm : Form
    {
        private Button buttonSummary;
        private BindingList<Car> cars = new BindingList<Car>();

        public MainForm()
        {
            InitializeComponent();
            this.Resize += (s, e) => UpdateControlPositions();
            MenuSingleton.OnLoadTriggered += performOnLoadXmlUIActions;
            MenuSingleton.OnSaveTriggered += performOnSaveXmlUIActions;
            MenuSingleton.OnNewCarSaleAdded += AddNewCarActions;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateControlPositions();
        }

        private void UpdateControlPositions()
        {
            label_invitation.Left = (this.ClientSize.Width - label_invitation.Width) / 2;
            label_invitation.Top = (this.ClientSize.Height - label_invitation.Height) / 2 - label_invitation.Height;

            button_select_xml.Left = (this.ClientSize.Width - button_select_xml.Width) / 2;
            button_select_xml.Top = (this.ClientSize.Height - button_select_xml.Height) / 2 + button_select_xml.Height;

            button_summary.Left = this.ClientSize.Width - button_summary.Width - 40;
            button_summary.Top = this.ClientSize.Height - button_summary.Height - 10;
        }

        private void InitializeDataGridView()
        {
            dataGridView = new DataGridView
            {
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                Dock = DockStyle.Fill,
                Location = new Point(0, 40), 
                Size = new Size(ClientSize.Width, ClientSize.Height - 20),
                Visible = false
            };
            
            dataGridView.RowHeadersVisible = false;

            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView.EnableHeadersVisualStyles = false;
            Controls.Add(dataGridView);
            dataGridView.DataSource = cars;
        }

        private void ButtonSummary_Click(object sender, EventArgs e)
        {
            if (cars.Count > 0)
            {
                var carGroups = cars.GroupBy(c => c.Model).ToList();
                var carSummary = new List<CarSummary>();

                foreach (var carGroup in carGroups)
                {
                    double groupSumPriceWithoutVat = 0;
                    double groupSumPriceWithVat = 0;

                    foreach (var car in carGroup)
                    {
                        if ((car.Date.DayOfWeek == DayOfWeek.Saturday) || (car.Date.DayOfWeek == DayOfWeek.Sunday))
                        {
                            groupSumPriceWithoutVat += car.Price;
                            groupSumPriceWithVat += (100 + car.VAT) * car.Price / 100;
                        }
                    }
                    carSummary.Add(new CarSummary(carGroup.First().Model, groupSumPriceWithoutVat, groupSumPriceWithVat));
                }

                SumForm sumForm = new SumForm(carSummary);
                sumForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Žádná data k součtu!", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ButtonSelectXml_Click(object sender, EventArgs e)
        {
            MenuSingleton.LoadXml(null, null);
        }

        private void performOnLoadXmlUIActions(object sender, List<Car> loadedCars)
        {
            cars = new BindingList<Car>(loadedCars);
            dataGridView.DataSource = cars;

            label_invitation.Visible = false;
            button_select_xml.Visible = false;
            dataGridView.Visible = true;
            button_summary.Visible = true;
            button_summary.BringToFront();
        }

        private void performOnSaveXmlUIActions(object sender, string filePath)
        {
            CarProvider.saveToXml(cars.ToList(), filePath);

        }

        private void AddNewCarActions(object sender, Car car)
        {
            cars.Add(car);
        }
    }
}
