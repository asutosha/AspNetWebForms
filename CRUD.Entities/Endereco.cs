using CRUD.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Entities
{
    public class Endereco
    {
        #region Atributos

        private int idEndereco;
        private string descricao;
        private string bairro;
        private string cidade;
        private Estado estado;
        private string cep;

        #endregion

        #region Construtores

        public Endereco()
        {

        }

        public Endereco(int idEndereco, string descricao, string bairro, string cidade, Estado estado, string cep)
        {
            this.IdEndereco = idEndereco;
            this.Descricao = descricao;
            this.Bairro = bairro;
            this.Cidade = cidade;
            this.Estado = estado;
            this.Cep = cep;
        }

        #endregion

        #region Propriedades

        public int IdEndereco
        {
            get { return idEndereco; }
            set { idEndereco = value; }
        }

        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        public string Bairro
        {
            get { return bairro; }
            set { bairro = value; }
        }

        public string Cidade
        {
            get { return cidade; }
            set { cidade = value; }
        }

        public Estado Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public string Cep
        {
            get { return cep; }
            set { cep = value; }
        }

        #endregion
    }
}
