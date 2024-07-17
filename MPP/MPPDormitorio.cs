using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Abstraccion;
using System.Xml.Linq;

namespace MPP
{
    public class MPPDormitorio : IGestor<BEDormitorio>
    {
        public bool Borrar(BEDormitorio obj)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BEDormitorio obj)
        {
            throw new NotImplementedException();
        }

        public BEDormitorio ListarMuebleCompleto()
        {
            try
            {
                XDocument docXml = XDocument.Load("Mueble.xml");

                var query = from Mueble in docXml.Descendants("Mueble")
                            where Mueble.Element("Juego").Value == "TRUE"
                            select Mueble;

                BEDormitorio oDormitorio = new BEDormitorio();
                foreach (XElement element in query)
                {
                    oDormitorio.Codigo = Convert.ToInt32(element.Attribute("Codigo").Value);
                    oDormitorio.Descripcion = Convert.ToString(element.Element("Descripcion").Value);
                    oDormitorio.Precio = Convert.ToDouble(element.Element("Precio").Value);
                    oDormitorio.Cantidad = Convert.ToInt32(element.Element("Cantidad").Value);
                    oDormitorio.Material = Convert.ToString(element.Element("Material").Value);
                    oDormitorio.Color = Convert.ToString(element.Element("Color").Value);
                }
                return oDormitorio;
            }
            catch (Exception ex) { throw ex; }
        }

        public BEDormitorio ListarMuebleIncompleto()
        {
            try
            {
                XDocument docXml = XDocument.Load("Mueble.xml");

                var query = from Mueble in docXml.Descendants("Mueble")
                            where Mueble.Element("Juego").Value == "FALSE"
                            select Mueble;

                BEDormitorio oDormitorio = new BEDormitorio();
                foreach (XElement element in query)
                {
                    oDormitorio.Codigo = Convert.ToInt32(element.Attribute("Codigo").Value);
                    oDormitorio.Descripcion = Convert.ToString(element.Element("Descripcion").Value);
                    oDormitorio.Precio = Convert.ToDouble(element.Element("Precio").Value);
                    oDormitorio.Cantidad = Convert.ToInt32(element.Element("Cantidad").Value);
                    oDormitorio.Material = Convert.ToString(element.Element("Material").Value);
                    oDormitorio.Color = Convert.ToString(element.Element("Color").Value);
                }
                return oDormitorio;
            }
            catch (Exception ex) { throw ex; }
        }

        public List<BEDormitorio> ListarTodo()
        {
            throw new NotImplementedException();
        }

        public double ObtenerDescuentoDormitorio()
        {
            XDocument docXml = XDocument.Load("Mueble.xml");

            BEDormitorio oBEDormitorio = new BEDormitorio();

            if(docXml.Descendants("Mueble").Elements("Juego").ToString() == "TRUE")
            {
                double descuento = (oBEDormitorio.Precio * 25) / 100;
                return descuento;
            }
            else
            {
                return 0;
            }

            
        }
    }
}
