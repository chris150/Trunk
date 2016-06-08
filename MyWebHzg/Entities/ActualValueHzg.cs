using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebHzg.Entities
{
    public partial class ActualValueHzg
    {
        [Key]
        public virtual Guid Id { get; set; }
        public virtual DateTime CreateDateTime { get; set; }

        // Allgemein
        public virtual int GruppeNr { get; set; }
        public virtual int Betriebsprogramm { get; set; }
        public virtual int Heizkreispumpe { get; set; }
        public virtual int RaumtempSoll { get; set; }
        public virtual int ReduzierteRaumtempSoll { get; set; }
        public virtual int VentilLaufzeitIst { get; set; }
        public virtual int VorlauftempIst { get; set; }
        public virtual int VorlauftempSoll { get; set; }

    }
}
