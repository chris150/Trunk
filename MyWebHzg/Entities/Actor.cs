using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebHzg.Entities
{
    public partial class Actor
    {
        public virtual Guid ActorId { get; set; }
        
        [Required, MaxLength(256)]
        public virtual string Name { get; set; }

        public virtual Nullable<DateTime> Birthdate { get; set; }

        public virtual Nullable<bool> Gender { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
