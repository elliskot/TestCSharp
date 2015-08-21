using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TestCSharp.Models.Mappings
{
    public class ArticoloMap : EntityTypeConfiguration<Articolo>
    {
        public ArticoloMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .IsRequired();

            this.Property(t => t.Codice)
                //.IsRequired()
                .HasMaxLength(16);

            this.Property(t => t.Descrizione)
                //.IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Articolo");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Codice).HasColumnName("Codice");
            this.Property(t => t.Descrizione).HasColumnName("Descrizione");

        }
    }
}
