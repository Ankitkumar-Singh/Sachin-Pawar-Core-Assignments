using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcFirstApp.Models
{
    public class Comment
    {       
        public int CommentId { get; set; }

        [Key]
        public int MovieId { get; set; }

        public String MovieComment { get; set; }
    }
}