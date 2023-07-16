using System;
using System.Windows.Forms;
using BLL;

namespace PL
{
    public partial class EditRecipe : Form
    {
        private readonly Home _form;
        private readonly int _id;
        private readonly RecipeService _recipeService = new RecipeService();

        public EditRecipe()
        {
            InitializeComponent();
        }

        public EditRecipe(Home form, int id)
        {
            _form = form;
            _id = id;
            InitializeComponent();
        }

        private void EditRecipe_Load(object sender, EventArgs e)
        {
            ML.Recipe mRecipe = _recipeService.GetRecipe(_id);
            
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            var recipe = new Recipe(_form);
            _form.OpenForm(recipe);
        }

        private void bSearchAutor_Click(object sender, EventArgs e)
        {
            //Search help = new Search(_personService.GetPerson())
        }
    }
}