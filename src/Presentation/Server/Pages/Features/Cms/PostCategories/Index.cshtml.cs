using Persistence;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using ViewModels.Pages.Features.Cms.PostCategories;

namespace Server.Pages.Features.Cms.PostCategories;

/// <summary>
/// https://localhost:7057/Features/Cms/PostCategories/Index
/// </summary>
//[Infrastructure.Security.CustomAuthorize(minRoleCode:
//	Domain.Features.Identity.Enums.RoleEnum.Supervisor)]
public class IndexModel : BasePageModelWithApplicationDbContext
{
	public IndexModel(
		ApplicationDbContext applicationDbContext) :
		base(applicationDbContext: applicationDbContext)
	{
		ViewModel = [];
	}

	public List<IndexItemViewModel> ViewModel { get; private set; }

	public async Task OnGetAsync()
	{
		ViewModel =
			await
			ApplicationDbContext.PostCategories
			.OrderBy(current => current.Ordering)
			.ThenBy(current => current.Name)
			.Select(current => new IndexItemViewModel
			{
				Id = current.Id,

				Name = current.Name,
				Title = current.Title,

				Hits = current.Hits,
				Ordering = current.Ordering,

				// TODO
				//PostCount = current.Posts.Count,
				//InactivePostCount

				InsertDateTime = current.InsertDateTime,
				UpdateDateTime = current.UpdateDateTime,

				IsActive = current.IsActive,
				DisplayInHomePage = current.DisplayInHomePage,
			})
			.ToListAsync()
			;
	}
}
