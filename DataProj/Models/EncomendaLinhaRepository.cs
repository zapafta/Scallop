using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataProj.Models
{
   public class EncomendaLinhaRepository
    {

        ApplicationDbContext context;
        public EncomendaLinhaRepository(ApplicationDbContext pContext)
        {
            context = pContext;
        }


        public List<EncomendaLinha> GetEncomendaByCabec(Guid IdCabec)

        {
            List<EncomendaLinha> encomendaCabec = context.EncomendaLinha.Where(t => t.IdEncomendaCabec == IdCabec).ToList();
            return encomendaCabec;
        }



        public List<EncomendaLinha> GetLinhaEncomendaById(Guid id)

        {
            List<EncomendaLinha> encomendaCabec = context.EncomendaLinha.Where(t => t.Id == id).ToList();
            return encomendaCabec;
        }




        public void SaveEncomendaLinha(EncomendaLinha encomendaLinha)
        {

            EncomendaLinha encomendaLinhaVerify = context.EncomendaLinha.Where(t => t.Id == encomendaLinha.Id ).FirstOrDefault();
            if (encomendaLinhaVerify == null)
            {
                //Vamos gravar
                EncomendaLinha encomendaLinhaNew = new EncomendaLinha();
                encomendaLinhaNew.Id = Guid.NewGuid();
                encomendaLinhaNew.IdEncomendaCabec = encomendaLinha.IdEncomendaCabec;
                encomendaLinhaNew.IsPayment = encomendaLinha.IsPayment;
                encomendaLinhaNew.PrecoUnit = encomendaLinha.PrecoUnit;
                encomendaLinhaNew.Qty = encomendaLinha.Qty;
                encomendaLinhaNew.UserCreation = "";
                encomendaLinhaNew.DateCreation = DateTime.Now;
                encomendaLinhaNew.ArticleID = encomendaLinha.ArticleID;
                encomendaLinhaNew.Article = encomendaLinha.Article;
                context.Entry(encomendaLinhaNew).State = EntityState.Added;
                context.SaveChanges();
            }
            else
            {
                encomendaLinhaVerify.UserCreation = encomendaLinha.UserCreation;
                encomendaLinhaVerify.DateCreation = encomendaLinha.DateCreation;
                encomendaLinhaVerify.DateModification = DateTime.Now;
                context.Entry(encomendaLinhaVerify).State = EntityState.Modified;
                context.SaveChanges();

                //Vamos Alterar
            }


        }

    }
}
