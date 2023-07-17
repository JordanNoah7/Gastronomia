using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using ML;

namespace PL
{
    public partial class EditRecipe : Form
    {
        private int i = 2;
        private int location_y;
        private readonly Home _form;
        private readonly int _id;
        private readonly RecipeService _recipeService = new RecipeService();
        private readonly CategoryService _categoryService = new CategoryService();
        private readonly UnitMeasureService _unitMeasureService = new UnitMeasureService();

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

            /*var dgvcbcMeasure = new DataGridViewComboBoxColumn();
            dgvcbcMeasure.DataPropertyName = "ID_UNIDAD_MEDIDA"; 
            dgvcbcMeasure.HeaderText = "Unidad de medida";
            dgvcbcMeasure.Name = "ID_UNIDAD_MEDIDA";
            dgvcbcMeasure.DataSource = _unitMeasureService.GetUnitMeasures();
            dgvcbcMeasure.DisplayMember = "ABREVIATURA";
            dgvcbcMeasure.ValueMember = "ID_UNIDAD_MEDIDA";*/

            dgvIngredients.Columns.Add("ID_INGREDIENTE", "ID_INGREDIENTE");
            dgvIngredients.Columns.Add("Ingrediente", "Ingrediente");
            dgvIngredients.Columns.Add("CANTIDAD", "Cantidad");
            dgvIngredients.Columns.Add("ID_UNIDAD_MEDIDA", "ID_UNIDAD_MEDIDA");
            dgvIngredients.Columns.Add("UNIDAD_MEDIDA", "Unidad de medida");
            dgvIngredients.Columns["ID_INGREDIENTE"].Visible = false;
            dgvIngredients.Columns["ID_UNIDAD_MEDIDA"].Visible = false;
            dgvIngredients.Columns["Ingrediente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvIngredients.Columns["CANTIDAD"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvIngredients.Columns["UNIDAD_MEDIDA"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvIngredients.EnableHeadersVisualStyles = false;
            dgvIngredients.Columns["Ingrediente"].ReadOnly = true;
            dgvIngredients.Columns["UNIDAD_MEDIDA"].ReadOnly = true;

            dgvSteps.Columns.Clear();
            dgvSteps.Columns.Add("DESCRIPCION", "Descripción");
            dgvSteps.Columns["DESCRIPCION"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSteps.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            ML.Recipe mRecipe = _recipeService.GetRecipe(_id);
            tbIdRecipe.Text = mRecipe.ID_RECETA.ToString();
            tbRecipeName.Text = mRecipe.NOMBRE_RECETA;
            tbIdAutor.Text = mRecipe.ID_PERSONA.ToString();
            tbAutor.Text = mRecipe.Persona;
            tbPortions.Text = mRecipe.PORCIONES.ToString();
            tbCookingTime.Text = mRecipe.TIEMPO_COCCION;
            tbPreparationTime.Text = mRecipe.TIEMPO_PREPARACION;
            cbCategory.SelectedValue = mRecipe.ID_CATEGORIA;
            cbDifficulty.SelectedValue = mRecipe.DIFICULTAD;
            tbDescription.Text = mRecipe.DESCRIPCION;

            foreach (DataRow row in mRecipe.Ingredientes.Rows)
            {
                dgvIngredients.Rows.Add(row["ID_INGREDIENTE"], row["NOMBRE"], row["CANTIDAD"], row["ID_UNIDAD_MEDIDA"], row["ABREVIATURA"]);
            }

            //int it = 1;
            foreach (DataRow row in mRecipe.Preparacion.Rows)
            {
                /*if (it == 1)
                {
                    tbStep1.Text = row["Descripcion"].ToString();
                    it++;
                }
                location_y = pSteps.Controls["tbStep" + (i - 1)].Location.Y + 89;
                var tbNuevo = new TextBox();
                tbNuevo.Name = "tbStep" + i;
                tbNuevo.Location = new Point(tbStep1.Location.X, location_y);
                tbNuevo.Multiline = true;
                tbNuevo.Size = tbStep1.Size;
                tbNuevo.Text = row["Descripcion"].ToString();
                pSteps.Controls.Add(tbNuevo);
                i++;*/
                int i = dgvSteps.Rows.Add(row["DESCRIPCION"]);
                dgvSteps.AutoResizeRow(i);
            }
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

        private void dgvIngredients_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}