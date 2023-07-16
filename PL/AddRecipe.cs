using System;
using System.Windows.Forms;
using BLL;

namespace PL
{
    public partial class AddRecipe : Form
    {
        private readonly Home _form;
        private readonly PersonService _personService = new PersonService();

        public AddRecipe()
        {
            InitializeComponent();
        }

        public AddRecipe(Home form)
        {
            _form = form;
            InitializeComponent();
        }

        private void AddRecipe_Load(object sender, EventArgs e)
        {
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            var recipe = new Recipe(_form);
            _form.OpenForm(recipe);
        }

        private void bSearchAutor_Click(object sender, EventArgs e)
        {
            var help = new Search(_personService.GetChefsByLike(tbAutor.Text), "Chefs");
            help.TopLevel = true;
            help.FormBorderStyle = FormBorderStyle.None;
            help.ShowDialog();
            if (help.Id != "")
            {
                tbIdAutor.Text = help.Id;
                tbAutor.Text = help.Fullname;
            }
        }
    }
}