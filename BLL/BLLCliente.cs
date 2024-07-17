using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Abstraccion;
using BE;
using MPP;

namespace BLL
{
    public class BLLCliente : IGestor<BECliente>
    {
        public BLLCliente() { oMPPCliente = new MPPCliente(); }

        MPPCliente oMPPCliente;

        public bool Borrar(BECliente obj)
        {
           return oMPPCliente.Borrar(obj);
        }

        public bool Guardar(BECliente obj, int codigo)
        {
            return oMPPCliente.Guardar(obj, codigo);
        }

        public bool Guardar(BECliente obj)
        {
            return oMPPCliente.Guardar(obj);
        }

        public List<BECliente> ListarTodo()
        {
            return oMPPCliente.ListarTodo();
        }

        public bool GuardarCliente_Mueble(BECliente oCliente,BEMueble oMueble)
        {
            return oMPPCliente.GuardarCliente_Mueble(oCliente, oMueble);
        }

    }
}
