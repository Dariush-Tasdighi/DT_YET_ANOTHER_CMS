using Persistence;

namespace Infrastructure;

public abstract class BaseServiceWithApplicationDbContext(ApplicationDbContext applicationDbContext) : object
{
	public ApplicationDbContext ApplicationDbContext { get; init; } = applicationDbContext;
}
