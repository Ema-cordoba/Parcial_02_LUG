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
using System.Text.RegularExpressions;

namespace Presentacion_IU
{
    public partial class FormClientes : Form
    {
        public FormClientes()
        {
            InitializeComponent();
            oBECliente = new BECliente();
            oBLLCliente = new BLLCliente();
        }

        BECliente oBECliente;
        BLLCliente oBLLCliente;

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                oBECliente.Nombre = this.textBoxNombre.Text;
                oBECliente.Apellido = this.textBoxApellido.Text;
                oBECliente.DNI = this.textBoxDNI.Text;

                if(oBECliente.DNI != this.textBoxDNI.Text)
                {
                    if(Regex.IsMatch(textBoxDNI.Text, "^([0-9]{8})$") == true)
                    {
                        if(oBLLCliente.ListarTodo().Exists(x=>x.DNI == textBoxDNI.Text) == false)
                        {
                            oBECliente.DNI = this.textBoxDNI.Text;
                        }
                        else
                        {
                            throw new Exception("El DNI ingresado ya existe");
                        }
                    }
                    else
                    {
                        throw new Exception("El DNI ingresado no es correcto");
                    }
                }
                if(oBLLCliente.Guardar(oBECliente,0) == true)
                {
                    MessageBox.Show("Cliente modificado");
                    CargarGrillaClientes();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        void CargarGrillaClientes()
        {
            this.dataGridViewClientes.DataSource = null;
            this.dataGridViewClientes.DataSource = oBLLCliente.ListarTodo();
            this.dataGridViewClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void FormClientes_Load(object sender, EventArgs e)
        {
            this.dataGridViewClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            CargarGrillaClientes();
        }

        private void dataGridViewClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                oBECliente = (BECliente)this.dataGridViewClientes.SelectedRows[0].DataBoundItem;
                this.textBoxNombre.Text = oBECliente.Nombre;
                this.textBoxApellido.Text = oBECliente.Apellido;
                this.textBoxDNI.Text = oBECliente.DNI;
               
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                oBECliente = (BECliente)this.dataGridViewClientes.SelectedRows[0].DataBoundItem;
                DialogResult dialogo = MessageBox.Show("Desea eliminar el usuario?", "Info",MessageBoxButtons.YesNo);

                if(dialogo == DialogResult.Yes)
                {
                    if(oBLLCliente.Borrar(oBECliente)== true)
                    {
                        MessageBox.Show("Cliente eliminado correctamente");
                    }
                }
            }
            catch(Exception ex) { throw ex; }
        }
    }
}
