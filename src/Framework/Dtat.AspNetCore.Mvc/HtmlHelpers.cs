using Dtat;
using System;
using System.Linq;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Dtat.Resources;
using Dtat.AspNetCore.Mvc.TagHelpers;

namespace Dtat.AspNetCore.Mvc;

public static class HtmlHelpers : object
{
	public static IHtmlContent DtatDisplayString(this IHtmlHelper html, string? value)
	{
		if (string.IsNullOrWhiteSpace(value: value))
		{
			return html.Raw(value: Constant.Format.NullValue);
		}

		var result = value.Fix();

		return html.Raw(value: result);
	}

	public static IHtmlContent DtatDisplayInteger(this IHtmlHelper html, long? value)
	{
		if (value is null)
		{
			return html.Raw(value: Constant.Format.NullValue);
		}

		var result = value.Value.ToString(format: Constant.Format.Integer);

		result = result.ConvertDigitsToUnicode();

		return html.Raw(value: result);
	}

	public static IHtmlContent DtatDisplayRowNumberWithTd(this IHtmlHelper html, long? value)
	{
		var td = new TagBuilder(tagName: "td");

		td.AddCssClass(value: "text-center");

		var innerHtml = DtatDisplayInteger(html: html, value: value);

		td.InnerHtml.AppendHtml(content: innerHtml);

		return td;
	}

	public static IHtmlContent DtatDisplayInlineBoolean(this IHtmlHelper html, bool? value)
	{
		if (html is null)
		{
			throw new ArgumentNullException(paramName: nameof(html));
		}

		var result = "<i class='bi bi-square'></i>";

		if (value is not null && value.Value)
		{
			result = "<i class='bi bi bi-check-square'></i>";
		}

		return html.Raw(value: result);

		//var input =
		//	new Microsoft.AspNetCore.Mvc
		//	.Rendering.TagBuilder(tagName: "input");

		//input.Attributes.Add
		//	(key: "type", value: "checkbox");

		//input.Attributes.Add
		//	(key: "disabled", value: "disabled");

		//if (value is not null && value.Value)
		//{
		//	input.Attributes.Add
		//		(key: "checked", value: "checked");
		//}

		//return input;
	}

	public static IHtmlContent DtatDisplayBoolean(this IHtmlHelper html, bool? value)
	{
		if (html is null)
		{
			throw new ArgumentNullException(paramName: nameof(html));
		}

		var div = new TagBuilder(tagName: "div");

		var innerHtml = "<i class='bi bi-square'></i>";

		if (value is not null && value.Value)
		{
			innerHtml = "<i class='bi bi bi-check-square'></i>";
		}

		div.InnerHtml.AppendHtml(encoded: innerHtml);

		//var input =
		//	new Microsoft.AspNetCore.Mvc
		//	.Rendering.TagBuilder(tagName: "input");

		//input.Attributes.Add
		//	(key: "type", value: "checkbox");

		//input.Attributes.Add
		//	(key: "disabled", value: "disabled");

		//if (value is not null && value.Value)
		//{
		//	input.Attributes.Add
		//		(key: "checked", value: "checked");
		//}

		//div.InnerHtml.AppendHtml(content: input);

		return div;
	}

	public static IHtmlContent DtatDisplayStringWithTd
		(this IHtmlHelper html, string? value, bool? isLeftToRight = null)
	{
		var td = new TagBuilder(tagName: "td");

		if (isLeftToRight is not null && isLeftToRight.Value)
		{
			td.Attributes.Add(key: "dir", value: "ltr");
		}

		var innerHtml = DtatDisplayString(html: html, value: value);

		td.InnerHtml.AppendHtml(content: innerHtml);

		return td;
	}

	public static IHtmlContent DtatDisplayBooleanWithTd(this IHtmlHelper html, bool? value)
	{
		var td = new TagBuilder(tagName: "td");

		td.AddCssClass(value: "text-center");

		var innerHtml = DtatDisplayBoolean(html: html, value: value);

		td.InnerHtml.AppendHtml(content: innerHtml);

		return td;
	}

	public static IHtmlContent DtatDisplayIntegerWithTd(this IHtmlHelper html, long? value)
	{
		var td = new TagBuilder(tagName: "td");

		td.Attributes.Add(key: "dir", value: "ltr");

		var innerHtml = DtatDisplayInteger(html: html, value: value);

		td.InnerHtml.AppendHtml(content: innerHtml);

		return td;
	}

