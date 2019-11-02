using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataProj.Models
{
   public class EncomendaCabec
    {


        [Key]
        [Display(Order = 0)]
        [Required(ErrorMessage = "Id is required")]
        public Guid Id { get; set; }

        [Display(Order = 1)]
        [Required(ErrorMessage = "Descricao is required")]
        public string Descricao { get; set; }

        [Display(Order = 2)]
        [Required(ErrorMessage = "Payment is required")]
        public bool Payment { get; set; }


        [Display(Order = 3)]
        [Required(ErrorMessage = "Localidade is required")]
        public string Localidade { get; set; }

        [Display(Order = 4)]
        [Required(ErrorMessage = "Localidade is required")]
        public string Morada { get; set; }


        [Display(Order = 5)]
        [Required(ErrorMessage = "CodPostal is required")]
        public string CodPostal { get; set; }



        [Display(Order = 8)]
        [ForeignKey("UserSite")]
        public Guid IdUserSite { get; set; }
        public UserSite UserSite { get; set; }


        [Display(Order = 9)]
        public string NomeUtilizador { get; set; }



    }
}
