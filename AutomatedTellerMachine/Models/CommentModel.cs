using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AutomatedTellerMachine.Models
{
    public class CommentModel
    {
        public int Id { get; set; }

        public string message { get; set; }

        
        public int ForumModelId { get; set; }

        [ForeignKey("ForumModelId")]
        public virtual ForumModel ForumModel { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }
    }
}