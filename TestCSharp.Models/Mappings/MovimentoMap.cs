using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TestCSharp.Models.Mappings
{
    public class MovimentoMap : EntityTypeConfiguration<Movimento>
    {
        public MovimentoMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .IsRequired();

            this.Property(t => t.ArticoloID).IsRequired();
            this.Property(t => t.PartenzaID).IsRequired();
            this.Property(t => t.DestinazioneID).IsRequired();
            this.Property(t => t.CausaleID).IsRequired();

            // Table & Column Mappings
            this.ToTable("Movimento");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ArticoloID).HasColumnName("ArticoloID");
            this.Property(t => t.PartenzaID).HasColumnName("PartenzaID");
            this.Property(t => t.DestinazioneID).HasColumnName("DestinazioneID");
            this.Property(t => t.CausaleID).HasColumnName("CausaleID");

            //// Relationships
            this.HasRequired(t => t.Articolo)
                .WithMany(t => t.Movimenti)
                .HasForeignKey(d => d.ArticoloID);
            this.HasRequired(t => t.Partenza)
                .WithMany(t => t.MovimentiP)
                .HasForeignKey(d => d.PartenzaID).WillCascadeOnDelete(false);
            this.HasRequired(t => t.Destinazione)
                .WithMany(t => t.MovimentiD)
                .HasForeignKey(d => d.DestinazioneID).WillCascadeOnDelete(false);
            this.HasRequired(t => t.Causale)
                .WithMany(t => t.Movimenti)
                .HasForeignKey(d => d.CausaleID);

        }
    }
}
