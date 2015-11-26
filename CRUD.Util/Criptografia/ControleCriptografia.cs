using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Util.Criptografia
{
    public class ControleCriptografia : IControleCriptografia
    {
        public string EncriptarParaSHA1(string valor)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();

            byte[] hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(valor));

            return BitConverter.ToString(hash).Replace("-", string.Empty);
        }
    }
}
