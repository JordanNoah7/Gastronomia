using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL
{
    public partial class AddStep : Form
    {
        public string step;

        public AddStep()
        {
            InitializeComponent();
        }

        private void AddStep_Load(object sender, EventArgs e)
        {
            Text = "Añadir paso";
        }

        private void bAccept_Click(object sender, EventArgs e)
        {
            step = tbStep.Text;
            Close();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
