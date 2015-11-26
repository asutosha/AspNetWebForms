using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Util.Criptografia
{
    public interface IControleCriptografia
    {
        string EncriptarParaSHA1(string valor);
    }
}
