using Persistence;

namespace Infrastructure;

public abstract class BaseServiceWithDatabaseContext(ApplicationDbContext applicationDbContext) : object
{
	public ApplicationDbContext ApplicationDbContext { get; init; } = applicationDbContext;
}
