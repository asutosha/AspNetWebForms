using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Entities
{
    public class Cliente
    {
        #region Atributos

        private int idCliente;
        private string nome;
        private string rg;
        private string cpf;
        private DateTime dataCadastro;

        #endregion

        #region Relacionamentos

        private Endereco endereco;

        #endregion

        #region Construtores

        //construtor default
        public Cliente()
        {

        }

        //sobrecarga de metodo 1
        public Cliente(int idCliente, string nome, string rg, string cpf, DateTime dataCadastro)
        {
            this.IdCliente = idCliente;
            this.Nome = nome;
            this.Rg = rg;
            this.Cpf = cpf;
            this.DataCadastro = dataCadastro;
        }

        //sobrecarga de metodo 2
        public Cliente(int idCliente, string nome, string rg, string cpf, DateTime dataCadastro, Endereco endereco)
            : this(idCliente, nome, rg, cpf, dataCadastro)
        {
            this.Endereco = endereco;
        }

        #endregion

        #region Propriedades

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

        public string Rg
        {
            get { return rg; }
            set { rg = value; }
        }

        public string Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }

        public Endereco Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }

        public DateTime DataCadastro
        {
            get { return dataCadastro; }
            set { dataCadastro = value; }
        }

        #endregion
    }
}
