using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.DAL.DataSource
{
    public class Conexao
    {
        #region Atributos

        protected SqlConnection Con;
        protected SqlCommand Cmd;
        protected SqlDataReader Dr;
        protected SqlTransaction Tr;

        #endregion

        #region Abrindo Conexao

        protected void OpenConnection()
        {
            try
            {
                Con = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
                Con.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao abrir conexao com banco de dados. \n" + ex.Message);
            }

        }

        #endregion

        #region Fechando Conexao

        protected void CloseConnection()
        {
            try
            {
                Con.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao fechar conexao com banco de dados. \n" + ex.Message);
            }

        }

        #endregion
    }
}