	public static IHtmlContent DtatDisplayDateTime(this IHtmlHelper html, System.DateTime? value)
	{
		if (value is null)
		{
			return html.Raw(value: Constant.Format.NullValue);
		}

		var result = value.Value.ToString(format: Constant.Format.DateTime);

		result = result.ConvertDigitsToUnicode();

		return html.Raw(value: result);
	}

	public static IHtmlContent DtatDisplayDateOffset(this IHtmlHelper html, DateTimeOffset? value)
	{
		if (value is null)
		{
			return html.Raw(value: Constant.Format.NullValue);
		}

		var result = value.Value.ToString(format: Constant.Format.Date);

		result = result.ConvertDigitsToUnicode();

		return html.Raw(value: result);
	}

	public static IHtmlContent DtatDisplayDateTimeOffset(this IHtmlHelper html, DateTimeOffset? value)
	{
		if (value is null)
		{
			return html.Raw(value: Constant.Format.NullValue);
		}

		var result = value.Value.ToString(format: Constant.Format.DateTime);

		result = result.ConvertDigitsToUnicode();

		return html.Raw(value: result);
	}

	public static IHtmlContent DtatDisplayDateTimeWithTd(this IHtmlHelper html, DateTime? value)
	{
		var td = new TagBuilder(tagName: "td");

		td.Attributes.Add(key: "dir", value: "ltr");

		var innerHtml = DtatDisplayDateTime(html: html, value: value);

		td.InnerHtml.AppendHtml(content: innerHtml);

		return td;
	}

	public static IHtmlContent DtatDisplayDateTimeOffsetWithTd(this IHtmlHelper html, DateTimeOffset? value)
	{
		var td = new TagBuilder(tagName: "td");

		td.Attributes.Add(key: "dir", value: "ltr");

		var innerHtml = DtatDisplayDateTimeOffset(html: html, value: value);

		td.InnerHtml.AppendHtml(content: innerHtml);

		return td;
	}

	public static IHtmlContent DtatGetLinkCaptionForList(this IHtmlHelper html)
	{
		if (html is null)
		{
			throw new ArgumentNullException(paramName: nameof(html));
		}

		var icon = TagHelpers.Utility.GetIconList();

		var span = new TagBuilder(tagName: "span");

		span.AddCssClass(value: "mx-1");

		span.InnerHtml.Append(unencoded: "[");
		span.InnerHtml.Append(unencoded: " ");
		span.InnerHtml.AppendHtml(content: icon);
		span.InnerHtml.Append(unencoded: DataDictionary.BackToList);
		span.InnerHtml.Append(unencoded: " ");
		span.InnerHtml.Append(unencoded: "]");

		return span;
	}

	public static IHtmlContent DtatGetLinkCaptionForDetails(this IHtmlHelper html)
	{
		if (html is null)
		{
			throw new ArgumentNullException(paramName: nameof(html));
		}

		var icon = TagHelpers.Utility.GetIconDetails();

		var span = new TagBuilder(tagName: "span");

		span.AddCssClass(value: "mx-1");

		span.InnerHtml.Append(unencoded: "[");
		span.InnerHtml.Append(unencoded: " ");
		span.InnerHtml.AppendHtml(content: icon);
		span.InnerHtml.Append(unencoded: DataDictionary.Details);
		span.InnerHtml.Append(unencoded: " ");
		span.InnerHtml.Append(unencoded: "]");

		return span;
	}

	public static IHtmlContent DtatGetLinkCaptionForCreate(this IHtmlHelper html)
	{
		if (html is null)
		{
			throw new ArgumentNullException(paramName: nameof(html));
		}

		var icon = TagHelpers.Utility.GetIconCreate();

		var span = new TagBuilder(tagName: "span");

		//span.AddCssClass(value: "mx-1");

		//span.InnerHtml.Append(unencoded: "[");
		//span.InnerHtml.Append(unencoded: " ");
		span.InnerHtml.AppendHtml(content: icon);
		span.InnerHtml.Append(unencoded: DataDictionary.Create);
		//span.InnerHtml.Append(unencoded: " ");
		//span.InnerHtml.Append(unencoded: "]");

		return span;
	}

