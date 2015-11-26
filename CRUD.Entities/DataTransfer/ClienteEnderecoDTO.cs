using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Entities.DataTransfer
{
    public class ClienteEnderecoDTO
    {
        #region Atributos

        private int idCliente;
        private string nome;
        private DateTime dataCadastro;
        private string cidade;
        private string estado;

        #endregion

        #region Construtores

        public ClienteEnderecoDTO()
        {

        }

        public ClienteEnderecoDTO(int idCliente, string nome, DateTime dataCadastro, string cidade, string estado)
        {
            this.IdCliente = idCliente;
            this.Nome = nome;
            this.DataCadastro = dataCadastro;
            this.Cidade = cidade;
            this.Estado = estado;
        }

        #endregion

        #region Properties

        public int IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public DateTime DataCadastro
        {
            get { return dataCadastro; }
            set { dataCadastro = value; }
        }

        public string Cidade
        {
            get { return cidade; }
            set { cidade = value; }
        }

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        #endregion
    }
}
