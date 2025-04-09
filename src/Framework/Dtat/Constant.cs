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
}
