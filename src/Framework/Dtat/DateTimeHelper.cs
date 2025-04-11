namespace Dtat;

public static class DateTimeHelper : object
{
	public static DateTimeOffset Now
	{
		get
		{
			//return System.DateTime.Now;

			//return System.DateTime.UtcNow;

			var currentCulture = Thread.CurrentThread.CurrentCulture;
			var currentUICulture = Thread.CurrentThread.CurrentUICulture;
			var englishCulture = new System.Globalization.CultureInfo(name: "en-US");

			Thread.CurrentThread.CurrentCulture = englishCulture;
			Thread.CurrentThread.CurrentUICulture = englishCulture;

			var result = System.DateTime.Now;
			//var result = System.DateTime.UtcNow;

			Thread.CurrentThread.CurrentCulture = currentCulture;
			Thread.CurrentThread.CurrentUICulture = currentUICulture;

			return result;
		}
	}
}
