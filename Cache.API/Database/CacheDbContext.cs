using Microsoft.EntityFrameworkCore;

namespace Database;

public partial class CacheDbContext : DbContext
{
	public CacheDbContext()
	{
	}

	public CacheDbContext(DbContextOptions<CacheDbContext> options)
		: base(options)
	{
	}

	public virtual DbSet<Cache> Caches { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Cache>(entity =>
		{
			entity.ToTable("Cache");

			entity.Property(e => e.CacheKey).HasMaxLength(450);
			entity.Property(e => e.CreatedAt).HasColumnType("datetime");
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
