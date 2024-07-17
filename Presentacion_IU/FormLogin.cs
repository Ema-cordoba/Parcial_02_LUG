using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;
using Security;

namespace Presentacion_IU
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            oBEUsuario = new BEUsuario();
            oBLLUsuario = new BLLUsuario();
        }

        BEUsuario oBEUsuario;
        BLLUsuario oBLLUsuario;
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (textBoxUsuario.Text != string.Empty && textBoxClave.Text != string.Empty) 
            {
                oBEUsuario = oBLLUsuario.VerificarUsuario(textBoxUsuario.Text, textBoxClave.Text);
                if (oBEUsuario != null) 
                {
                    MessageBox.Show("Ha iniciado sesion");
                    FormInicio formInicio = new FormInicio();
                    formInicio.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrecta");
                }
            }
        }
    }
}
