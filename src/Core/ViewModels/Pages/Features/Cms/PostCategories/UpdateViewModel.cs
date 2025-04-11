using System;
using Resources;
using System.ComponentModel.DataAnnotations;

namespace ViewModels.Pages.Features.Cms.PostCategories;

public class UpdateViewModel : CreateViewModel
{
	public UpdateViewModel() : base()
	{
	}

	#region public Guid Id { get; set; }
	/// <summary>
	/// شناسه
	/// </summary>
	[Display(
		ResourceType = typeof(DataDictionary),
		Name = nameof(DataDictionary.Id))]
	public Guid Id { get; set; }
	#endregion /public Guid Id { get; set; }
}
