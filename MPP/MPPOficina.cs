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
    public class MPPOficina : IGestor<BEOficina>
    {
        public bool Borrar(BEOficina obj)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BEOficina obj)
        {
            throw new NotImplementedException();
        }

        public List<BEOficina> ListarTodo()
        {
            throw new NotImplementedException();
        }

        public BEOficina ListarMuebleModerno()
        {
            try
            {
                XDocument docXml = XDocument.Load("Mueble.xml");

                var query = from Mueble in docXml.Descendants("Mueble")
                            where Mueble.Element("Estilo").Value == "Moderno"
                            select Mueble;

                BEOficina oDormitorio = new BEOficina();
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


        public BEOficina ListarMuebleColonial()
        {
            try
            {
                XDocument docXml = XDocument.Load("Mueble.xml");

                var query = from Mueble in docXml.Descendants("Mueble")
                            where Mueble.Element("Estilo").Value == "Colonial"
                            select Mueble;

                BEOficina oDormitorio = new BEOficina();
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

        public double ObtenerDescuentoOficina()
        {
            XDocument docXml = XDocument.Load("Mueble.xml");

            BEOficina oBEOficina = new BEOficina();

            if (docXml.Descendants("Mueble").Elements("Estilo").ToString() == "Moderno")
            {
                double descuento = (oBEOficina.Precio * 10) / 100;
                return descuento;
            }
            else
            {
                return 0;
            }


        }

    }
}
