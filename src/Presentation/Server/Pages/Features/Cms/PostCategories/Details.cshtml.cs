using Dtat;
using Persistence;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ViewModels.Pages.Features.Cms.PostCategories;

namespace Server.Pages.Features.Cms.PostCategories;

//[Infrastructure.Security.CustomAuthorize(minRoleCode:
//	Domain.Features.Identity.Enums.RoleEnum.Supervisor)]
public class DetailsModel : BasePageModelWithApplicationDbContext
{
	public DetailsModel(ApplicationDbContext applicationDbContext) : base(applicationDbContext: applicationDbContext)
	{
		ViewModel = new();
	}

	public DetailsOrDeleteViewModel ViewModel { get; private set; }

	public async Task<IActionResult> OnGetAsync(Guid? id)
	{
		if (id is null)
		{
			return RedirectToPage(pageName: Constant.CommonRouting.BadRequest);
		}

		var result =
			await
			ApplicationDbContext.PostCategories
			.Where(current => current.Id == id.Value)
			.Select(current => new DetailsOrDeleteViewModel
			{
				Id = current.Id,
				Body = current.Body,
				Hits = current.Hits,
				Name = current.Name,
				Title = current.Title,
				ImageUrl = current.ImageUrl,
				IsActive = current.IsActive,
				Ordering = current.Ordering,
				//PostCount = current.Posts.Count,
				Description = current.Description,
				CoverImageUrl = current.CoverImageUrl,
				InsertDateTime = current.InsertDateTime,
				UpdateDateTime = current.UpdateDateTime,
				DisplayInHomePage = current.DisplayInHomePage,
				MaxPostCountInHomePage = current.MaxPostCountInHomePage,
				MaxPostCountInMainPage = current.MaxPostCountInMainPage,
			})
			.FirstOrDefaultAsync();

		if (result is null)
		{
			return RedirectToPage(pageName: Constant.CommonRouting.NotFound);
		}

		ViewModel = result;

		return Page();
	}
}
