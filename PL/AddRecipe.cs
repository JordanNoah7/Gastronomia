using System;
using System.Windows.Forms;
using BLL;

namespace PL
{
    public partial class AddRecipe : Form
    {
        private readonly PersonService _personService = new PersonService();
        
        public AddRecipe()
        {
            InitializeComponent();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bSearchAutor_Click(object sender, EventArgs e)
        {
            //Search help = new Search(_personService.GetPerson())
        }
    }
}