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
    public partial class EditRecipe : Form
    {
        private Home _form;
        private int _id;

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
            tbRecipeName.Text = _id.ToString();
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
    }
}
