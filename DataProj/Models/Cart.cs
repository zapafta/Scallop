using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataProj.Models
{
   public class Cart
    {

        [Key]
        [Display(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Id is required")]
        public Guid Id { get; set; }



       
        
        public bool isEncomendada { get; set; }


        public bool isFaturada { get; set; }

        public virtual List<Article> ArticleList { get; set; }

    }
}
