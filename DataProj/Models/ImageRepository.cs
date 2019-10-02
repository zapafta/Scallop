using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataProj.Models
{
    public class ImageRepository
    {
        ApplicationDbContext context;
        public ImageRepository(ApplicationDbContext pContext)
        {
            context = pContext;
        }


        public List<Image> GetImages()
        {

            List<Image> l = context.Image.ToList();
            return l;
        }


    }
}
