using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacaSeusTrabalhos.DAO;
using System.Data.Linq.Mapping;

namespace FacaSeusTrabalhos.Model
{
     

    [Table(Name = "Trabalhos")]
    public class Trabalhos
    {
        private int _id;

        [Column(Name = "Id", IsPrimaryKey = true, IsDbGenerated = true, CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _descricao;

        [Column(Name = "Descricao", CanBeNull = false)]
        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }

        private string _data;

        [Column(Name = "DataEntrega", CanBeNull = false)]
        public string DataEntrega
        {
            get { return _data; }
            set { _data = value; }
        }


        private bool _realizada;

        [Column(Name = "Realizada", CanBeNull = false)]
        public bool Realizada
        {
            get { return _realizada; }
            set { _realizada = value; }
        }


        public IEnumerable<Trabalhos> ObtemTrabalhos()
        {
            DAOTrabalhos daoTrabalhos = new DAOTrabalhos();
            return daoTrabalhos.ObtemTrabalhos();
        }

        public bool Gravar()
        {
            DAOTrabalhos daoTrabalhos = new DAOTrabalhos();
            return daoTrabalhos.Gravar(this);
        }

        public bool Excluir()
        {
            DAOTrabalhos daoTrabalhos = new DAOTrabalhos();
            return daoTrabalhos.Excluir(this);
        }

        public bool Realizado()
        {
            DAOTrabalhos daoTrabalhos = new DAOTrabalhos();
            return daoTrabalhos.Realizado(this);
        }
    }
}