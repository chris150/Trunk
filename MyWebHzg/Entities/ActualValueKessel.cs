using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebHzg.Entities
{
    public partial class ActualValueKessel
    {
        [Key]
        public virtual Guid Id { get; set; }
        public virtual DateTime CreateDateTime { get; set; }

        // Kessel
        public virtual int KesselNr { get; set; }
        public virtual int Abgastemperatur { get; set; }
        public virtual int AbgasventilatorDrehzahlRPM { get; set; }
        public virtual int Betriebsstunden { get; set; }
        public virtual int Gesamtstatus { get; set; }
        public virtual int Kesselpumpe { get; set; }
        public virtual int RestO2Mittelwert { get; set; }
        public virtual int SekundaerluftklappeProzent { get; set; }
        public virtual int Vorlauftemperatur { get; set; }
        public virtual int AbgasventilatorDrehzahlProzent { get; set; }
    }
}
