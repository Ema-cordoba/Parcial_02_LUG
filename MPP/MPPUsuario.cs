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
    public class MPPUsuario : IGestor<BEUsuario>
    {
        public bool Borrar(BEUsuario obj)
        {
            try
            {
                XDocument docXml = XDocument.Load("Usiario.xml");

                var query = from Usiario in docXml.Descendants("Usuario")
                            where Usiario.Element("Username").Value == obj.Username.Trim()
                            select Usiario;
                query.Remove();
                docXml.Save("Usuario.xml");
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public bool Guardar(BEUsuario obj)
        {
            try
            {
                XDocument docXml = XDocument.Load("Usuario.xml");
                docXml.Element("Usuarios").Add(new XElement("Usuario",
                new XElement("Username", obj.Username.Trim()),
                new XElement("Password", obj.Password.Trim())
                ));
                docXml.Save("Usuario.XML");
                return true;
            }
            catch (Exception ex) { throw ex; }
        }


        public bool ModifcarClave(BEUsuario objBEUsuario)
        {
            try
            {
                XDocument docXml = XDocument.Load("Usuario.xml");
                var query = from Usuario in docXml.Descendants("Usuario")
                            where Usuario.Element("Username").Value == objBEUsuario.Username.Trim()
                            select Usuario;

                foreach (XElement Element in query)
                {
                    Element.Element("Username").Value = objBEUsuario.Username.Trim();
                    Element.Element("Password").Value = objBEUsuario.Password.Trim();
                }
                docXml.Save("Usuario.XML");
                return true;
            }
            catch (Exception ex) { throw ex; }
        }


        public BEUsuario VerificarUsuario(string username, string password)
        {
            try
            {
                XDocument docXml = XDocument.Load("Usuario.xml");

                var query = from Usuario in docXml.Descendants("Usuario")
                            where Usuario.Element("Username").Value == username.Trim()
                            && Usuario.Element("Password").Value == password.Trim()
                            select Usuario;

                if (query.Any() == true)
                {
                    BEUsuario objBEUsuario = new BEUsuario();
                    foreach (XElement xElement in query)
                    {
                        objBEUsuario.Username = xElement.Element("Username").Value;
                        objBEUsuario.Password = xElement.Element("Password").Value;
                    }
                    return objBEUsuario;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public List<BEUsuario> ListarTodo()
        {
            try
            {
                var query = from Usuario in XElement.Load("Usuario.xml").Elements("Usuario")
                            select new BEUsuario
                            {
                                Username = Convert.ToString(Usuario.Element("Username").Value),
                                Password = Convert.ToString(Usuario.Element("Password").Value)
                            };
                List<BEUsuario> ListaUsuarios = query.ToList<BEUsuario>();
                return ListaUsuarios;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
