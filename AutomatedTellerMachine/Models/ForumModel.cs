using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutomatedTellerMachine.Models
{
    public class ForumModel
    {

        public int Id { get; set; }

        public virtual ApplicationUser User { get; set; }

        
        public string ApplicationUserId { get; set; }

        public string Title { get; set; }

        public string Question { get; set; }
    }
}