using System;
using System.Windows.Forms;
using BLL;

namespace PL
{
    public partial class AddRecipe : Form
    {
        private readonly PersonService _personService = new PersonService();
        private Home _form;

        public AddRecipe()
        {
            InitializeComponent();
        }
        
        public AddRecipe(Home form)
        {
            _form = form;
            InitializeComponent();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Recipe recipe = new Recipe(_form);
            _form.OpenForm(recipe);
        }

        private void bSearchAutor_Click(object sender, EventArgs e)
        {
            //Search help = new Search(_personService.GetPerson())
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}