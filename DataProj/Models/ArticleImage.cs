using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataProj.Models
{
  public  class ArticleImage
    {

        [ForeignKey("Image")]
        public Guid IdImage { get; set; }
        public Image Image { get; set; }

        [ForeignKey("Article")]
        public Guid IdArticle { get; set; }
        public Article Article { get; set; }







    }
}
