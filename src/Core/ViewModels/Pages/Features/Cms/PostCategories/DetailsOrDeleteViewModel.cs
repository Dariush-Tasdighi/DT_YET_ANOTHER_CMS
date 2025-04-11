using Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModels.Pages.Features.Cms.PostCategories;

public class DetailsOrDeleteViewModel : UpdateViewModel
{
	public DetailsOrDeleteViewModel() : base()
	{
	}

	#region public int PostCount { get; set; }
	/// <summary>
	/// تعداد مطالب
	/// </summary>
	[Display(
		ResourceType = typeof(DataDictionary),
		Name = nameof(DataDictionary.PostCount))]
	public int PostCount { get; set; }
	#endregion /public int PostCount { get; set; }

	#region public DateTimeOffset InsertDateTime { get; set; }
	/// <summary>
	/// زمان ایجاد
	/// </summary>
	[Display
		(ResourceType = typeof(DataDictionary),
		Name = nameof(DataDictionary.InsertDateTime))]
	public DateTimeOffset InsertDateTime { get; set; }
	#endregion /public DateTimeOffset InsertDateTime { get; set; }

	#region public DateTimeOffset UpdateDateTime { get; set; }
	/// <summary>
	/// زمان ویرایش
	/// </summary>
	[Display
		(ResourceType = typeof(DataDictionary),
		Name = nameof(DataDictionary.UpdateDateTime))]
	public DateTimeOffset UpdateDateTime { get; set; }
	#endregion /public DateTimeOffset UpdateDateTime { get; set; }
}
