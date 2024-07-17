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
    public partial class FormMuebles : Form
    {
        public FormMuebles()
        {
            InitializeComponent();
            oBEDormitorio = new BEDormitorio();
            oBEOficina = new BEOficina();
            oBLLDormitorio = new BLLDormitorio();
            oBLLOficina = new BLLOficina(); 
        }

        BEDormitorio oBEDormitorio;
        BEOficina oBEOficina;

        BLLDormitorio oBLLDormitorio;
        BLLOficina oBLLOficina;

        void CargarGrillaMueble()
        {
            this.dataGridViewMueble.DataSource = null;
            this.dataGridViewMueble.DataSource = oBLLDormitorio.ListarMuebleCompleto();
            this.dataGridViewMueble.DataSource = oBLLDormitorio.ListarMuebleIncompleto();
            this.dataGridViewMueble.DataSource = oBLLOficina.ListarMuebleColonial();
            this.dataGridViewMueble.DataSource = oBLLOficina.ListarMuebleModerno();
            this.dataGridViewMueble.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                oBEDormitorio.Descripcion = this.textBoxDescripcion.Text;
                oBEDormitorio.Precio =  Convert.ToDouble(this.textBoxPrecio.Text);
                oBEDormitorio.Cantidad = Convert.ToInt32(this.textBoxCantidad.Text);
                oBEDormitorio.Material = this.textBoxMaterial.Text;
                oBEDormitorio.Color = this.textBoxColor.Text;
                oBLLDormitorio.Guardar(oBEDormitorio);


                oBEOficina.Descripcion = this.textBoxDescripcion.Text;
                oBEOficina.Precio = Convert.ToDouble(this.textBoxPrecio.Text);
                oBEOficina.Cantidad = Convert.ToInt32(this.textBoxCantidad.Text);
                oBEOficina.Material = this.textBoxMaterial.Text;
                oBEOficina.Color = this.textBoxColor.Text;
                oBLLOficina.Guardar(oBEOficina);

            }
            catch (Exception ex) { throw ex; }
        }

        private void dataGridViewMueble_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                oBEDormitorio = (BEDormitorio)this.dataGridViewMueble.SelectedRows[0].DataBoundItem;
                this.textBoxDescripcion.Text = oBEDormitorio.Descripcion;
                this.textBoxPrecio.Text = oBEDormitorio.Precio.ToString();
                this.textBoxCantidad.Text = oBEDormitorio.Cantidad.ToString();
                this.textBoxMaterial.Text = oBEDormitorio.Material.ToString();
                this.textBoxColor.Text = oBEDormitorio.Color.ToString();
                oBEOficina = (BEOficina)this.dataGridViewMueble.SelectedRows[0].DataBoundItem;
                this.textBoxDescripcion.Text = oBEOficina.Descripcion;
                this.textBoxPrecio.Text = oBEOficina.Precio.ToString();
                this.textBoxCantidad.Text = oBEOficina.Cantidad.ToString();
                this.textBoxMaterial.Text = oBEOficina.Material.ToString();
                this.textBoxColor.Text = oBEOficina.Color.ToString();
            }
            catch (Exception) { }
        }

        private void FormMuebles_Load(object sender, EventArgs e)
        {
            CargarGrillaMueble();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                oBEDormitorio = (BEDormitorio)this.dataGridViewMueble.SelectedRows[0].DataBoundItem;
                DialogResult dialogo1 = MessageBox.Show("Desea eliminar el mueble?", "Info", MessageBoxButtons.YesNo);
                if(dialogo1 == DialogResult.Yes)
                {
                    if(oBLLDormitorio.Borrar(oBEDormitorio) == true)
                    {
                        MessageBox.Show("El mueble fue eliminado");
                    }
                }
            }
            catch (Exception ex) { throw ex; }   
        }
    }
}
