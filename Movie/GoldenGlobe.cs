using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie
{
    public class GoldenGlobe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Year { get; set; }
        public Actor ActorId { get; set; }
        public Actress ActressId { get; set; }
        public Director DirectorId { get; set; }
        public Movie MovieId { get; set; }
    }
}
