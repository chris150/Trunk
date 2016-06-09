using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Globalization;

namespace MyWebHzg.Entities
{
    public partial class ActualValueAllg
    {
        [Key]
        public virtual Guid Id { get; set; }
        public virtual DateTime CreateDateTime { get; set; }

        // Allgemein
        [Display(Name = "Sym_Witterungstemperatur", ResourceType = typeof(BasicRes))]
        [DisplayFormat(DataFormatString = "{0:0.0}", ApplyFormatInEditMode = true)]
        public virtual double Witterungstemperatur { get; set; }

    }
}
