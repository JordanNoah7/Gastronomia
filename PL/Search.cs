using System.Data;
using System.Windows.Forms;

namespace PL
{
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }

        public Search(DataTable dt, string title)
        {
            InitializeComponent();
            dgvDatos.DataSource = dt;
        }
    }
}