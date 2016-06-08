using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebHzg.Entities
{

    public partial class Genre
    {        
        public virtual Guid GenreId { get; set; }
     
        [MaxLength(8), MinLength(1)]
        public virtual string GenreCd { get; set; }

        [MaxLength(64), Required, Column("Bez")]
        public virtual string Bezeichnung { get; set; }

        /* Navigationseigenschaft - Navigation Property */
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
