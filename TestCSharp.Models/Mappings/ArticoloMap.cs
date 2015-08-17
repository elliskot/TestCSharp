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
                .HasMaxLength(16);

            this.Property(t => t.Descrizione)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Articolo");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Codice).HasColumnName("Codice");
            this.Property(t => t.Descrizione).HasColumnName("Descrizione");

            //// Relationships
            //this.HasOptional(t => t.CicloNormale)
            //    .WithMany(t => t.ArticoliNormali)
            //    .HasForeignKey(d => d.CicloNormaleID);

            ////this.HasOptional(s => s.CicloSpeciale) // Mark StudentAddress is optional for Student
            ////    .WithOptionalDependent(ad => ad.ArticoloSpeciale); // Create inverse relationship

            ////this.HasOptional(t => t.CicloSpeciale)
            ////    .WithOptionalDependent(t => t.ArticoloSpeciale);
            //this.HasOptional(t => t.CicloSpeciale)
            //    .WithMany(t => t.ArticoliSpeciali)
            //    .HasForeignKey(d => d.CicloSpecialeID);

            //this.HasOptional(t => t.CicloStandard)
            //    .WithMany(t => t.ArticoliStandard)
            //    .HasForeignKey(d => d.CicloStandardID);

        }
    }
}
