using CRUD.DAL.DataSource;
using CRUD.Entities;
using CRUD.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.DAL.Persistence
{
    public class ClienteDAL : Conexao
    {
        /// <summary>
        /// Metodo utilizado para cadastrar cliente na base de dados
        /// </summary>
        /// <param name="c">Entidade Cliente</param>
        public void Inert(Cliente c)
        {
            try
            {
                OpenConnection();

                Tr = Con.BeginTransaction();

                string queryCliente = "Insert into Cliente (Nome, Rg, Cpf, DataCadastro) " +
                                      "values (@v1, @v2, @v3, GetDate()) " +
                                      "select scope_identity()";

                Cmd = new SqlCommand(queryCliente, Con, Tr);
                Cmd.Parameters.AddWithValue("@v1", c.Nome);
                Cmd.Parameters.AddWithValue("@v2", c.Rg);
                Cmd.Parameters.AddWithValue("@v3", c.Cpf);

                c.IdCliente = Convert.ToInt32(Cmd.ExecuteScalar());

                string queryEndereco = "Insert into Endereco (Descricao, Bairro, Cidade, Estado, Cep, IdCliente) " +
                                       "values (@v4, @v5, @v6, @v7, @v8, @v9)";

                Cmd = new SqlCommand(queryEndereco, Con, Tr);
                Cmd.Parameters.AddWithValue("@v4", c.Endereco.Descricao);
                Cmd.Parameters.AddWithValue("@v5", c.Endereco.Bairro);
                Cmd.Parameters.AddWithValue("@v6", c.Endereco.Cidade);
                Cmd.Parameters.AddWithValue("@v7", c.Endereco.Estado);
                Cmd.Parameters.AddWithValue("@v8", c.Endereco.Cep);
                Cmd.Parameters.AddWithValue("@v9", c.IdCliente);

                Cmd.ExecuteNonQuery();

                Tr.Commit();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar cliente na base de dados. \n" + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        /// <summary>
        /// Metodo utilizado para validar existencia de um CPF cadastrado na base de dados
        /// </summary>
        /// <param name="Cpf">String Cpf</param>
        public int FindByCpf(string Cpf)
        {
            try
            {
                OpenConnection();

                Cmd = new SqlCommand("select count(1) from Cliente where Cpf = @v1", Con);
                Cmd.Parameters.AddWithValue("@v1", Cpf);

                return Convert.ToInt32(Cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao filtrar cliente por CPF. \n" + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        /// <summary>
        /// Metodo utilizado para listar todos os clientes no load da pagina
        /// </summary>
        /// <returns>Lista de Clientes</returns>
        public List<Cliente> FindAll()
        {
            try
            {
                OpenConnection();

                string query = "select * from vwClientes";

                Cmd = new SqlCommand(query, Con);

                Dr = Cmd.ExecuteReader();

                List<Cliente> listaClientes = new List<Cliente>();

                while (Dr.Read())
                {
                    Cliente c = new Cliente();
                    c.Endereco = new Endereco();

                    c.IdCliente = Convert.ToInt32(Dr["IdCliente"]);
                    c.Nome = Convert.ToString(Dr["Nome"]);
                    c.Rg = Convert.ToString(Dr["Rg"]);
                    c.Cpf = Convert.ToString(Dr["Cpf"]);
                    c.DataCadastro = Convert.ToDateTime(Dr["DataCadastro"]);

                    c.Endereco.IdEndereco = Convert.ToInt32(Dr["IdEndereco"]);
                    c.Endereco.Descricao = Convert.ToString(Dr["Descricao"]);
                    c.Endereco.Bairro = Convert.ToString(Dr["Bairro"]);
                    c.Endereco.Cidade = Convert.ToString(Dr["Cidade"]);
                    c.Endereco.Estado = (Estado)Enum.Parse(typeof(Estado), Convert.ToString((Dr["Estado"])));
                    c.Endereco.Cep = Convert.ToString(Dr["Cep"]);

                    listaClientes.Add(c);
                }

                return listaClientes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        /// <summary>
        /// Overload 1 - Metodo utilizado para listar todos os clientes utilizando os campos de filtro
        /// </summary>
        /// <returns>Lista de Clientes</returns>
        public List<Cliente> FindAll(string Bairro, string Cidade)
        {
            try
            {
                OpenConnection();

                Cmd = new SqlCommand();

                string query = "select * from vwClientes where 1=1 ";

                if (!String.IsNullOrEmpty(Bairro))
                {
                    query += "and Bairro like '%' + @v1 + '%' ";
                    Cmd.Parameters.AddWithValue("@v1", Bairro);
                }

                if (!String.IsNullOrEmpty(Cidade))
                {
                    query += "and Cidade like '%' + @v2 + '%' ";
                    Cmd.Parameters.AddWithValue("@v2", Cidade);
                }

                Cmd.CommandText = query;
                Cmd.Connection = Con;

                Dr = Cmd.ExecuteReader();

                List<Cliente> listaClientes = new List<Cliente>();

                while (Dr.Read())
                {
                    Cliente c = new Cliente();
                    c.Endereco = new Endereco();

                    c.IdCliente = Convert.ToInt32(Dr["IdCliente"]);
                    c.Nome = Convert.ToString(Dr["Nome"]);
                    c.Rg = Convert.ToString(Dr["Rg"]);
                    c.Cpf = Convert.ToString(Dr["Cpf"]);
                    c.DataCadastro = Convert.ToDateTime(Dr["DataCadastro"]);

                    c.Endereco.IdEndereco = Convert.ToInt32(Dr["IdEndereco"]);
                    c.Endereco.Descricao = Convert.ToString(Dr["Descricao"]);
                    c.Endereco.Bairro = Convert.ToString(Dr["Bairro"]);
                    c.Endereco.Cidade = Convert.ToString(Dr["Cidade"]);
                    c.Endereco.Estado = (Estado)Enum.Parse(typeof(Estado), Convert.ToString((Dr["Estado"])));
                    c.Endereco.Cep = Convert.ToString(Dr["Cep"]);

                    listaClientes.Add(c);
                }

                return listaClientes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        /// <summary>
        /// Overload 2 - Metodo utilizado para listar todos os clientes utilizando os campos de filtro
        /// </summary>
        /// <returns>Lista de Clientes</returns>
        public List<Cliente> FindAll(string Bairro, string Cidade, int Estado)
        {
            try
            {
                OpenConnection();

                Cmd = new SqlCommand();

                string query = "select * from vwClientes where 1=1 ";

                if (!String.IsNullOrEmpty(Bairro))
                {
                    query += "and Bairro like '%' + @v1 + '%' ";
                    Cmd.Parameters.AddWithValue("@v1", Bairro);
                }

                if (!String.IsNullOrEmpty(Cidade))
                {
                    query += "and Cidade like '%' + @v2 + '%' ";
                    Cmd.Parameters.AddWithValue("@v2", Cidade);
                }

                if (!String.IsNullOrEmpty(Convert.ToString(Estado)))
                {
                    query += "and Estado = @v3";
                    Cmd.Parameters.AddWithValue("@v3", Estado);
                }

                Cmd.CommandText = query;
                Cmd.Connection = Con;

                Dr = Cmd.ExecuteReader();

                List<Cliente> listaClientes = new List<Cliente>();

                while (Dr.Read())
                {
                    Cliente c = new Cliente();
                    c.Endereco = new Endereco();

                    c.IdCliente = Convert.ToInt32(Dr["IdCliente"]);
                    c.Nome = Convert.ToString(Dr["Nome"]);
                    c.Rg = Convert.ToString(Dr["Rg"]);
                    c.Cpf = Convert.ToString(Dr["Cpf"]);
                    c.DataCadastro = Convert.ToDateTime(Dr["DataCadastro"]);

                    c.Endereco.IdEndereco = Convert.ToInt32(Dr["IdEndereco"]);
                    c.Endereco.Descricao = Convert.ToString(Dr["Descricao"]);
                    c.Endereco.Bairro = Convert.ToString(Dr["Bairro"]);
                    c.Endereco.Cidade = Convert.ToString(Dr["Cidade"]);
                    c.Endereco.Estado = (Estado)Enum.Parse(typeof(Estado), Convert.ToString((Dr["Estado"])));
                    c.Endereco.Cep = Convert.ToString(Dr["Cep"]);

                    listaClientes.Add(c);
                }

                return listaClientes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        /// <summary>
        /// Metodo para listar cliente atraves do Id
        /// </summary>
        /// <param name="Id">Retorna um cliente com base em seu Id</param>
        /// <returns>Entidade Cliente</returns>
        public Cliente FindById(int Id)
        {
            try
            {
                OpenConnection();

                Cmd = new SqlCommand("select * from vwClientes where IdCliente = @v1", Con);
                Cmd.Parameters.AddWithValue("@v1", Id);
                Dr = Cmd.ExecuteReader();

                if (Dr.Read())
                {
                    Cliente c = new Cliente();
                    c.Endereco = new Endereco();

                    //Dados do Cliente
                    c.IdCliente = Convert.ToInt32(Dr["IdCliente"]);
                    c.Nome = Convert.ToString(Dr["Nome"]);
                    c.Rg = Convert.ToString(Dr["Rg"]);
                    c.Cpf = Convert.ToString(Dr["Cpf"]);
                    c.DataCadastro = Convert.ToDateTime(Dr["DataCadastro"]);

                    //Endereco Cliente
                    c.Endereco.IdEndereco = Convert.ToInt32(Dr["IdEndereco"]);
                    c.Endereco.Descricao = Convert.ToString(Dr["Descricao"]);
                    c.Endereco.Bairro = Convert.ToString(Dr["Bairro"]);
                    c.Endereco.Cidade = Convert.ToString(Dr["Cidade"]);
                    c.Endereco.Estado = (Estado)Enum.Parse(typeof(Estado), Convert.ToString((Dr["Estado"])));
                    c.Endereco.Cep = Convert.ToString(Dr["Cep"]);

                    return c;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar cliente por Id. \n" + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        /// <summary>
        /// Metodo para atualizar dados de clientes na base de dados
        /// </summary>
        /// <param name="c">Entidade Cliente</param>
        public void Update(Cliente c)
        {
            try
            {
                OpenConnection();

                Tr = Con.BeginTransaction();

                string queryCliente = "Update Cliente " +
                                      "set " +
                                            "Nome = @Nome, " +
                                            "Rg   = @Rg, " +
                                            "Cpf  = @Cpf " +
                                      "where " +
                                            "IdCliente = @IdCliente";

                Cmd = new SqlCommand(queryCliente, Con, Tr);
                Cmd.Parameters.AddWithValue("@Nome", c.Nome);
                Cmd.Parameters.AddWithValue("@Rg", c.Rg);
                Cmd.Parameters.AddWithValue("@Cpf", c.Cpf);
                Cmd.Parameters.AddWithValue("@IdCliente", c.IdCliente);
                Cmd.ExecuteNonQuery();

                string queryEndereco = "Update Endereco " +
                                       "set " +
                                            "Descricao = @Descricao, " +
                                            "Bairro    = @Bairro, " +
                                            "Cidade    = @Cidade, " +
                                            "Estado    = @Estado, " +
                                            "Cep       = @Cep " +
                                       "where " +
                                            "IdCliente = @IdCliente";

                Cmd = new SqlCommand(queryEndereco, Con, Tr);
                Cmd.Parameters.AddWithValue("@Descricao", c.Endereco.Descricao);
                Cmd.Parameters.AddWithValue("@Bairro", c.Endereco.Bairro);
                Cmd.Parameters.AddWithValue("@Cidade", c.Endereco.Cidade);
                Cmd.Parameters.AddWithValue("@Estado", c.Endereco.Estado);
                Cmd.Parameters.AddWithValue("@Cep", c.Endereco.Cep);
                Cmd.Parameters.AddWithValue("@IdCliente", c.IdCliente);
                Cmd.ExecuteNonQuery();

                Tr.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar cliente. \n" + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        /// <summary>
        /// Metodo utilizado para excluir um cliente na base de dados e seu respectivo endereco
        /// </summary>
        /// <param name="Id">Int Id (Código da entidade Cliente)</param>
        public void Delete(int Id)
        {
            try
            {
                OpenConnection();

                Tr = Con.BeginTransaction();

                string queryEndereco = "delete from Endereco where IdCliente = @Id";

                Cmd = new SqlCommand(queryEndereco, Con, Tr);
                Cmd.Parameters.AddWithValue("@Id", Id);
                Cmd.ExecuteNonQuery();

                string queryCliente = "delete from Cliente where IdCliente = @Id";

                Cmd = new SqlCommand(queryCliente, Con, Tr);
                Cmd.Parameters.AddWithValue("@Id", Id);
                Cmd.ExecuteNonQuery();

                Tr.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir cliente. \n" + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
