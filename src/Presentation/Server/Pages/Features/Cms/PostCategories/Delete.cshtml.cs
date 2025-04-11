using Dtat;
using Resources;
using Persistence;
using Infrastructure;
using Resources.Messages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ViewModels.Pages.Features.Cms.PostCategories;

namespace Server.Pages.Features.Cms.PostCategories;

//[Infrastructure.Security.CustomAuthorize(minRoleCode:
//	Domain.Features.Identity.Enums.RoleEnum.Administrator)]
public class DeleteModel : BasePageModelWithApplicationDbContext
{
	public DeleteModel(ApplicationDbContext applicationDbContext) : base(applicationDbContext: applicationDbContext)
	{
		ViewModel = new();
	}

	[BindProperty]
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

	public async Task<IActionResult> OnPostAsync(Guid? id)
	{
		if (id is null)
		{
			return RedirectToPage(pageName: Constant.CommonRouting.BadRequest);
		}

		// **************************************************
		var foundedItem =
			await
			ApplicationDbContext.PostCategories
			.Where(current => current.Id == id.Value)
			.FirstOrDefaultAsync();

		if (foundedItem is null)
		{
			return RedirectToPage(pageName: Constant.CommonRouting.NotFound);
		}
		// **************************************************

		// **************************************************
		//var hasAnyChildren =
		//	await
		//	ApplicationDbContext.Posts
		//	.Where(current => current.CategoryId == id.Value)
		//	.AnyAsync();

		//if (hasAnyChildren)
		//{
		//	// **************************************************
		//	var errorMessage = string.Format
		//		(format: Errors.CascadeDelete, arg0: DataDictionary.PostCategory);

		//	AddToastError(message: errorMessage);
		//	// **************************************************

		//	return RedirectToPage(pageName: Constant.CommonRouting.CurrentIndex);
		//}
		// **************************************************

		// **************************************************
		var entityEntry = ApplicationDbContext.Remove(entity: foundedItem);

		var affectedRows =
			await
			ApplicationDbContext.SaveChangesAsync();
		// **************************************************

		// **************************************************
		var successMessage = string.Format
			(format: Successes.Deleted, arg0: DataDictionary.PostCategory);

		AddToastSuccess(message: successMessage);
		// **************************************************

		return RedirectToPage(pageName: Constant.CommonRouting.CurrentIndex);
	}
}
