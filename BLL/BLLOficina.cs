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
    public class BLLOficina : IGestor<BEOficina>
    {

        public BLLOficina() { oMPPOficina = new MPPOficina(); }

        MPPOficina oMPPOficina;

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
            return oMPPOficina.ListarMuebleModerno();
        }

        public BEOficina ListarMuebleColonial()
        {
            return oMPPOficina.ListarMuebleColonial();
        }

        public double ObtenerDescuento()
        {
            return oMPPOficina.ObtenerDescuentoOficina();
        }
    }
}
