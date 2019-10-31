using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataProj.Models
{
 public  class EncomendaLinha
    {

        [Key]
        [Display(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Id is required")]
        public Guid Id { get; set; }
        
        [Display(Order = 1)]
        [ForeignKey("EncomendaCabec")]
        public Guid IdEncomendaCabec { get; set; }
        public EncomendaCabec EncomendaCabec { get; set; }

        [Display(Order = 2)]
        [Required(ErrorMessage = "Payment is required")]
        public bool IsPayment { get; set; }


        [Display(Order = 3)]
        [Required(ErrorMessage = "PrecoUnit is required")]
        public double PrecoUnit { get; set; }

        [Display(Order = 4)]
        [Required(ErrorMessage = "Qty is required")]
        public int Qty { get; set; }


        [Display(Order = 5)]
        [Required(ErrorMessage = "DateCreation is required")]
        public DateTime DateCreation { get; set; }

        [Display(Order = 6)]
        [Required(ErrorMessage = "DateModification is required")]
        public DateTime DateModification { get; set; }

        [Display(Order = 7)]
        [Required(ErrorMessage = "DateModification is required")]
        public string UserCreation { get; set; }





    }
}
