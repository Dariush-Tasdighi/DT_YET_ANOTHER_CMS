using Dtat;
using Resources;
using Persistence;
using Infrastructure;
using Resources.Messages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ViewModels.Pages.Features.Cms.PostCategories;

namespace Server.Pages.Features.Cms.Admin.PostCategories;

//[Infrastructure.Security.CustomAuthorize(minRoleCode:
//	Domain.Features.Identity.Enums.RoleEnum.Administrator)]
public class UpdateModel : BasePageModelWithApplicationDbContext
{
	public UpdateModel(
		ApplicationDbContext applicationDbContext) :
		base(applicationDbContext: applicationDbContext)
	{
		ViewModel = new();
	}

	[BindProperty]
	public UpdateViewModel ViewModel { get; set; }

	//public async Task<IActionResult> OnGetAsync(Guid id)
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
			.Select(current => new UpdateViewModel
			{
				Id = current.Id,
				Body = current.Body,
				Hits = current.Hits,
				Name = current.Name,
				Title = current.Title,
				ImageUrl = current.ImageUrl,
				IsActive = current.IsActive,
				Ordering = current.Ordering,
				Description = current.Description,
				CoverImageUrl = current.CoverImageUrl,
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

	public async Task<IActionResult> OnPostAsync()
	{
		if (ModelState.IsValid == false)
		{
			return Page();
		}

		// **************************************************
		var foundedItem =
			await
			ApplicationDbContext.PostCategories
			.Where(current => current.Id == ViewModel.Id)
			.FirstOrDefaultAsync();

		if (foundedItem is null)
		{
			return RedirectToPage(pageName: Constant.CommonRouting.NotFound);
		}
		// **************************************************

		// **************************************************
		var name = ViewModel.Name.Fix()!;

		var isNameFound =
			await
			ApplicationDbContext.PostCategories
			.Where(current => current.Id != ViewModel.Id)
			.Where(current => current.Name.ToLower() == name.ToLower())
			.AnyAsync();

		if (isNameFound)
		{
			var errorMessage = string.Format
				(format: Errors.AlreadyExists, arg0: DataDictionary.Name);

			AddPageError(message: errorMessage);
		}
		// **************************************************

		// **************************************************
		var title = ViewModel.Title.Fix()!;

		var isTitleFound =
			await
			ApplicationDbContext.PostCategories
			.Where(current => current.Id != ViewModel.Id)
			.Where(current => current.Title.ToLower() == title.ToLower())
			.AnyAsync();

		if (isTitleFound)
		{
			var errorMessage = string.Format
				(format: Errors.AlreadyExists, arg0: DataDictionary.Title);

			AddPageError(message: errorMessage);
		}
		// **************************************************

		if (isNameFound || isTitleFound)
		{
			return Page();
		}

		// **************************************************
		//foundedItem.SetUpdateDateTime(); // TODO

		foundedItem.Name = name;
		foundedItem.Title = title;

		foundedItem.Hits = ViewModel.Hits;
		foundedItem.Ordering = ViewModel.Ordering;

		foundedItem.Body = ViewModel.Body.Fix();
		foundedItem.ImageUrl = ViewModel.ImageUrl.Fix();
		foundedItem.Description = ViewModel.Description.Fix();
		foundedItem.CoverImageUrl = ViewModel.CoverImageUrl.Fix();

		foundedItem.IsActive = ViewModel.IsActive;
		foundedItem.DisplayInHomePage = ViewModel.DisplayInHomePage;

		foundedItem.MaxPostCountInHomePage = ViewModel.MaxPostCountInHomePage;
		foundedItem.MaxPostCountInMainPage = ViewModel.MaxPostCountInMainPage;
		// **************************************************

		await ApplicationDbContext.SaveChangesAsync();

		// **************************************************
		var successMessage = string.Format
			(format: Successes.Updated, arg0: DataDictionary.PostCategory);

		AddToastSuccess(message: successMessage);
		// **************************************************

		return RedirectToPage(pageName: Constant.CommonRouting.CurrentIndex);
	}
}
