using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebHzg.Entities
{
    public partial class ActualValueAllg
    {
        [Key]
        public virtual Guid Id { get; set; }
        public virtual DateTime CreateDateTime { get; set; }

        // Allgemein
        public virtual int Witterungstemperatur { get; set; }

    }
}
