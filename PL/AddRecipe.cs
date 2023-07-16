using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BLL;

namespace PL
{
    public partial class AddRecipe : Form
    {
        private readonly Home _form;
        private readonly PersonService _personService = new PersonService();
        private readonly CategoryService _categoryService = new CategoryService();

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
            cbCategory.DataSource = _categoryService.GetCategories();
            cbCategory.DisplayMember = "NOMBRE_CATEGORIA";
            cbCategory.ValueMember = "ID_CATEGORIA";

            cbDifficulty.Items.Add(new KeyValuePair<int, string>(1, "Muy fácil"));
            cbDifficulty.Items.Add(new KeyValuePair<int, string>(2, "Fácil"));
            cbDifficulty.Items.Add(new KeyValuePair<int, string>(3, "Medio"));
            cbDifficulty.Items.Add(new KeyValuePair<int, string>(4, "Moderado"));
            cbDifficulty.Items.Add(new KeyValuePair<int, string>(5, "Profesional"));
            cbDifficulty.DisplayMember = "Value";
            cbDifficulty.ValueMember = "Key";
            cbDifficulty.SelectedIndex = 0;
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