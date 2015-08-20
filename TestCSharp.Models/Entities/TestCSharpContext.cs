using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using TestCSharp.Models;
using TestCSharp.Models.Mappings;

namespace TestCSharp.Models.Entities
{
    public class TestCSharpContext : ContextBase
    {
        public const string Name = "TestCSharp.TestCSharpContext";

        public TestCSharpContext() : this(Name) 
        {
        }

        public TestCSharpContext(string name) : base(name) 
        {
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
        }


        public DbSet<Articolo> Articoli { get; set; }
        public DbSet<Magazzino> Magazzini { get; set; }
        public DbSet<Movimento> Movimenti { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Configurations.Add(new ArticoloMap());
            modelBuilder.Configurations.Add(new MagazzinoMap());
            modelBuilder.Configurations.Add(new MovimentoMap());
        }
    }
}

