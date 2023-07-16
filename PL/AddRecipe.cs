using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BLL;

namespace PL
{
    public partial class AddRecipe : Form
    {
        private readonly CategoryService _categoryService = new CategoryService();
        private readonly Home _form;
        private readonly PersonService _personService = new PersonService();
        private readonly ProductService _productService = new ProductService();
        private readonly RecipeService _recipeService = new RecipeService();
        private readonly UnitMeasureService _unitMeasureService = new UnitMeasureService();
        private int i = 2;
        private int location_y;

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

            var dtDifficulty = new DataTable();
            dtDifficulty.Columns.Add("Value");
            dtDifficulty.Columns.Add("Display");

            dtDifficulty.Rows.Add(1, "Muy fácil");
            dtDifficulty.Rows.Add(2, "Fácil");
            dtDifficulty.Rows.Add(3, "Medio");
            dtDifficulty.Rows.Add(4, "Moderado");
            dtDifficulty.Rows.Add(5, "Profesional");
            cbDifficulty.DataSource = dtDifficulty;
            cbDifficulty.DisplayMember = "Display";
            cbDifficulty.ValueMember = "Value";
            cbDifficulty.SelectedIndex = 1;

            var dgvcbcMeasure = new DataGridViewComboBoxColumn();
            dgvcbcMeasure.HeaderText = "Unidad de medida";
            dgvcbcMeasure.Name = "ID_UNIDAD_MEDIDA";
            dgvcbcMeasure.DataSource = _unitMeasureService.GetUnitMeasures();
            dgvcbcMeasure.DisplayMember = "ABREVIATURA";
            dgvcbcMeasure.ValueMember = "ID_UNIDAD_MEDIDA";

            dgvIngredients.Columns.Add("ID_INGREDIENTE", "ID_INGREDIENTE");
            dgvIngredients.Columns.Add("Ingrediente", "Ingrediente");
            dgvIngredients.Columns.Add("CANTIDAD", "Cantidad");
            dgvIngredients.Columns.Add(dgvcbcMeasure);
            dgvIngredients.Columns["ID_INGREDIENTE"].Visible = false;
            dgvIngredients.Columns["Ingrediente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvIngredients.Columns["CANTIDAD"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvIngredients.Columns["ID_UNIDAD_MEDIDA"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvIngredients.EnableHeadersVisualStyles = false;
            dgvIngredients.Columns["Ingrediente"].ReadOnly = true;
        }

        private void dgvIngredients_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == dgvIngredients.Columns["CANTIDAD"].Index)
            {
                var valor = e.FormattedValue.ToString();
                float numero;
                if (string.IsNullOrEmpty(valor))
                {
                }
                else if (!float.TryParse(valor, out numero))
                {
                    //dgvIngredients.Rows[e.RowIndex].ErrorText = "Solo números.";
                    MessageBox.Show("Ingrese un valo numérico válido.");
                    e.Cancel = true;
                }
            }
        }

        private void dgvIngredients_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //dgvIngredients.Rows[e.RowIndex].ErrorText = string.Empty;
        }

        private void dgvIngredients_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 2 && string.IsNullOrEmpty(dgvIngredients.Rows[e.RowIndex].Cells[0].Value?.ToString()))
                e.Cancel = true;
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

        private void bAddIngredient_Click(object sender, EventArgs e)
        {
            var help = new Search(_productService.GetProducts(), "Productos");
            help.TopLevel = true;
            help.FormBorderStyle = FormBorderStyle.None;
            help.ShowDialog();
            if (!string.IsNullOrEmpty(help.Id)) dgvIngredients.Rows.Add(help.Id, help.Fullname);
        }

        private void bAddStep_Click(object sender, EventArgs e)
        {
            location_y = pSteps.Controls["tbStep" + (i - 1)].Location.Y + 89;
            var tbNuevo = new TextBox();
            tbNuevo.Name = "tbStep" + i;
            tbNuevo.Location = new Point(tbStep1.Location.X, location_y);
            tbNuevo.Multiline = true;
            tbNuevo.Size = tbStep1.Size;
            pSteps.Controls.Add(tbNuevo);
            i++;
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            var recipe = new ML.Recipe();
            recipe.NOMBRE_RECETA = tbRecipeName.Text;
            recipe.DESCRIPCION = tbDescription.Text;
            recipe.TIEMPO_PREPARACION = tbPreparationTime.Text;
            recipe.TIEMPO_COCCION = tbCookingTime.Text;
            recipe.PORCIONES = Convert.ToByte(tbPortions.Text);
            recipe.DIFICULTAD = Convert.ToByte(cbDifficulty.SelectedValue);
            recipe.ID_CATEGORIA = Convert.ToInt32(cbCategory.SelectedValue);
            recipe.ID_PERSONA = Convert.ToInt32(tbIdAutor.Text);

            recipe.Ingredientes.Columns.Add("ID_INGREDIENTE", typeof(int));
            recipe.Ingredientes.Columns.Add("CANTIDAD", typeof(float));
            recipe.Ingredientes.Columns.Add("ID_UNIDAD_MEDIDA", typeof(int));

            foreach (DataGridViewRow dgvIngredient in dgvIngredients.Rows)
                recipe.Ingredientes.Rows.Add(dgvIngredient.Cells["ID_INGREDIENTE"].Value.ToString(),
                    dgvIngredient.Cells["CANTIDAD"].Value.ToString(),
                    dgvIngredient.Cells["ID_UNIDAD_MEDIDA"].Value.ToString());

            recipe.Preparacion.Columns.Add("ID_PASO", typeof(int));
            recipe.Preparacion.Columns.Add("DESCRIPCION", typeof(string));
            var it = 1;
            foreach (Control step in pSteps.Controls)
            {
                recipe.Preparacion.Rows.Add(it, step.Text);
                it++;
            }

            if (_recipeService.AddRecipe(recipe))
            {
                MessageBox.Show("La receta se agregó correctamente.", "Éxito", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                var fRecipe = new Recipe(_form);
                _form.OpenForm(fRecipe);
            }
            else
            {
                MessageBox.Show("Hubo un error al agregar la receta.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}