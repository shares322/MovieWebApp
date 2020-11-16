using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWebApp.Models.Movies
{
    public class RegisterMovie
    {
        [Key]
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public DateTime DateTime { get; set; }
        public string Actors { get; set; }
        public string Directors { get; set; }
       
    }
}