	public static IHtmlContent DtatGetLinkCaptionForUpdate(this IHtmlHelper html)
	{
		if (html is null)
		{
			throw new ArgumentNullException(paramName: nameof(html));
		}

		var icon = TagHelpers.Utility.GetIconUpdate();

		var span = new TagBuilder(tagName: "span");

		span.AddCssClass(value: "mx-1");

		span.InnerHtml.Append(unencoded: "[");
		span.InnerHtml.Append(unencoded: " ");
		span.InnerHtml.AppendHtml(content: icon);
		span.InnerHtml.Append(unencoded: DataDictionary.Update);
		span.InnerHtml.Append(unencoded: " ");
		span.InnerHtml.Append(unencoded: "]");

		return span;
	}

	public static IHtmlContent DtatGetLinkCaptionForUpdateInformationsAgain(this IHtmlHelper html)
	{
		if (html is null)
		{
			throw new ArgumentNullException(paramName: nameof(html));
		}

		var icon = TagHelpers.Utility.GetIconReset();

		var span = new TagBuilder(tagName: "span");

		span.AddCssClass(value: "mx-1");

		span.InnerHtml.Append(unencoded: "[");
		span.InnerHtml.Append(unencoded: " ");
		span.InnerHtml.AppendHtml(content: icon);
		span.InnerHtml.Append(unencoded: DataDictionary.UpdateInformationAgain);
		span.InnerHtml.Append(unencoded: " ");
		span.InnerHtml.Append(unencoded: "]");

		return span;
	}

	public static IHtmlContent DtatGetLinkCaptionForDelete(this IHtmlHelper html)
	{
		if (html is null)
		{
			throw new ArgumentNullException(paramName: nameof(html));
		}

		var icon = TagHelpers.Utility.GetIconDelete();

		var span = new TagBuilder(tagName: "span");

		span.AddCssClass(value: "mx-1");

		span.InnerHtml.Append(unencoded: "[");
		span.InnerHtml.Append(unencoded: " ");
		span.InnerHtml.AppendHtml(content: icon);
		span.InnerHtml.Append(unencoded: DataDictionary.Delete);
		span.InnerHtml.Append(unencoded: " ");
		span.InnerHtml.Append(unencoded: "]");

		return span;
	}

	public static IHtmlContent DtatGetIconDetails(this IHtmlHelper html)
	{
		if (html is null)
		{
			throw new ArgumentNullException(paramName: nameof(html));
		}

		var icon = TagHelpers.Utility.GetIconDetails();

		return icon;
	}

	public static IHtmlContent DtatGetIconDisplay(this IHtmlHelper html)
	{
		if (html is null)
		{
			throw new ArgumentNullException(paramName: nameof(html));
		}

		var icon = TagHelpers.Utility.GetIconDisplay();

		return icon;
	}

	public static IHtmlContent DtatGetIconCreate(this IHtmlHelper html)
	{
		if (html is null)
		{
			throw new ArgumentNullException(paramName: nameof(html));
		}

		var icon = TagHelpers.Utility.GetIconCreate();

		return icon;
	}

	public static IHtmlContent DtatGetIconUpdate(this IHtmlHelper html)
	{
		if (html is null)
		{
			throw new ArgumentNullException(paramName: nameof(html));
		}

		var icon = TagHelpers.Utility.GetIconUpdate();

		return icon;
	}

	public static IHtmlContent DtatGetIconDelete(this IHtmlHelper html)
	{
		if (html is null)
		{
			throw new ArgumentNullException(paramName: nameof(html));
		}

		var icon = TagHelpers.Utility.GetIconDelete();

		return icon;
	}

	public static IHtmlContent DtatGetIconCustom(this IHtmlHelper html, string iconName)
	{
		if (html is null)
		{
			throw new ArgumentNullException(paramName: nameof(html));
		}

		var icon = Utility.GetIconCustom(iconName: iconName);

		return icon;
	}

	public static SelectList DtatGetEnumSelectList<TEnum>
		(this IHtmlHelper html, int? selectedValue = null) where TEnum : struct
	{
		var list = html.GetEnumSelectList<TEnum>().ToList();

		// **************************************************
		var emptySelectListItem = new SelectListItem
			(text: DataDictionary.SelectAnItem, value: string.Empty);

		list.Insert(index: 0, item: emptySelectListItem);
		// **************************************************

		var result = new SelectList
			(items: list, selectedValue: selectedValue,
			dataTextField: nameof(SelectListItem.Text),
			dataValueField: nameof(SelectListItem.Value));

		return result;
	}
}
