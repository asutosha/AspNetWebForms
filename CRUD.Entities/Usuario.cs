using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Entities
{
    public class Usuario
    {
        #region Atributos

        private int idUsuario;
        private string nome;
        private string email;
        private string login;
        private string senha;
        private DateTime dataCadastro;

        #endregion

        #region Construtores

        public Usuario()
        {

        }

        public Usuario(int idUsuario, string nome, string email, string login, string senha, DateTime dataCadastro)
        {
            this.IdUsuario = idUsuario;
            this.Nome = nome;
            this.Email = email;
            this.Login = login;
            this.Senha = senha;
            this.DataCadastro = dataCadastro;
        }

        #endregion

        #region Propriedades

        public int IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }

        public DateTime DataCadastro
        {
            get { return dataCadastro; }
            set { dataCadastro = value; }
        }

        #endregion
    }
}
