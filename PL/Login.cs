using System;
using System.Windows.Forms;
using BLL;
using ML;

namespace PL
{
    public partial class Login : Form
    {
        private readonly PersonService _personService = new PersonService();
        private Person _person;

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            Text = "Iniciar Sesión";
        }

        private void bLogin_Click(object sender, EventArgs e)
        {
            if (tbUsername.Text.Equals("") || tbPassword.Text.Equals(""))
            {
                MessageBox.Show("Por favor, ingresa un usuario y una contraseña.", "Error de inicio de sesión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _person = _personService.GetByUsername(tbUsername.Text);
                if (tbPassword.Text.Equals(_person.CONTRASENA))
                {
                    _person = _personService.GetPerson(tbUsername.Text, tbPassword.Text);
                    var home = new Home(_person.NOMBRES, this);
                    Hide();
                    home.Show();

                    tbUsername.Text = "";
                    tbPassword.Text = "";
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos, por favor corregir.",
                        "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}