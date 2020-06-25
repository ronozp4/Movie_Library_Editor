using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MovieSerial { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public Director DirectorId { get; set; }
        public string Country { get; set; }
        public decimal ImdbScore { get; set; }
        public ICollection<Actor> Actors { get; set; }
        public ICollection<Actress> Actresses { get; set; }
    }
}
