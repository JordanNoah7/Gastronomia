using System;
using System.Drawing;
using System.Windows.Forms;

namespace PL
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        public Home(string name)
        {
            InitializeComponent();
            lName.Text = name;
        }

        private void Home_Load(object sender, EventArgs e)
        {
        }

        private void bRecipes_Click(object sender, EventArgs e)
        {
            Recipe recipe = new Recipe();
            recipe.TopLevel = false;
            recipe.FormBorderStyle = FormBorderStyle.None;
            pVentana.Controls.Add(recipe);
            recipe.Location = new Point(0, 0);
            recipe.Anchor = pVentana.Anchor;
            recipe.Show();
        }
    }
}