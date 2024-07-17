using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public abstract class BEMueble : Entidad
    {
        public string Descripcion {  get; set; }
        public double Precio {  get; set; }
        public int Cantidad { get; set; }
        public string Material {  get; set; }
        public string Color { get; set; }
    }
}
