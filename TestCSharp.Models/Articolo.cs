using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp.Models
{
    public partial class Articolo
    {
        public Articolo()
        {
            this.Movimenti = new List<Movimento>();
        }
        public int ID { get; set; }
        public string Codice { get; set; }
        public string Descrizione { get; set; }

        public virtual ICollection<Movimento> Movimenti { get; set; }
    }
}
