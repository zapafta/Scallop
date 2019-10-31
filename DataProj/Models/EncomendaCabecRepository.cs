using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataProj.Models
{


    public  class EncomendaCabecRepository
    {

        ApplicationDbContext context;

        public EncomendaCabecRepository(ApplicationDbContext pContext)
        {
            context = pContext;
        }



        public EncomendaCabec GetEncomendaCabecById(Guid Id)

        {
            EncomendaCabec encomendaCabec = context.EncomendaCabec.Where(t => t.Id == Id).FirstOrDefault();
            return encomendaCabec;
        }



        public List<EncomendaCabec> GetEncomendaByUser(Guid IdUser)

        {
            List<EncomendaCabec> encomendaCabec = context.EncomendaCabec.Where(t => t.IdUserSite == IdUser).ToList();
            return encomendaCabec;
        }

        public void SaveEncomendaLinha(EncomendaCabec encomendaCabec)
        {

            EncomendaCabec encomendaLinhaVerify = context.EncomendaCabec.Where(t => t.Id == encomendaCabec.Id).FirstOrDefault();
            if (encomendaLinhaVerify == null)
            {
                //Vamos gravar
                EncomendaCabec encomendaCabecNew = new EncomendaCabec();
                encomendaCabecNew.Id = Guid.NewGuid();
                encomendaCabecNew.CodPostal = encomendaCabec.CodPostal;
                encomendaCabecNew.Descricao = encomendaCabec.Descricao;
                encomendaCabecNew.IdUserSite = encomendaCabec.IdUserSite;
                encomendaCabecNew.Localidade = encomendaCabec.Localidade;
                encomendaCabecNew.Morada = encomendaCabec.Morada;
                encomendaCabecNew.Payment = encomendaCabec.Payment;
                context.Entry(encomendaCabecNew).State = EntityState.Added;
                context.SaveChanges();
            }
            else
            {
                encomendaLinhaVerify.CodPostal = encomendaCabec.CodPostal;
                encomendaLinhaVerify.Descricao = encomendaCabec.Descricao;
                encomendaLinhaVerify.IdUserSite = encomendaCabec.IdUserSite;
                encomendaLinhaVerify.Localidade = encomendaCabec.Localidade;
                encomendaLinhaVerify.Morada = encomendaCabec.Morada;
                encomendaLinhaVerify.Payment = encomendaCabec.Payment;
                context.Entry(encomendaLinhaVerify).State = EntityState.Modified;
                context.SaveChanges();

                //Vamos Alterar
            }


        }




    }
}
