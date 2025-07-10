using Microsoft.EntityFrameworkCore;

namespace hometask5.Models;

public partial class ApplicationContext : DbContext
{
    public virtual DbSet<Analysis> Analyses { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Order> Orders { get; set; }
    
    private readonly string _connectionString;

    public ApplicationContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(_connectionString);
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Analysis>(entity =>
        {
            entity.HasKey(e => e.AnId).HasName("PK__Analysis__831DABF3C016F1F2");

            entity.ToTable("Analysis");

            entity.HasIndex(e => e.AnName, "UQ__Analysis__251E3FCD0619E067").IsUnique();

            entity.Property(e => e.AnId).HasColumnName("an_id");
            entity.Property(e => e.AnCost)
                .HasColumnType("money")
                .HasColumnName("an_cost");
            entity.Property(e => e.AnGroup).HasColumnName("an_group");
            entity.Property(e => e.AnName)
                .HasMaxLength(255)
                .HasColumnName("an_name");
            entity.Property(e => e.AnPrice)
                .HasColumnType("money")
                .HasColumnName("an_price");

            entity.HasOne(d => d.AnGroupNavigation).WithMany(p => p.Analyses)
                .HasForeignKey(d => d.AnGroup)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Analysis__an_gro__3B75D760");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.GrId).HasName("PK__Groups__2BC0F88EBD58F738");

            entity.HasIndex(e => e.GrName, "UQ__Groups__2291CF8D1E34F79C").IsUnique();

            entity.Property(e => e.GrId).HasColumnName("gr_id");
            entity.Property(e => e.GrName)
                .HasMaxLength(255)
                .HasColumnName("gr_name");
            entity.Property(e => e.GrTemp).HasColumnName("gr_temp");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrdId).HasName("PK__Orders__DC39D7DFF1FDB40D");

            entity.Property(e => e.OrdId).HasColumnName("ord_id");
            entity.Property(e => e.OrdAn).HasColumnName("ord_an");
            entity.Property(e => e.OrdDatetime).HasColumnName("ord_datetime");

            entity.HasOne(d => d.OrdAnNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrdAn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__ord_an__3E52440B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
