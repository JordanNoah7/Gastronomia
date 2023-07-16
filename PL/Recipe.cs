using System;
using System.Data;
using System.Drawing;
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
            DataGridViewButtonColumn dgvbcUpdate = new DataGridViewButtonColumn();
            dgvbcUpdate.Name = "Editar";
            dgvbcUpdate.HeaderText = "Editar";
            dgvbcUpdate.Text = "-";
            dgvbcUpdate.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvbcUpdate.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn dgvbcDelete = new DataGridViewButtonColumn();
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
            if(e.ColumnIndex == dgvRecipes.Columns["Eliminar"].Index)
            {

            }
            else if (e.ColumnIndex == dgvRecipes.Columns["Editar"].Index)
            {

            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            string filter = tbFilter.Text;
            (dgvRecipes.DataSource as DataTable).DefaultView.RowFilter = $"Receta LIKE '%{filter}%'";
        }

        private void bAddRecipe_Click(object sender, EventArgs e)
        {
            AddRecipe addRecipe = new AddRecipe();
            addRecipe.TopLevel = true;
            addRecipe.FormBorderStyle = FormBorderStyle.None;
            //pVentana.Controls.Add(recipe);
            //recipe.Location = new Point(0, 0);
            //recipe.Anchor = pVentana.Anchor;
            addRecipe.ShowDialog();
        }
    }
}