using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL
{
    public class EMDbContext : DbContext 
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Photography> Photographies { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Decoration> Decorations { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Catering> Caterings { get; set; }


        public DbSet<OrderedCatering> OCaterings { get; set; }
        public DbSet<OrderedDecoration> ODecorations { get; set; }
        public DbSet<OrderedPhotography> OPhotographies { get; set; }
        public DbSet<OrderedPlace> OPlaces { get; set; }
        public DbSet<OrderedFood> OFoods { get; set; }

    }
}
