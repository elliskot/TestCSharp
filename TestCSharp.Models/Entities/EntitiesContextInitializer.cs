using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp.Models.Entities
{
    public class EntitiesContextInitializer : DropCreateDatabaseIfModelChanges<TestCSharpContext>
    {
        protected override void Seed(TestCSharpContext context)
        {
            List<Causale> causali = new List<Causale>
            {
                new Causale {ID=1, Descrizione="Carico"},
                new Causale {ID=2, Descrizione="Scarico per Furto"},
                new Causale {ID=3, Descrizione="Scarico per Vendita"},
                new Causale {ID=3, Descrizione="Invio ad altro magazzino"}
            };

            // add data into context and save to db
            foreach (Causale r in causali)
            {
                context.Causali.Add(r);
            }

            List<Articolo> articoli = new List<Articolo>
            {
                new Articolo {ID=1, Codice="ART.123", Descrizione="Articolo 123"},
                new Articolo {ID=2, Codice="ART.456", Descrizione="Articolo 456"},
                new Articolo {ID=3, Codice="ART.789", Descrizione="Articolo 789"}
            };

            // add data into context and save to db
            foreach (Articolo r in articoli)
            {
                context.Articoli.Add(r);
            }

            List<Magazzino> magazzini = new List<Magazzino>
            {
                new Magazzino {ID=1, Codice="MAG.001", Descrizione="Magazzino centrale"},
                new Magazzino {ID=2, Codice="MAG.002", Descrizione="Magazzino ricambi"},
                new Magazzino {ID=3, Codice="MAG.CF", Descrizione="Magazzino clienti e fornitori"},
                new Magazzino {ID=3, Codice="MAG.FS", Descrizione="Magazzino scarti e furti"}
            };

            // add data into context and save to db
            foreach (Magazzino r in magazzini)
            {
                context.Magazzini.Add(r);
            }

            context.SaveChanges();

        }
    }
}
