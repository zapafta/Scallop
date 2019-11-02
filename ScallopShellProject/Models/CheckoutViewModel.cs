using DataProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScallopShellProject.Models
{
    public class CheckoutViewModel : MotherViewModel
    {

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Morada { get; set; }


        public string Cidade { get; set; }

        public string CodPostal { get; set; }

        public string Telefone { get; set; }

        public string Comentario { get; set; }


        public List<Article> ListArticles { get; set; }

        public List<Guid> ListIdArticle { get; set; }

    }
}
