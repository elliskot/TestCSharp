using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp.Models
{
    public partial class Magazzino
    {
        public Magazzino()
        {
            this.MovimentiP = new List<Movimento>();
            this.MovimentiD = new List<Movimento>();
        }
        public int ID { get; set; }
        public string Codice { get; set; }
        public string Descrizione { get; set; }

        public virtual ICollection<Movimento> MovimentiP { get; set; }
        public virtual ICollection<Movimento> MovimentiD { get; set; }
    }
}
