using Domain.Features.Cms;
using Domain.Features.Common;
using Domain.Features.Identity;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext() : base()
	{
		// تا قبل از اولین نسخه اصلی
		Database.EnsureCreated();
	}

	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options: options)
	{
		// تا قبل از اولین نسخه اصلی
		Database.EnsureCreated();

		// نوشتن دستورات ذیل کامل غلط است
		// لااقل در اولین باری که بانک‌اطلاعاتی
		// می‌خواهد ایجاد شود، کار نمی‌کند
		//// using Microsoft.EntityFrameworkCore;
		//if (Database.GetAppliedMigrations().Any())
		//{
		//	// using Microsoft.EntityFrameworkCore;
		//	Database.Migrate();
		//}

		//Database.Migrate();
	}

	public DbSet<User> Users { get; set; }
	public DbSet<Role> Roles { get; set; }

	public DbSet<Page> Pages { get; set; }
	public DbSet<MenuItem> MenuItems { get; set; }
	public DbSet<PostCategory> PostCategories { get; set; }

	public DbSet<ApplicationSetting> ApplicationSettings { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		if (optionsBuilder.IsConfigured == false)
		{
			var connectionString = "Server=.;User ID=sa;Password=1234512345;Database=DT_CMS;MultipleActiveResultSets=true;TrustServerCertificate=True;";

			optionsBuilder
				//.UseLazyLoadingProxies()
				.UseSqlServer(connectionString: connectionString)
				;

			//optionsBuilder.EnableDetailedErrors(detailedErrorsEnabled: true);
			//optionsBuilder.EnableSensitiveDataLogging(sensitiveDataLoggingEnabled: true);

			//optionsBuilder.LogTo(
			//	action: System.Console.WriteLine,

			//	minimumLevel: LogLevel.Trace,
			//	//minimumLevel: Microsoft.Extensions.Logging.LogLevel.Trace,

			//	options:
			//		DbContextLoggerOptions.Id |
			//		DbContextLoggerOptions.Level |
			//		DbContextLoggerOptions.Category |
			//		DbContextLoggerOptions.LocalTime
			//);
		}
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly
			(assembly: typeof(ApplicationDbContext).Assembly);

		//modelBuilder.Seed();
	}
}
