using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraccion;
using BE;
using MPP;

namespace BLL
{
    public class BLLUsuario : IGestor<BEUsuario>
    {
        public BLLUsuario() { oMPPUsuario = new MPPUsuario(); }

        MPPUsuario oMPPUsuario;

        public bool Borrar(BEUsuario obj)
        {
            return oMPPUsuario.Borrar(obj);
        }

        public bool Guardar(BEUsuario obj)
        {
            return oMPPUsuario.Guardar(obj);
        }

        public List<BEUsuario> ListarTodo()
        {
            return oMPPUsuario.ListarTodo();
        }

        public BEUsuario VerificarUsuario(string username, string password)
        {
            return oMPPUsuario.VerificarUsuario(username, password);
        }
    }
}
