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
    public class MovieContext : DbContext
    {

        public MovieContext() : base("MovieEntitaeten"){}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Verhindern, dass Tabllennamen den Plural verwenden
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Name der Tabelle in Datenbank explizit angeben
            modelBuilder.Entity<MediumType>().ToTable("MediumTypeTab");

            // GenreCd als Primärschlüssel für Genre festlegen
            modelBuilder.Entity<Genre>().HasKey(g => g.GenreId);

            // Autoinkrement (Autowert +1) deaktivieren
            modelBuilder.Entity<Genre>().Property(g => g.GenreCd).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            
            // CustomTypeConfigurationen
            modelBuilder.Configurations.Add(new MovieEntityTypeConfiguration());

            // Löschweitergaben aktivieren / deaktivieren
            modelBuilder
                .Entity<Genre>()
                .HasMany(g => g.Movies) // Genre hat viele Movies
                .WithRequired(m => m.Genre) // Jedes Movie hat genau ein Genre
                .HasForeignKey(k => k.GenreId) // Fremdschlüsselmapping
                .WillCascadeOnDelete(false);

            // 0..n Beziehungen
            modelBuilder
                .Entity<Movie>()
                .HasOptional<MediumType>(mov => mov.MediumType) // Movie hat 0 oder 1  Mediumtypen
                .WithMany(med => med.Movies) // Mediumtype ist in vielen Movies
                .Map(mov => mov.MapKey("MediumTypeId"));
        }


        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MediumType> MediumTypes { get; set; }
        public DbSet<Actor> Actors { get; set; }
    }
}
