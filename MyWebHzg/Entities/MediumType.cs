using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebHzg.Entities
{
    [Table("MediumTypeTable")]
    public partial class MediumType
    {
        [Key]
        public virtual Guid MediumTypeId { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
        [Column("Bez")]
        public virtual string Bezeichnung { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }

}
