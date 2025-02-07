using CarSales.Entites;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CarSales
{
    public partial class SumForm : Form
    {
        private DataGridView dataGridView;

        public SumForm(List<CarSummary> carSummary)
        {
            InitializeComponent();
            SetupForm(carSummary);
        }

        private void AdjustFormSize()
        {
            int totalHeight = dataGridView.ColumnHeadersHeight;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                totalHeight += row.Height;
            }

            int totalWidth = 0;
            foreach (DataGridViewColumn col in dataGridView.Columns)
            {
                totalWidth += col.Width;
            }

            int paddingWidth = this.Width - this.ClientSize.Width;
            int paddingHeight = this.Height - this.ClientSize.Height;

            this.Size = new Size(totalWidth + paddingWidth +2, totalHeight + paddingHeight -30);

            dataGridView.Size = new Size(totalWidth, totalHeight);
        }

        private void SetupForm(List<CarSummary> carSummary)
        {
            this.Text = "Součet prodejů";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.FormBorderStyle = FormBorderStyle.FixedDialog; 
            this.MaximizeBox = false; 

            dataGridView = new DataGridView
            {
                Dock = DockStyle.Fill,
                AllowUserToAddRows = false,
                RowTemplate = { Height = 30 },
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                ColumnHeadersVisible = false, 
                RowHeadersVisible = false
            };
            dataGridView.CellPainting += (sender, e) =>
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    if (e.RowIndex % 2 != 1) 
                    {
                        e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
                    }
                }
            };

            dataGridView.Columns.Add("PriceWithoutVat", "Cena bez DPH");
            dataGridView.Columns.Add("PriceWithVat", "Cena s DPH");

            int headerIndex = dataGridView.Rows.Add();
            dataGridView.Rows[headerIndex].Cells[0].Value = "Model";
            dataGridView.Rows[headerIndex].Cells[1].Value = "";
            dataGridView.Rows[headerIndex].DefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dataGridView.Rows[headerIndex].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Rows[headerIndex].DefaultCellStyle.BackColor = Color.LightGray;

            int subHeaderIndex = dataGridView.Rows.Add();
            dataGridView.Rows[subHeaderIndex].Cells[0].Value = "Cena bez DPH";
            dataGridView.Rows[subHeaderIndex].Cells[1].Value = "Cena s DPH";
            dataGridView.Rows[subHeaderIndex].DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dataGridView.Rows[subHeaderIndex].DefaultCellStyle.BackColor = Color.LightGray;

            foreach (var car in carSummary)
            {
                int rowIndex = dataGridView.Rows.Add();
                dataGridView.Rows[rowIndex].Cells[0].Value = car.Model;

                rowIndex = dataGridView.Rows.Add();
                dataGridView.Rows[rowIndex].Cells[0].Value = car.PriceWithoutVat;
                dataGridView.Rows[rowIndex].Cells[1].Value = car.PriceWithVat;
            }

            dataGridView.Columns[0].Width = 200;
            dataGridView.Columns[1].Width = 200;

            Controls.Add(dataGridView);
            AdjustFormSize();
        }
    }
}
