using KeyWorkerService.Infrastructure.DataModels.TblSEXTE;
using Microsoft.EntityFrameworkCore;

namespace KeyWorkerService.Infrastructure.Data;

public partial class TblSexteContext : DbContext
{
    public TblSexteContext()
    {
    }

    public TblSexteContext(DbContextOptions<TblSexteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("usuarios");

            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("lastName");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
