using BLL;
using System;
using System.Windows.Forms;

namespace PL
{
    public partial class AddProduct : Form
    {
        private readonly ProductService _productService = new ProductService();
        private readonly UnitMeasureService _unitMeasureService = new UnitMeasureService();

        public int idProduct, idMeasure;
        public string product, measure;
        public decimal quantity;
        public AddProduct()
        {
            InitializeComponent();
        }

        private void bSearchProducto_Click(object sender, EventArgs e)
        {
            var help = new Search(_productService.GetProducts(), "Productos");
            help.TopLevel = true;
            help.FormBorderStyle = FormBorderStyle.None;
            help.ShowDialog();
            if (help.Id != "")
            {
                tbIdProduct.Text = help.Id;
                tbProduct.Text = help.Fullname;
            }
        }

        private void bSearchMeasure_Click(object sender, EventArgs e)
        {
            var help = new Search(_unitMeasureService.GetUnitMeasures(), "Unidades de medida");
            help.TopLevel = true;
            help.FormBorderStyle = FormBorderStyle.None;
            help.ShowDialog();
            if (help.Id != "")
            {
                tbIdMeasure.Text = help.Id;
                tbMeasure.Text = help.Fullname;
            }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddProduct_Load(object sender, System.EventArgs e)
        {
            Text = "Añadir producto";
        }

        private void bAccept_Click(object sender, System.EventArgs e)
        {
            idProduct = Convert.ToInt32(tbIdProduct.Text);
            idMeasure = Convert.ToInt32(tbIdMeasure.Text);
            product = tbProduct.Text;
            measure = tbMeasure.Text;
            Close();
        }
    }
}