using Domain.Seedwork;
using Dtat.Seedwork.Abstractions;

namespace Domain.Features.Common;

public class ApplicationSetting : Entity,
	IEntityHasUpdateDateTime
{
	public ApplicationSetting() : base()
	{
		//DigitCountInCaptchaImage = 4;
		//FavoriteUserProfileLevel = 0;

		//Theme = Cms.Enums.ThemeEnum.Ligth;
		Theme = "black";

		//LoginOption = Enums.LoginOptionEnum.Both;

		UpdateDateTime = InsertDateTime;
	}

	public string? Copyright { get; set; }
	public string? ApplicationVersioin { get; set; }

	///// <summary>
	///// گذرواژه اصلی / شاه کلید
	///// </summary>
	//[System.ComponentModel.DataAnnotations.Display
	//	(ResourceType = typeof(Resources.DataDictionary),
	//	Name = nameof(Resources.DataDictionary.MasterPassword))]
	//public string? MasterPassword { get; set; }

	/// <summary>
	/// Google Analytics Code
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display(Name = "Google Analytics Code")]
	public string? GoogleAnalyticsCode { get; set; }

	/// <summary>
	/// Google Tag Manager Code
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display(Name = "Google Tag Manager Code")]
	public string? GoogleTagManagerCode { get; set; }

	///// <summary>
	///// سطح مورد نظر برای پروفایل کاربر
	///// </summary>
	//[System.ComponentModel.DataAnnotations.Display
	//	(ResourceType = typeof(Resources.DataDictionary),
	//	Name = nameof(Resources.DataDictionary.FavoriteUserProfileLevel))]

	//[System.ComponentModel.DataAnnotations.Required
	//	(AllowEmptyStrings = false,
	//	ErrorMessageResourceType = typeof(Resources.Messages.Validations),
	//	ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]
	//public int FavoriteUserProfileLevel { get; set; }

	///// <summary>
	///// تم پیش‌فرض سامانه
	///// </summary>
	//[System.ComponentModel.DataAnnotations.Display
	//	(ResourceType = typeof(Resources.DataDictionary),
	//	Name = nameof(Resources.DataDictionary.Theme))]

	//[System.ComponentModel.DataAnnotations.Required
	//	(AllowEmptyStrings = false,
	//	ErrorMessageResourceType = typeof(Resources.Messages.Validations),
	//	ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]
	//public Cms.Enums.ThemeEnum Theme { get; set; }

	[System.ComponentModel.DataAnnotations.Required
	(AllowEmptyStrings = false,
	ErrorMessageResourceType = typeof(Resources.Messages.Validations),
	ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]
	public string Theme { get; set; }

	///// <summary>
	///// تنوع ورود به سامانه
	///// </summary>
	//[System.ComponentModel.DataAnnotations.Display
	//	(ResourceType = typeof(Resources.DataDictionary),
	//	Name = nameof(Resources.DataDictionary.LoginOption))]

	//[System.ComponentModel.DataAnnotations.Required
	//	(AllowEmptyStrings = false,
	//	ErrorMessageResourceType = typeof(Resources.Messages.Validations),
	//	ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]
	//public Enums.LoginOptionEnum LoginOption { get; set; }

	///// <summary>
	///// نمایش ورود به سامانه
	///// </summary>
	//[System.ComponentModel.DataAnnotations.Display
	//	(ResourceType = typeof(Resources.DataDictionary),
	//	Name = nameof(Resources.DataDictionary.IsLoginVisible))]
	//public bool IsLoginVisible { get; set; }

	///// <summary>
	///// ثبت‌نام فعال است
	///// </summary>
	//[System.ComponentModel.DataAnnotations.Display
	//	(ResourceType = typeof(Resources.DataDictionary),
	//	Name = nameof(Resources.DataDictionary.IsContactUsEnabled))]
	//public bool IsContactUsEnabled { get; set; }

	///// <summary>
	///// امکان ثبت‌نام
	///// </summary>
	//[System.ComponentModel.DataAnnotations.Display
	//	(ResourceType = typeof(Resources.DataDictionary),
	//	Name = nameof(Resources.DataDictionary.IsRegistrationEnabled))]
	//public bool IsRegistrationEnabled { get; set; }

	///// <summary>
	///// امکان جستجوی مطالب در منوی سایت
	///// </summary>
	//[System.ComponentModel.DataAnnotations.Display
	//	(ResourceType = typeof(Resources.DataDictionary),
	//	Name = nameof(Resources.DataDictionary.IsSearchInNavbarEnabled))]
	//public bool IsSearchInNavbarEnabled { get; set; }

	///// <summary>
	///// فعال‌سازی خودکار کاربر بعد از ثبت‌نام
	///// </summary>
	//[System.ComponentModel.DataAnnotations.Display
	//	(ResourceType = typeof(Resources.DataDictionary),
	//	Name = nameof(Resources.DataDictionary.ActivateUserAfterRegistration))]
	//public bool ActivateUserAfterRegistration { get; set; }

	///// <summary>
	///// امکان ورود به سامانه از طریق گوگل
	///// </summary>
	//[System.ComponentModel.DataAnnotations.Display
	//	(ResourceType = typeof(Resources.DataDictionary),
	//	Name = nameof(Resources.DataDictionary.IsGoogleAuthenticationEnabled))]
	//public bool IsGoogleAuthenticationEnabled { get; set; }



	///// <summary>
	///// فعال‌سازی کد امنیتی
	///// </summary>
	//[System.ComponentModel.DataAnnotations.Display
	//	(ResourceType = typeof(Resources.DataDictionary),
	//	Name = nameof(Resources.DataDictionary.IsCaptchaImageEnabled))]
	//public bool IsCaptchaImageEnabled { get; set; }

	///// <summary>
	///// تعداد ارقام در کد امنیتی
	///// </summary>
	//[System.ComponentModel.DataAnnotations.Display
	//	(ResourceType = typeof(Resources.DataDictionary),
	//	Name = nameof(Resources.DataDictionary.DigitCountInCaptchaImage))]

	//[System.ComponentModel.DataAnnotations.Required
	//	(AllowEmptyStrings = false,
	//	ErrorMessageResourceType = typeof(Resources.Messages.Validations),
	//	ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]

	//[System.ComponentModel.DataAnnotations.Range
	//	(minimum: 4, maximum: 8,
	//	ErrorMessageResourceType = typeof(Resources.Messages.Validations),
	//	ErrorMessageResourceName = nameof(Resources.Messages.Validations.Range))]
	//public int DigitCountInCaptchaImage { get; set; }



	/// <summary>
	/// زمان ویرایش
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.UpdateDateTime))]

	[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
		(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
	public System.DateTimeOffset UpdateDateTime { get; private set; }



	public string ThemeName
	{
		get
		{
			var result =
				Theme.ToString().ToLower();

			return result;
		}
	}

	public void SetUpdateDateTime()
	{
		UpdateDateTime = Dtat.DateTime.Now;
	}
}
