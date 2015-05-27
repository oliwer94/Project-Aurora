using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AutomatedTellerMachine.Models
{
    public class GameInfo
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Developer { get; set; }

        [Required]
        public string Publisher { get; set; }

        [Required]
        public string Platforms { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public string Genre { get; set; }

        [Display(Name = "Metacritic Score")]
        public int MetaCriticScore { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name = "In page image")]
        public string InPageImage { get; set; }

        [Required]
        [Display(Name = "Thumbnail #1")]
        public string Thumbnail { get; set; }
        [Required]
        [Display(Name = "Thumbnail #2")]
        public string Thumbnail2 { get; set; }
        [Required]
        [Display(Name = "Thumbnail #3")]
        public string Thumbnail3 { get; set; }
        [Required]
        [Display(Name = "Thumbnail #4")]
        public string Thumbnail4 { get; set; }

        [Required]
        [Display(Name = "Video Url #1")]
        public string VideoUrl { get; set; }
        [Required]
        [Display(Name = "Video Url #2 #4")]
        public string VideoUrl2 { get; set; }

        [Required]
        [Display(Name = "IGN Review Link")]
        public string ReviewLinks { get; set; }
        [Required]
        [Display(Name = "PC Gamer Review Link")]
        public string ReviewLinks2 { get; set; }
        [Required]
        [Display(Name = "Gamespot Review Link")]
        public string ReviewLinks3 { get; set; }
        [Required]
        [Display(Name = "Eurogamer Review Link")]
        public string ReviewLinks4 { get; set; }

    }
    
}