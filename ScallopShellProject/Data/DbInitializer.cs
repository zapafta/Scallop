using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using DataProj;

namespace ScallopShellProject.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
           // context.Database.EnsureCreated();
            context.Database.Migrate();
        }
    }
}