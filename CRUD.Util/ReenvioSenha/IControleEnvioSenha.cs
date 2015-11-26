using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Util.ReenvioSenha
{
    public interface IControleEnvioSenha
    {
        void EnvioSenha(string email, string msgBody);
    }
}
