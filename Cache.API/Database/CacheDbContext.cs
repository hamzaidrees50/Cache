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

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
		=> optionsBuilder.UseSqlServer("Server=localhost; Database=CachingDB;Trusted_Connection=True;TrustServerCertificate=True");

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
