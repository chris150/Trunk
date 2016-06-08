using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebHzg.Entities
{
    public partial class ActualValuePuffer
    {
        [Key]
        public virtual Guid Id { get; set; }
        public virtual DateTime CreateDateTime { get; set; }

        // Pufferspeicher        
        public virtual int PufferSensor_1 { get; set; }
        public virtual int PufferSensor_2 { get; set; }
        public virtual int PufferSensor_3 { get; set; }
        public virtual int PufferSensor_4 { get; set; }
        public virtual int PufferSensor_5 { get; set; }
        public virtual int PufferLadezustand { get; set; }
        public virtual int PuffertempMittelwert { get; set; }
    }
}
