using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion_IU
{
    public partial class FormInicio : Form
    {
        public FormInicio()
        {
            InitializeComponent();
        }

        private void clToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormClientes formClientes = new FormClientes();
            formClientes.MdiParent = this;
            formClientes.Show();
        }

        private void mueblesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMuebles formMuebles = new FormMuebles();
            formMuebles.MdiParent = this;
            formMuebles.Show();
        }

        private void informesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInforme formInformes = new FormInforme();
            formInformes.MdiParent = this;
            formInformes.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
