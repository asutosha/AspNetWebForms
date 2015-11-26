using CRUD.DAL.DataSource;
using CRUD.Entities;
using CRUD.Entities.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.DAL.Persistence
{
    public class ClienteEnderecoDAL : Conexao
    {
        public List<ClienteEnderecoDTO> FindAll()
        {
            try
            {
                OpenConnection();

                ClienteDAL d = new ClienteDAL();

                List<Cliente> dados = d.FindAll();

                var lista = new List<ClienteEnderecoDTO>();

                foreach (var p in dados)
                {
                    var dto = new ClienteEnderecoDTO();

                    dto.IdCliente = p.IdCliente;
                    dto.Nome = p.Nome;
                    dto.DataCadastro = p.DataCadastro;
                    dto.Cidade = p.Endereco.Cidade;
                    dto.Estado = p.Endereco.Estado.ToString();

                    lista.Add(dto);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar Clientes e Endereços. \n" + ex.Message);
            }
            finally
            {
                CloseConnection();
            }

        }
    }
}
