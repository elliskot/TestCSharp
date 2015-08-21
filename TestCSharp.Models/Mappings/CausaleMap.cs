using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TestCSharp.Models.Mappings
{
    public class CausaleMap : EntityTypeConfiguration<Causale>
    {
        public CausaleMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .IsRequired();

            this.Property(t => t.Descrizione)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Causale");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Descrizione).HasColumnName("Descrizione");

        }
    }
}
