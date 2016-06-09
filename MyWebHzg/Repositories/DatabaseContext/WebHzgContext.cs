using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWebHzg.Entities;

namespace MyWebHzg.Repositories

{
    public class WebHzgContext : DbContext
    {

        public WebHzgContext() : base("MovieEntitaeten") {}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
        }

        public DbSet<ActualValueAllg> ActualValueAllgs { get; set; }

    }
}
