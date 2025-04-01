using Persistence;
using Infrastructure;
using Domain.Features.Common;
using Microsoft.EntityFrameworkCore;

namespace Services.Features.Common;

public class ApplicationSettingService(ApplicationDbContext applicationDbContext) :
	BaseServiceWithApplicationDbContext(applicationDbContext: applicationDbContext)
{
	public async Task<ApplicationSetting> GetInstanceAsync()
	{
		var result =
			await
			ApplicationDbContext.ApplicationSettings
			.FirstOrDefaultAsync();

		if (result is null)
		{
			result = new ApplicationSetting();

			ApplicationDbContext.Add(entity: result);

			await ApplicationDbContext.SaveChangesAsync();
		}

		return result;
	}
}
