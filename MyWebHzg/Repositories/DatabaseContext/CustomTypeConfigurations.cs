using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWebHzg.Entities;

namespace MyWebHzg.Repositories
{
    public class MovieEntityTypeConfiguration : EntityTypeConfiguration<Movie>
    {

        internal MovieEntityTypeConfiguration()
        {
            this.Property(p => p.Price).HasPrecision(18, 2);
        }

    }
}
