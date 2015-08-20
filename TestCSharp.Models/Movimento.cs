using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp.Models
{
    public partial class Movimento
    {
        public int ID { get; set; }
        public int ArticoloID { get; set; }
        public int PartenzaID { get; set; }
        public int DestinazioneID { get; set; }
        public int CausaleID { get; set; }

        public virtual Articolo Articolo { get; set; }
        public virtual Magazzino Partenza { get; set; }
        public virtual Magazzino Destinazione { get; set; }
        public virtual Causale Causale { get; set; }
    }
}
