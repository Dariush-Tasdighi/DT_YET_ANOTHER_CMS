using Dtat;
using Resources;
using Persistence;
using Infrastructure;
using Resources.Messages;
using Domain.Features.Cms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ViewModels.Pages.Features.Cms.PostCategories;

namespace Server.Pages.Features.Cms.PostCategories;

//[Infrastructure.Security.CustomAuthorize(minRoleCode:
//	Domain.Features.Identity.Enums.RoleEnum.Administrator)]
public class CreateModel : BasePageModelWithApplicationDbContext
{
	public CreateModel(
		ApplicationDbContext applicationDbContext) :
		base(applicationDbContext: applicationDbContext)
	{
		ViewModel = new();
	}

	[BindProperty]
	public CreateViewModel ViewModel { get; set; }

	//public void OnGet()
	//{
	//}

	public async Task OnGetAsync()
	{
		await Task.CompletedTask;
	}

	public async Task<IActionResult> OnPostAsync()
	{
		if (ModelState.IsValid == false)
		{
			return Page();
		}

		// **************************************************
		var name = ViewModel.Name.Fix()!;
		//var name = ViewModel.Name.Fix();

		var isNameFound =
			await
			ApplicationDbContext.PostCategories
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
		//var title = ViewModel.Title.Fix();

		var isTitleFound =
			await
			ApplicationDbContext.PostCategories
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
		var newEntity =
			new PostCategory(name: name, title: title)
			{
				Body = ViewModel.Body.Fix(),
				Description = ViewModel.Description.Fix(),

				ImageUrl = ViewModel.ImageUrl.Fix(),
				CoverImageUrl = ViewModel.CoverImageUrl.Fix(),

				IsActive = ViewModel.IsActive,
				DisplayInHomePage = ViewModel.DisplayInHomePage,

				Hits = ViewModel.Hits,
				Ordering = ViewModel.Ordering,
				MaxPostCountInHomePage = ViewModel.MaxPostCountInHomePage,
				MaxPostCountInMainPage = ViewModel.MaxPostCountInMainPage,
			};

		ApplicationDbContext.Add(entity: newEntity);

		await ApplicationDbContext.SaveChangesAsync();
		// **************************************************

		// **************************************************
		var successMessage = string.Format
			(format: Successes.Created, arg0: DataDictionary.PostCategory);

		AddToastSuccess(message: successMessage);
		// **************************************************

		return RedirectToPage(pageName: Constant.CommonRouting.CurrentIndex);
	}
}
