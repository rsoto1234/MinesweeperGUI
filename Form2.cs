using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinesweeperGUI
{
    public partial class Form2 : Form
    {
        private Button button;
        public Form2()
        {
            InitializeComponent();
            InitializeGrid();
            AssociateClickEvent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.FormClosed += MainPage_FormClosed;
        }

        /// Create Buttons for all cells in the grid

        private void MainPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void InitializeGrid()
        {
            for (int i = 0; i < tableLayoutPanel1.ColumnCount; i++)
            {
                for (int j = 0; j < tableLayoutPanel1.RowCount; j++)
                {
                    button = new Button();
                    button.Visible = true;
                    button.Dock = DockStyle.Fill;

                    tableLayoutPanel1.Controls.Add(button, i, j);
                }
            }
        }

        /// Associate a Click event for all the buttons in the grid
        private void AssociateClickEvent()
        {
            foreach (Control c in tableLayoutPanel1.Controls.OfType<Button>())
            {
                c.Click += new EventHandler(OnClick);
            }
        }

        /// Handle the Click event
        /// <param name="sender">Button</param>
        /// <param name="e">Click</param>
        private void OnClick(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.Visible = true;

            button.BackColor = Color.Red;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}