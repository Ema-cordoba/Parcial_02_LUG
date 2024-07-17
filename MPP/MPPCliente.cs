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
    public class MPPCliente : IGestor<BECliente>
    {
        public bool Borrar(BECliente obj)
        {
            try
            {
                XDocument docXml = XDocument.Load("Cliente.xml");
                var query = from Cliente in docXml.Descendants("Cliente")
                            where Cliente.Attribute("Codigo").Value == obj.Codigo.ToString()
                            select Cliente;
                query.Remove();
                docXml.Save("Cliente.xml");
                return true;
            }
            catch(Exception ex) { throw ex; }
        }

        public bool Guardar(BECliente obj, int codigo)
        {
            try
            {
                XDocument docXml = XDocument.Load("Cliente.xml");
                if (obj.Codigo == 0) 
                {
                    docXml.Element("Clientes").Add(new XElement("Cliente",
                        new XAttribute("Codigo",codigo),
                        new XElement("Nombre", obj.Nombre.Trim()),
                        new XElement("Apellido",obj.Apellido.Trim()),
                        new XElement("DNI",obj.DNI.Trim()),
                        new XElement("Mueble", obj.Mueble.Descripcion.Trim())
                        ));

                    docXml.Save("Cliente.xml");
                    return true;
                }
                else 
                { 
                    var query = from Cliente in docXml.Descendants("Cliente")
                                where Cliente.Attribute("Codigo").Value == obj.Codigo.ToString()
                                select Cliente;

                    foreach(XElement e in query)
                    {
                        e.Element("Nombre").Value = obj.Nombre.Trim();
                        e.Element("Apellido").Value = obj.Apellido.Trim();
                        e.Element("DNI").Value = obj.DNI.Trim();
                    }
                    docXml.Save("Cliente.xml");
                    return true;

                }
            }
            catch(Exception ex) { throw ex; }
        }

        public bool GuardarCliente_Mueble(BECliente oCliente, BEMueble oMueble)
        {
            try
            {
                XDocument docXml = XDocument.Load("Cliente_Mueble.xml");

                docXml.Element("Clientes_Muebles").Add("Cliente_Mueble",
                    new XElement("CodCliente", Convert.ToString(oCliente)),
                    new XElement("CodMueble", Convert.ToString(oMueble))
                    );
            
            
                docXml.Save("Jugador_Mueble.xml");
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public bool Guardar(BECliente obj)
        {
            throw new NotImplementedException();
        }

        public List<BECliente> ListarTodo()
        {
            try
            {
                var query = from Cliente in XElement.Load("Cliente.xml").Elements("Cliente")
                            select new BECliente
                            {
                                Codigo = Convert.ToInt32(Cliente.Attribute("Codigo").Value),
                                Nombre = Convert.ToString(Cliente.Element("Nombre").Value),
                                Apellido = Convert.ToString(Cliente.Element("Apellido").Value),
                                DNI = Convert.ToString(Cliente.Element("DNI").Value)
                            };
                List<BECliente> ListaClientes = query.ToList<BECliente>();
                return ListaClientes;
            }
            catch(Exception ex) { throw ex; }
        }
    }
}
