using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie
{

    public class MovieContext2 : DbContext
    {
        public MovieContext2(string databaseName)
            : base(databaseName) { }
        public DbSet<Actress> Actresses { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<GoldenGlobe> GoldenGlobes { get; set; }
        public DbSet<Oscar> Oscars { get; set; }
        public DbSet<Movie> Movies { get; set; }
    }
}
