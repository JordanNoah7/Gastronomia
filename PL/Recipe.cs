using System;
using System.Data;
using System.Windows.Forms;
using BLL;

namespace PL
{
    public partial class Recipe : Form
    {
        private readonly Home _form;
        private readonly RecipeService _recipeService = new RecipeService();

        public Recipe()
        {
            InitializeComponent();
        }

        public Recipe(Home form)
        {
            _form = form;
            InitializeComponent();
        }

        private void Recipe_Load(object sender, EventArgs e)
        {
            var dgvbcUpdate = new DataGridViewButtonColumn();
            dgvbcUpdate.Name = "Editar";
            dgvbcUpdate.HeaderText = "Editar";
            dgvbcUpdate.Text = "-";
            dgvbcUpdate.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvbcUpdate.UseColumnTextForButtonValue = true;

            var dgvbcDelete = new DataGridViewButtonColumn();
            dgvbcDelete.Name = "Eliminar";
            dgvbcDelete.HeaderText = "Eliminar";
            dgvbcDelete.Text = "X";
            dgvbcDelete.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvbcDelete.UseColumnTextForButtonValue = true;

            dgvRecipes.Columns.Clear();

            dgvRecipes.CellContentClick += DataGridView_CellContentClick;
            tbFilter.TextChanged += TextBox_TextChanged;

            dgvRecipes.DataSource = _recipeService.GetRecipes();
            dgvRecipes.Columns["Nro"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvRecipes.Columns["Receta"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvRecipes.Columns["Autor"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvRecipes.Columns.Add(dgvbcUpdate);
            dgvRecipes.Columns.Add(dgvbcDelete);
        }

        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvRecipes.Columns["Eliminar"].Index)
            {
                var id = Convert.ToInt32(dgvRecipes.CurrentRow.Cells["Nro"].Value);
                var result = MessageBox.Show("¿Está seguro que desea eliminar esta receta?", "Confirmación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (_recipeService.DeleteRecipe(id))
                    {
                        MessageBox.Show("La receta se eliminó correctamente.", "Éxito", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        Recipe fRecipe = new Recipe(_form);
                        _form.OpenForm(fRecipe);
                    }

                    else
                        MessageBox.Show("Hubo un error al eliminar la receta.", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }
            }
            else if (e.ColumnIndex == dgvRecipes.Columns["Editar"].Index)
            {
                var id = Convert.ToInt32(dgvRecipes.CurrentRow.Cells["Nro"].Value);
                var editRecipe = new EditRecipe(_form, id);
                _form.OpenForm(editRecipe);
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            var filter = tbFilter.Text;
            (dgvRecipes.DataSource as DataTable).DefaultView.RowFilter = $"Receta LIKE '%{filter}%'";
        }

        private void bAddRecipe_Click(object sender, EventArgs e)
        {
            var addRecipe = new AddRecipe(_form);
            _form.OpenForm(addRecipe);
        }
    }
}