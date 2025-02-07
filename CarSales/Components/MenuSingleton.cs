using CarSales.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CarSales.Components
{
    public class MenuSingleton
    {
        private static MenuStrip _instance;
        public static event EventHandler<List<Car>> OnLoadTriggered;
        public static event EventHandler<string> OnSaveTriggered;
        public static event EventHandler<Car> OnNewCarSaleAdded;
        private MenuSingleton() { }
        public static MenuStrip Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MenuStrip();
                    _instance.ImageScalingSize = new System.Drawing.Size(24, 24);
                    _instance.Location = new System.Drawing.Point(0, 0);
                    _instance.Name = "menuStrip";
                    _instance.Size = new System.Drawing.Size(800, 32);
                    _instance.TabIndex = 3;
                    _instance.Text = "menuStrip";


                    ToolStripMenuItem fileToolStripMenuItem = new ToolStripMenuItem("Soubor");
                    ToolStripMenuItem openToolStripMenuItem = new ToolStripMenuItem("Otevřít");
                    openToolStripMenuItem.Click += LoadXml;
                    ToolStripMenuItem saveToolStripMenuItem = new ToolStripMenuItem("Uložit");
                    saveToolStripMenuItem.Enabled=false;
                    saveToolStripMenuItem.Click += SaveXml;

                    fileToolStripMenuItem.DropDownItems.Add(openToolStripMenuItem);
                    fileToolStripMenuItem.DropDownItems.Add(saveToolStripMenuItem);

                    ToolStripMenuItem editToolStripMenuItem = new ToolStripMenuItem("Upravit");
                    ToolStripMenuItem addRecordToolStripMenuItem = new ToolStripMenuItem("Přidat záznam");
                    addRecordToolStripMenuItem.Enabled = false;

                    addRecordToolStripMenuItem.Click += AddRecordToolStripMenuItem_Click;

                    editToolStripMenuItem.DropDownItems.Add(addRecordToolStripMenuItem);

                    _instance.Items.Add(fileToolStripMenuItem);
                    _instance.Items.Add(editToolStripMenuItem);
                }

                return _instance;
            }
        }

        public static void LoadXml(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML soubory (*.xml)|*.xml";
            openFileDialog.Title = "Vyberte XML soubor";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                if (OnLoadTriggered != null)
                {
                    List<Car> loaded = CarProvider.fromXml(filePath);
                    if (loaded.Count == 0)
                    {
                        return;
                    }
                    OnLoadTriggered.Invoke(null, loaded);
                    foreach (ToolStripMenuItem item in _instance.Items)
                    {
                        if (item.Text == "Soubor")
                        {
                            foreach (ToolStripMenuItem i in item.DropDownItems)
                            {
                                if (i.Text == "Uložit")
                                {
                                    i.Enabled = true;
                                }
                            }
                        }
                        else if (item.Text == "Upravit")
                        {
                            foreach (ToolStripMenuItem i in item.DropDownItems)
                            {
                                i.Enabled = true;
                            }
                        }
                    }
                }
            }
        }
        public static void SaveXml(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "XML soubory (*.xml)|*.xml";
                saveFileDialog.Title = "Uložit XML soubor";
                saveFileDialog.FileName = "cars.xml";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    OnSaveTriggered?.Invoke(sender, filePath);                   
                }
            }
        }

        private static void AddRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddRecordForm addRecordForm = new AddRecordForm();

            if (addRecordForm.ShowDialog() == DialogResult.OK)
            {
                Car addedCar = addRecordForm.newCar;
                OnNewCarSaleAdded.Invoke(null, addedCar);
                MessageBox.Show($"Nový záznam byl uspěšně přidán do tabulky", "Přidáno", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
