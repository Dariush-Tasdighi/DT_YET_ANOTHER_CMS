using Persistence;
using Infrastructure;
using Domain.Features.Common;
using Microsoft.EntityFrameworkCore;

namespace Services.Features.Common;

public class ApplicationSettingService(ApplicationDbContext applicationDbContext) : BaseServiceWithDatabaseContext(applicationDbContext: applicationDbContext)
{
	public async Task<ApplicationSetting> GetInstanceAsync()
	{
		var result =
			await
			ApplicationDbContext.ApplicationSettings
			.FirstOrDefaultAsync();

		if (result is not null)
		{
			return result;
		}
		else
		{
			result = new ApplicationSetting();

			ApplicationDbContext.Add(result);

			await ApplicationDbContext.SaveChangesAsync();
		}

		return result;
	}
}
