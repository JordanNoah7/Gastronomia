using System;
using System.Drawing;
using System.Windows.Forms;

namespace PL
{
    public partial class Home : Form
    {
        private Login _login;
        public Home()
        {
            InitializeComponent();
        }

        public Home(string name, Login login)
        {
            InitializeComponent();
            lName.Text = name;
            _login = login;
        }

        internal void OpenForm(Form form)
        {
            pVentana.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            pVentana.Controls.Add(form);
            form.Location = new Point(0, 0);
            form.Anchor = pVentana.Anchor;
            form.Show();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            var recipe = new Recipe(this);
            OpenForm(recipe);
        }

        private void bRecipes_Click(object sender, EventArgs e)
        {
            var recipe = new Recipe(this);
            OpenForm(recipe);
        }

        private void bLogout_Click(object sender, EventArgs e)
        {
            Close();
            _login.Show();
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            _login.Close();
        }
    }
}