namespace Dtat;

public static class Constant : object
{
	public static class MaxLength : object
	{
		public const int Link = 500;
		public const int Path = 200;

		public const int Color = 7;
		public const int Icon = 100;

		public const int IP = 15;
		public const int Url = 256;
		public const int Name = 100;
		public const int Title = 100;
		public const int Prefix = 100;
		public const int KeyName = 100;

		public const int NativeName = 50;
		public const int CultureName = 5;

		public const int EmailBody = 4000;
		public const int EmailSubject = 100;

		public const int MetaTitle = 70;
		public const int MetaAuthor = 50;
		public const int MetaKeywords = 200;
		public const int MetaDescription = 150;

		public const int Username = 20;
		public const int Password = 20;
		public const int LastName = 50;
		public const int FirstName = 50;
		public const int FullName = 100;
		public const int EmailAddress = 254;
		public const int CellPhoneNumber = 14;

		public const int CellPhoneNumberVerificationKey = 10;
	}

	public static class Range : object
	{
		public const int OrderingMinimum = 1;
		public const int OrderingMaximum = 100_000;
	}

	public static class RegularExpression : object
	{
		public const string Theme = @"^[a-z][a-z_]*$";
		public const string Color = @"^#[a-fA-F0-9]{4,7}$"; // #fff #11C79F

		public const string JustDigits = @"^[0-9]+$";
		public const string PostalCode = @"^\d{10}$";
		public const string NationalCode = @"^\d{10}$";
		public const string CellPhoneNumber = @"^09\d{9}$";
		public const string AToZDigitsUnderline = @"^[a-zA-Z][a-zA-Z0-9_]*$";

		public const string Username = @"^[a-zA-Z0-9_]{6,20}$";
		public const string Password = @"^[a-zA-Z0-9_!@#$%^&]{8,20}$";
		public const string EmailAddress = @"^[a-zA-Z0-9_.-]+@[a-zA-Z0-9_.-]+$";
		public const string UsernameOrEmailAddress = @"^[a-zA-Z0-9_@.]{6,254}$";

		public const string IP = @"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";
		public const string Url = @"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)";
	}

	public static class Format : object
	{
		public const string Integer = "#,##0";
		public const string NullValue = "-----";

		public const string Time = "HH:mm:ss";
		public const string Date = "yyyy/MM/dd";
		public const string DateTime = "yyyy/MM/dd - HH:mm:ss";

		//	public static string NullValue
		//	{
		//		get
		//		{
		//			//return null;
		//			//return "-----";
		//			//return string.Empty;

		//			return "<i class='bi bi-patch-question'></i>";
		//		}
		//	}

		//	public static string Integer
		//	{
		//		get
		//		{
		//			return "#,##0";
		//		}
		//	}

		//	public static string Time
		//	{
		//		get
		//		{
		//			return "HH:mm:ss";
		//		}
		//	}

		//	public static string Date
		//	{
		//		get
		//		{
		//			return "yyyy/MM/dd";
		//		}
		//	}

		//	public static string DateTime
		//	{
		//		get
		//		{
		//			return $"{Date} - {Time}";
		//		}
		//	}
	}

	public static class TagHelper : object
	{
		public const string Prefix = "dtat-";

		public const string Label = Prefix + "simple-label";
		public const string Input = Prefix + "simple-input";
		public const string CheckBox = Prefix + "simple-checkbox";
		public const string TextArea = Prefix + "simple-textarea";

		public const string FullInput = Prefix + "full-input";
		public const string FullSelect = Prefix + "full-select";
		public const string FullCheckBox = Prefix + "full-checkbox";
		public const string FullTextArea = Prefix + "full-textarea";
		public const string FullPasswordInput = Prefix + "full-password-input";

		public const string ReadOnlyInput = Prefix + "readonly-input";
		public const string ReadOnlyCheckBox = Prefix + "readonly-checkbox";
		public const string ReadOnlyTextArea = Prefix + "readonly-textarea";
	}

	public static class CommonRouting : object
	{
		/// <summary>
		/// Error 404
		/// </summary>
		public const string NotFound = "/Errors/Error404";

		/// <summary>
		/// Error 403
		/// </summary>
		public const string Forbidden = "/Errors/Error403";

		/// <summary>
		/// Error 400
		/// </summary>
		public const string BadRequest = "/Errors/Error400";

		/// <summary>
		/// Error 500
		/// </summary>
		public const string InternalServerError = "/Errors/Error500";



		/// <summary>
		/// Root Index
		/// </summary>
		public const string RootIndex = "/Index";

		/// <summary>
		/// Current Index
		/// </summary>
		public const string CurrentIndex = "Index";

		/// <summary>
		/// Dashboard
		/// </summary>
		public const string Dashboard = "/Dashboard";

		/// <summary>
		/// Login
		/// </summary>
		public const string Login = "/Account/Login";

		/// <summary>
		/// Logout
		/// </summary>
		public const string Logout = "/Account/Logout";

		/// <summary>
		/// Google Login
		/// </summary>
		public const string GoogleLogin = "/Google/Login";

		/// <summary>
		/// Register
		/// </summary>
		public const string Register = "/Account/Register";

		/// <summary>
		/// Send Again Email Address Verification Key
		/// </summary>
		public const string
			SendAgainEmailAddressVerificationKey =
			"/Account/SendAgainEmailAddressVerificationKey";
	}

	public static class ViewDataKeyName : object
	{
		static ViewDataKeyName()
		{
		}

		public static string LayoutId
		{
			get
			{
				return "LayoutId";
			}
		}

		public static string PageTitle
		{
			get
			{
				return "PageTitle";
			}
		}

		public static string PageAuthor
		{
			get
			{
				return "PageAuthor";
			}
		}

		public static string PageImageUrl
		{
			get
			{
				return "PageImageUrl";
			}
		}

		public static string PageKeywords
		{
			get
			{
				return "PageKeywords";
			}
		}

		public static string PageDescription
		{
			get
			{
				return "PageDescription";
			}
		}

		public static string IgnoreRichTextBox
		{
			get
			{
				return "IgnoreRichTextBox";
			}
		}
	}
}
