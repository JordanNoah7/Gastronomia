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
        private readonly PersonService _personService = new PersonService();

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
                int i = dgvSteps.Rows.Add(row["Descripcion"]);
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
            var help = new Search(_personService.GetChefsByLike(""), "Chefs");
            help.TopLevel = true;
            help.FormBorderStyle = FormBorderStyle.None;
            help.ShowDialog();
            if (help.Id != "")
            {
                tbIdAutor.Text = help.Id;
                tbAutor.Text = help.Fullname;
            }
        }

        private void dgvIngredients_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void bAddIngredient_Click(object sender, EventArgs e)
        {
            var help = new AddProduct();
            help.TopLevel = true;
            help.FormBorderStyle = FormBorderStyle.None;
            help.ShowDialog();
            if (!string.IsNullOrEmpty(help.product)) dgvIngredients.Rows.Add(help.idProduct, help.product, "", help.idMeasure, help.measure);
        }

        private void bDeleteIngredient_Click(object sender, EventArgs e)
        {
            if(dgvIngredients.SelectedRows.Count > 0)
            {
                DataGridViewRow dgvr = dgvIngredients.SelectedRows[0];
                dgvIngredients.Rows.Remove(dgvr);
            }
        }

        private void bDeleteStep_Click(object sender, EventArgs e)
        {
            if (dgvSteps.SelectedRows.Count > 0)
            {
                DataGridViewRow dgvr = dgvSteps.SelectedRows[0];
                dgvSteps.Rows.Remove(dgvr);
            }
        }

        private void bAddStep_Click(object sender, EventArgs e)
        {
            var help = new AddStep();
            help.TopLevel = true;
            help.FormBorderStyle = FormBorderStyle.None;
            help.ShowDialog();
            if (!string.IsNullOrEmpty(help.step.ToString())) {
                int i = dgvSteps.Rows.Add(help.step);
                dgvSteps.AutoResizeRow(i);
            }
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            var recipe = new ML.Recipe();
            recipe.ID_RECETA = Convert.ToInt32(tbIdRecipe.Text);
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
            foreach (DataGridViewRow dgvStep in dgvSteps.Rows)
            {
                //recipe.Preparacion.Rows.Add(it, step.Text);
                recipe.Preparacion.Rows.Add(it, dgvStep.Cells["DESCRIPCION"].Value.ToString());
                it++;
            }

            if (_recipeService.UpdateRecipe(recipe))
            {
                MessageBox.Show("La receta se actualizó correctamente.", "Éxito", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                var fRecipe = new Recipe(_form);
                _form.OpenForm(fRecipe);
            }
            else
            {
                MessageBox.Show("Hubo un error al actualizar la receta.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}