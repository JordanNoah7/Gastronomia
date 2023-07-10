using System;
using System.Windows.Forms;
using BLL;

namespace PL
{
    public partial class Recipe : Form
    {
        private readonly RecipeService _recipeService = new RecipeService();
        public Recipe()
        {
            InitializeComponent();
        }

        private void Recipe_Load(object sender, EventArgs e)
        {
            dgvRecipes.DataSource = _recipeService.GetRecipes();
        }
    }
}