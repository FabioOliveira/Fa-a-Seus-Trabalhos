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
using System.Linq;
using System.Collections.Generic;
using FacaSeusTrabalhos.Model;

namespace FacaSeusTrabalhos.DAO
{
    public class DAOTrabalhos
    {
        public IEnumerable<Trabalhos> ObtemTrabalhos()
        {
            List<Trabalhos> dados = new List<Trabalhos>();
            using (DataBaseContext db = new DataBaseContext(DataBaseContext.ConnectionString))
            {
                dados = (from trabalhos in db.Trabalhos orderby trabalhos.Descricao select trabalhos).ToList();
            }
            return dados;
        }

        public bool Gravar(Trabalhos novoTrabalho)
        {
            try
            {
                using (DataBaseContext db = new DataBaseContext(DataBaseContext.ConnectionString))
                {
                    db.Trabalhos.InsertOnSubmit(novoTrabalho);
                    db.SubmitChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Excluir(Trabalhos trabalho)
        {
            try
            {
                using (DataBaseContext db = new DataBaseContext(DataBaseContext.ConnectionString))
                {
                    var excluir = db.Trabalhos.Where(t => t.Id == trabalho.Id).First();
                    db.Trabalhos.DeleteOnSubmit(excluir);
                    db.SubmitChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Realizado(Trabalhos trabalhos)
        {
            try
            {
                using (DataBaseContext db = new DataBaseContext(DataBaseContext.ConnectionString))
                {
                    Trabalhos update = (from tar in db.Trabalhos
                                     where tar.Id == trabalhos.Id
                                     select tar).First();
                    update.Realizada = !update.Realizada;
                    db.SubmitChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
