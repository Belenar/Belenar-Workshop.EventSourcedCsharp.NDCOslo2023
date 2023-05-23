using Microsoft.EntityFrameworkCore;

namespace BeerSender.Web.ReadStore;

public class Read_context : DbContext
{
    public Read_context(DbContextOptions<Read_context> options) : base(options)
    { }

    public DbSet<Box_status> Boxes => Set<Box_status>();
    public DbSet<Box_bottle> Bottles => Set<Box_bottle>();
    public DbSet<Checkpoint> Checkpoints => Set<Checkpoint>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Box_status>()
            .HasKey(b => b.Aggregate_id);

        modelBuilder.Entity<Box_bottle>()
            .HasOne(bottle => bottle.Box)
            .WithMany(box => box.Bottles)
            .HasPrincipalKey(box => box.Aggregate_id)
            .HasForeignKey(bottle => bottle.Box_id);

        modelBuilder.Entity<Checkpoint>()
            .HasKey(c => c.Name);

        modelBuilder.Entity<Checkpoint>()
            .Property(c => c.Last_timestamp)
            .HasColumnType("binary(8)");

        modelBuilder.Entity<Checkpoint>()
            .Property(c => c.Name)
            .HasMaxLength(64)
            .HasColumnType("varchar");
    }
}

public class Checkpoint
{
    public string Name { get; set; }
    public byte[] Last_timestamp { get; set; }
}

public class Box_status
{
    public Guid Aggregate_id { get; set; }
    public int? Size { get; set; }
    public ICollection<Box_bottle> Bottles { get; set; } = new HashSet<Box_bottle>();
    public string? Carrier { get; set; }
    public string? Tracking_code { get; set; }
    public Box_State Status { get; set; } = Box_State.Created;
}

public class Box_bottle
{
    public int Id { get; set; }
    public Guid Box_id { get; set; }
    public Box_status Box { get; set; }
    public string Brewery { get; set; }
    public string Name { get; set; }
    public decimal Percentage { get; set; }
}

public enum Box_State
{
    Created,
    Closed,
    Shipped
}