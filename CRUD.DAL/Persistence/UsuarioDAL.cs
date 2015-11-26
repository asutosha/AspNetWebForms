using CRUD.DAL.DataSource;
using CRUD.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.DAL.Persistence
{
    public class UsuarioDAL : Conexao
    {
        public void Insert(Usuario u)
        {
            try
            {
                OpenConnection();

                string query = "insert into Usuario (Nome, Email, Login, Senha, DataCadastro) " +
                               "values (@v1, @v2, @v3, @v4, GETDATE())";

                Cmd = new SqlCommand(query, Con);
                Cmd.Parameters.AddWithValue("@v1", u.Nome);
                Cmd.Parameters.AddWithValue("@v2", u.Email);
                Cmd.Parameters.AddWithValue("@v3", u.Login);
                Cmd.Parameters.AddWithValue("@v4", u.Senha);

                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao inserir usuário na base de dados. \n" + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool HasLogin(string Login)
        {
            try
            {
                OpenConnection();

                string query = "select count(1) from Usuario where Login = @v1";

                Cmd = new SqlCommand(query, Con);
                Cmd.Parameters.AddWithValue("@v1", Login);

                int count = Convert.ToInt32(Cmd.ExecuteScalar());

                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao validar login. \n" + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool HasEmail(string Email)
        {
            try
            {
                OpenConnection();

                string query = "select count(1) from Usuario where Email = @v1";

                Cmd = new SqlCommand(query, Con);
                Cmd.Parameters.AddWithValue("@v1", Email);

                int count = Convert.ToInt32(Cmd.ExecuteScalar());

                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao validar email. \n" + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public Usuario Authenticate(string Login, string Senha)
        {
            try
            {
                OpenConnection();

                string query = "select * from Usuario where Login = @v1 and Senha = @v2";

                Cmd = new SqlCommand(query, Con);
                Cmd.Parameters.AddWithValue("@v1", Login);
                Cmd.Parameters.AddWithValue("@v2", Senha);

                Dr = Cmd.ExecuteReader();

                if (Dr.Read())
                {
                    Usuario u = new Usuario();
                    u.IdUsuario = Convert.ToInt32(Dr["IdUsuario"]);
                    u.Nome = Convert.ToString(Dr["Nome"]);
                    u.Email = Convert.ToString(Dr["Email"]);
                    u.Login = Convert.ToString(Dr["Login"]);
                    u.Senha = Convert.ToString(Dr["Senha"]);
                    u.DataCadastro = Convert.ToDateTime(Dr["DataCadastro"]);

                    return u;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na autenticação do usuário. \n" + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void UpdatePassword(string Senha, string Email)
        {
            try
            {
                OpenConnection();

                string query = "update Usuario set Senha = @v1 where Email = @v2";

                Cmd = new SqlCommand(query, Con);
                Cmd.Parameters.AddWithValue("@v1", Senha);
                Cmd.Parameters.AddWithValue("@v2", Email);

                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar senha. \n" + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void UpdatePassword(string Senha, int IdUsuario)
        {
            try
            {
                OpenConnection();

                string query = "update Usuario set Senha = @v1 where IdUsuario = @v2";

                Cmd = new SqlCommand(query, Con);
                Cmd.Parameters.AddWithValue("@v1", Senha);
                Cmd.Parameters.AddWithValue("@v2", IdUsuario);

                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar senha. \n" + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool ValidateOldPassword(string Senha, int IdUsuario)
        {
            try
            {
                OpenConnection();

                string query = "select count(1) from Usuario where Senha = @v1 and IdUsuario = @v2";

                Cmd = new SqlCommand(query, Con);
                Cmd.Parameters.AddWithValue("@v1", Senha);
                Cmd.Parameters.AddWithValue("@v2", IdUsuario);

                int count = Convert.ToInt32(Cmd.ExecuteScalar());

                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao validar senha antiga. \n" + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
