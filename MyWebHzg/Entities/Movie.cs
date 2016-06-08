using Globalization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebHzg.Entities
{

    /* Entity Framework legt diese Tabelle als Movies auf dem SQL-Server an */
    public partial class Movie
    {
        [Key]
        public virtual Guid MovieId { get; set; }

        [MaxLength(128)]
        [Required]
        [Display(Name = "Title", ResourceType = typeof(BasicRes))]
        [RegularExpression(@"^[a-zA-Z0-9\ ]{2,}$", ErrorMessage = "Gross- und Kleinschreibung, mind 2 Zeichen, keine Sonderzeichen")]
        public virtual string Title { get; set; }


        // Kein Fremdschlüssel-Mapping

        /* Name der Navigationseigenschaft + Name des Primärschlüssels der referenzierten Entität
           Name der referenzierten Entität + Name ihres Primärschlüssels oder
           Name des Primärschlüssels der referenzierten Entität. 
           Wichtig: Der Datentyp des Primäschlüsselmappings muss mit jenem
           des Primärschlüssels übereinstimmen. */

        [Display(Name = "Genre", ResourceType = typeof(BasicRes))]
        public virtual Guid GenreId { get; set; }
        public virtual Genre Genre { get; set; }

        // Wenn Nullwerte auf der Datenbank erlaubt, dann Nullable markieren.
        [Column("MediumTypeId")]
        [Display(Name = "Medium", ResourceType = typeof(BasicRes))]
        public virtual Nullable<Guid> MediumTypeId { get; set; }
        [ForeignKey("MediumTypeId")]        
        public virtual MediumType MediumType { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Price", ResourceType = typeof(BasicRes))]
        public virtual decimal Price { get; set; }

        [Display(Name = "ReleaseDate", ResourceType = typeof(BasicRes))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public virtual DateTime ReleaseDate { get; set; }

        public virtual ICollection<Actor> Actors { get; set; }

    }
}
