using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataProj.Models
{
  public class Category
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
        [Required(ErrorMessage = "Active is required")]
        public bool Active { get; set; }
    }
}
