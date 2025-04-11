using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Dtat.AspNetCore.Mvc.Messages;

public static class Utility : object
{
	public static bool AddMessage
		(ITempDataDictionary tempData, MessageType type, string? message)
	{
		message = message.Fix();

		if (message is null)
		{
			return false;
		}

		// **************************************************
		// به دلایل خیلی زیادی، کد ذیل، به صورتی که ملاحظه می‌کنید
		// نوشته شده است، لذا در آن، هیچ‌گونه تغییری اعمال نکنید
		// **************************************************
		List<string>? list;

		// TODO ?????
		//var tempDataItems =
		//	(tempData[key: type.ToString()] as IList<string>);

		var tempDataItems =
			tempData[key: type.ToString()] as IList<string>;

		if (tempDataItems is null)
		{
			list = [];
		}
		else
		{
			list = tempDataItems as List<string>;

			//if (list is null)
			//{
			//	list = tempDataItems.ToList();
			//}

			//list ??= tempDataItems.ToList();

			list ??= [.. tempDataItems];
		}

		tempData[key: type.ToString()] = list;
		// **************************************************

		if (list.Contains(item: message))
		{
			return false;
		}

		list.Add(item: message);

		return true;
	}
}
