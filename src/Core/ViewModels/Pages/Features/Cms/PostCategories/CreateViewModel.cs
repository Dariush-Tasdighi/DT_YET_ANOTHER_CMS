using Dtat;
using Resources;
using System.ComponentModel.DataAnnotations;

namespace ViewModels.Pages.Features.Cms.PostCategories;

public class CreateViewModel : object
{
	public CreateViewModel() : base()
	{
		Ordering = 10_000;
		MaxPostCountInHomePage = 12;
		MaxPostCountInMainPage = 48;
	}

	#region public bool IsActive { get; set; }
	/// <summary>
	/// وضعیت
	/// </summary>
	[Display(
		ResourceType = typeof(DataDictionary),
		Name = nameof(DataDictionary.IsActive))]
	public bool IsActive { get; set; }
	#endregion /public bool IsActive { get; set; }

	#region public int Ordering { get; set; }
	/// <summary>
	/// چیدمان
	/// </summary>
	[Display(
		ResourceType = typeof(DataDictionary),
		Name = nameof(DataDictionary.Ordering))]

	[Required(
		AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]

	[Range(
		minimum: 1, maximum: 100_000,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.Range))]
	public int Ordering { get; set; }
	#endregion /public int Ordering { get; set; }



	#region public string? Name { get; set; }
	/// <summary>
	/// نام
	/// </summary>
	[Display(
		ResourceType = typeof(DataDictionary),
		Name = nameof(DataDictionary.Name))]

	[Required(
		AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]

	[MaxLength(
		length: Constant.MaxLength.Name,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]

	[System.ComponentModel.DataAnnotations.RegularExpression(
		pattern: Constant.RegularExpression.AToZDigitsUnderline,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.Name))]
	public string? Name { get; set; }
	#endregion /public string? Name { get; set; }

	#region public string? Title { get; set; }
	/// <summary>
	/// عنوان
	/// </summary>
	[Display(
		ResourceType = typeof(DataDictionary),
		Name = nameof(DataDictionary.Title))]

	[Required(
		AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]

	[MaxLength(
		length: Constant.MaxLength.Title,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]
	public string? Title { get; set; }
	#endregion /public string? Title { get; set; }

	#region public string? Description { get; set; }
	/// <summary>
	/// توضیحات
	/// </summary>
	[Display(
		ResourceType = typeof(DataDictionary),
		Name = nameof(DataDictionary.Description))]

	[MaxLength(
		length: Constant.MaxLength.MetaDescription,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]
	public string? Description { get; set; }
	#endregion /public string? Description { get; set; }



	#region public string? ImageUrl { get; set; }
	/// <summary>
	/// نشانی تصویر
	/// </summary>
	[Display(
		ResourceType = typeof(DataDictionary),
		Name = nameof(DataDictionary.ImageUrl))]
	public string? ImageUrl { get; set; }
	#endregion /public string? ImageUrl { get; set; }

	#region public string? CoverImageUrl { get; set; }
	/// <summary>
	/// نشانی تصویر کاور
	/// </summary>
	[Display(
		ResourceType = typeof(DataDictionary),
		Name = nameof(DataDictionary.CoverImageUrl))]
	public string? CoverImageUrl { get; set; }
	#endregion /public string? CoverImageUrl { get; set; }



	#region public int MaxPostCountInMainPage { get; set; }
	/// <summary>
	/// حداکثر تعداد مطالب در صفحه اصلی
	/// </summary>
	[Display(
		ResourceType = typeof(DataDictionary),
		Name = nameof(DataDictionary.MaxPostCountInMainPage))]

	[Required(
		AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]
	public int MaxPostCountInMainPage { get; set; }
	#endregion /public int MaxPostCountInMainPage { get; set; }

	#region public bool DisplayInHomePage { get; set; }
	/// <summary>
	/// نمایش در صفحه اول / خانه
	/// </summary>
	[Display(
		ResourceType = typeof(DataDictionary),
		Name = nameof(DataDictionary.DisplayInHomePage))]
	public bool DisplayInHomePage { get; set; }
	#endregion /public bool DisplayInHomePage { get; set; }

	#region public int MaxPostCountInHomePage { get; set; }
	/// <summary>
	/// حداکثر تعداد مطالب در صفحه اول سایت / خانه
	/// </summary>
	[Display(
		ResourceType = typeof(DataDictionary),
		Name = nameof(DataDictionary.MaxPostCountInHomePage))]

	[Required(
		AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]
	public int MaxPostCountInHomePage { get; set; }
	#endregion /public int MaxPostCountInHomePage { get; set; }



	#region public int Hits { get; set; }
	/// <summary>
	/// تعداد دفعات بازدید
	/// </summary>
	[Display(
		ResourceType = typeof(DataDictionary),
		Name = nameof(DataDictionary.Hits))]

	[Required(
		AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]
	public int Hits { get; set; }
	#endregion /public int Hits { get; set; }



	#region public string? Body { get; set; }
	/// <summary>
	/// متن اصلی
	/// </summary>
	[Display(
		ResourceType = typeof(DataDictionary),
		Name = nameof(DataDictionary.Body))]
	public string? Body { get; set; }
	#endregion /public string? Body { get; set; }
}
