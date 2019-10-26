using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataProj.Models
{
  public  class Article
    {

        [Key]
        [Display(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Id is required")]
        public Guid Id { get; set; }

        [Display(Order = 1)]
        [Required(ErrorMessage = "Descricao is required")]
        public string Descricao { get; set; }


        [Display(Order = 2)]
        [Required(ErrorMessage = "PrecoUnit is required")]
        public decimal PrecoUnit { get; set; }

        [Display(Order = 3)]
        [Required(ErrorMessage = "Qtd is required")]
        public int Qtd { get; set; }

        [Display(Order = 4)]
        [Required(ErrorMessage = "Active is required")]
        public bool Active { get; set; }


        [Display(Order = 5)]
        [ForeignKey("Category")]
        public Guid IdCategory { get; set; }
        public Category Category { get; set; }


        [Display(Order = 6)]
        public string DescricaoLonga { get; set; }


        public virtual List<Image> ImageList { get; set; }
    }
}
