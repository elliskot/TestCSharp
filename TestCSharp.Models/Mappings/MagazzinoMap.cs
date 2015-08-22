using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TestCSharp.Models.Mappings
{
    public class MagazzinoMap : EntityTypeConfiguration<Magazzino>
    {
        public MagazzinoMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .IsRequired();

            this.Property(t => t.Codice)
                .HasMaxLength(16);

            this.Property(t => t.Descrizione)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Magazzino");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Codice).HasColumnName("Codice");
            this.Property(t => t.Descrizione).HasColumnName("Descrizione");
            
        }
    }
}
