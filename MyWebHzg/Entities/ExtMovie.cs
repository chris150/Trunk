using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Globalization;

namespace MyWebHzg.Entities
{

    /* Entity Framework legt diese Tabelle als Movies auf dem SQL-Server an */
    public partial class ExtMovie
    {
        public virtual Guid MovieId { get; set; }

        [Display(Name = "Title", ResourceType = typeof(BasicRes))]
        public virtual string Title { get; set; }


        public virtual Guid GenreId { get; set; }
        public virtual string GenreName { get; set; }

        [Display(Name = "Genre", ResourceType = typeof(BasicRes))]
        public virtual string GenreCd { get; set; }

        public virtual Guid MediumTypeId { get; set; }
        
        [Display(Name="Medium", ResourceType = typeof(BasicRes))]
        public virtual string MediumTypeName { get; set; }

        [Display(Name = "Price", ResourceType = typeof(BasicRes))]
        public virtual decimal Price { get; set; }

        [Display(Name = "ReleaseDate", ResourceType = typeof(BasicRes))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public virtual DateTime ReleaseDate { get; set; }

    }
}
