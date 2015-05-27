using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutomatedTellerMachine.Models
{
    public class NewsModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Article Title")]
        public string NewsTitle { get; set; }
        [Required]
        [Display(Name = "Article main image")]
        public string NewsImageUrl { get; set; }
        [Required]
        [Display(Name = "Paragraph #1")]
        [DataType(DataType.MultilineText)]
        public string NewsPart1 { get; set; }
        [Display(Name = "Video URL")]
        public string VideoUrl { get; set; }
        [Display(Name = "Paragraph #2")]
        [DataType(DataType.MultilineText)]
        public string NewsPart2 { get; set; }

        public string Author { get; set; }
    }
}