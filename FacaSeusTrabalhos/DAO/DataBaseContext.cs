using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Data.Linq;
using FacaSeusTrabalhos.Model;

namespace FacaSeusTrabalhos.DAO
{
    public class DataBaseContext : DataContext
    {
        public static string ConnectionString = "Data Source=isostore:/Infoeste.sdf";

        private Table<Trabalhos> _trabalhos;

        public Table<Trabalhos> Trabalhos
        {
            get
            {
                if (_trabalhos == null)
                    _trabalhos = GetTable<Trabalhos>();

                return _trabalhos;
            }
        }

        public DataBaseContext(string connectionString)
            : base(connectionString)
        {
            if (!this.DatabaseExists())
                this.CreateDatabase();
        }
    }
}
