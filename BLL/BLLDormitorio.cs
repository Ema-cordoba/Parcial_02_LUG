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
    public class BLLDormitorio : IGestor<BEDormitorio>
    {
        public BLLDormitorio() 
        {
            oMPPDormitorio = new MPPDormitorio();
            
        }

        
        MPPDormitorio oMPPDormitorio;

        public bool Borrar(BEDormitorio obj)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BEDormitorio obj)
        {
            throw new NotImplementedException();
        }

        public List<BEDormitorio> ListarTodo()
        {
            throw new NotImplementedException();
        }

        public BEDormitorio ListarMuebleCompleto()
        {
            return oMPPDormitorio.ListarMuebleCompleto();
        }

        public BEDormitorio ListarMuebleIncompleto()
        {
            return oMPPDormitorio.ListarMuebleIncompleto();
        }

        public double ObtenerDescuento()
        {
            return oMPPDormitorio.ObtenerDescuentoDormitorio();
        }
    }
}
