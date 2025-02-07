using CarSales.Components;

namespace CarSales
{
    partial class MainForm
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

        private void InitializeComponent()
        {
            label_invitation = new Label();
            button_select_xml = new Button();
            button_summary = new Button();
            menuStrip1 = new MenuStrip();
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1, 
                RowCount = 2, 
            };

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

            ToolStripMenuItem souborToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            SuspendLayout();
            // 
            // label_invitation
            // 
            label_invitation.AutoSize = true;
            label_invitation.Location = new Point(0, 0);
            label_invitation.Name = "label_invitation";
            label_invitation.Size = new Size(241, 25);
            label_invitation.TabIndex = 0;
            label_invitation.Text = "Prosím, vyberte XML soubor.";
            // 
            // button_select_xml
            // 
            button_select_xml.Location = new Point(0, 0);
            button_select_xml.Name = "button_select_xml";
            button_select_xml.Size = new Size(112, 34);
            button_select_xml.TabIndex = 1;
            button_select_xml.Text = "Vybrat XML";
            button_select_xml.UseVisualStyleBackColor = true;
            button_select_xml.Click += ButtonSelectXml_Click;
            // 
            // button_summary
            // 
            button_summary.Location = new Point(0, 0);
            button_summary.Name = "button_summary";
            button_summary.Size = new Size(112, 34);
            button_summary.TabIndex = 2;
            button_summary.Text = "Součet";
            button_summary.UseVisualStyleBackColor = true;
            button_summary.Visible = false;
            button_summary.Click += ButtonSummary_Click;
            // 
            // menuStrip1
            // 
            menuStrip1 = MenuSingleton.Instance;
            tableLayoutPanel.Controls.Add(menuStrip1, 0, 0); 
            tableLayoutPanel.Controls.Add(dataGridView, 0, 1);
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button_select_xml);
            Controls.Add(label_invitation);
            Controls.Add(button_summary);
            Controls.Add(tableLayoutPanel);
            //Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Text = "Hlavní obrazovka";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private Label label_invitation;
        private Button button_select_xml;
        private Button button_summary;
        private MenuStrip menuStrip1;
        private DataGridView dataGridView;
    }
}
