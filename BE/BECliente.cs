using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraccion;
using BE;

namespace BE
{
    public class BECliente : Entidad
    {
        public string Nombre {  get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public BEUsuario Usiario { get; set; }
        public BEMueble Mueble;

        public BECliente(string nombre, string apellido, string dni)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.DNI = dni;
        }

        public BECliente() { }
        public override string ToString() 
        { 
            return Nombre + " " + Apellido + " " + DNI;
        }


    }
}
