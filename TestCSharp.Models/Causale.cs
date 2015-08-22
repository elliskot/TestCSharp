using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp.Models
{
    public partial class Causale
    {
        public Causale()
        {
            this.Movimenti = new List<Movimento>();
        }
        public int ID { get; set; }
        [Required]
        public string Descrizione { get; set; }

        public virtual ICollection<Movimento> Movimenti { get; set; }
    }
}
