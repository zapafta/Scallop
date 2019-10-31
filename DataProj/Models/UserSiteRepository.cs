using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataProj.Models
{
    public class UserSiteRepository
    {
        ApplicationDbContext context;
        public UserSiteRepository(ApplicationDbContext pContext)
        {
            context = pContext;
        }



        public UserSite getUserByEmail(string email)

        {
            UserSite user = context.UserSite.Where(t => t.Email == email).FirstOrDefault();
            return user;
        }


        public UserSite GetUserById(Guid id)

        {
            UserSite user = context.UserSite.Where(t => t.Id == id).FirstOrDefault();
            return user;
        }

        public void SaveUser(UserSite user)
        {

            UserSite UserSiteVerify = context.UserSite.Where(t => t.Email == user.Email).FirstOrDefault();
            if (UserSiteVerify == null)
            {
                //Vamos gravar
                UserSite UserSiteNew = new UserSite();
                UserSiteNew.Id = Guid.NewGuid();
                UserSiteNew.Email = user.Email.ToUpper().Trim();
             
                context.Entry(UserSiteNew).State = EntityState.Added;
                context.SaveChanges();
            }
            else
            {
                UserSiteVerify.Email = user.Email;
             
                context.Entry(UserSiteVerify).State = EntityState.Modified;
                context.SaveChanges();

                //Vamos Alterar
            }


        }
    }
}
