using ExtractInfoDocument.BUISNESS_LOGIC.ENTITIES;
using Microsoft.EntityFrameworkCore;

namespace ExtractInfoDocument.INFRASTRUCTURE.MODEL;

public class ExtractionInfoDocumentContext : DbContext
{
    public ExtractionInfoDocumentContext(DbContextOptions<ExtractionInfoDocumentContext> options) : base(options)
    {
    }

    public DbSet<ExtractionPerformed> ExtractionPerformeds { get; set; }
    public DbSet<ExtractionDetail> ExtractionDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExtractionPerformed>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<ExtractionPerformed>()
            .Property(x => x.License)
            .HasMaxLength(50)
            .IsRequired();

        modelBuilder.Entity<ExtractionPerformed>()
            .Property(x => x.Date)
            .IsRequired();

        modelBuilder.Entity<ExtractionPerformed>()
            .HasMany(x => x.Details)
            .WithOne(x => x.ExtractionPerformed)
            .HasForeignKey(x => x.ExtractionPerformedId);

        modelBuilder.Entity<ExtractionDetail>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<ExtractionDetail>()
            .Property(x => x.NameDocument)
            .HasMaxLength(250)
            .IsRequired();
    }
}
