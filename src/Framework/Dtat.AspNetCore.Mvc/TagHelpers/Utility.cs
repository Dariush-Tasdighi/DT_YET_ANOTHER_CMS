using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dtat.AspNetCore.Mvc.TagHelpers;

public static class Utility : object
{
	public static TagBuilder GetIconList()
	{
		var icon = new TagBuilder(tagName: "i");

		icon.AddCssClass(value: "mx-1");
		icon.AddCssClass(value: "bi");
		icon.AddCssClass(value: "bi-card-list");

		return icon;
	}

	public static TagBuilder GetIconDetails()
	{
		var icon = new TagBuilder(tagName: "i");

		icon.AddCssClass(value: "mx-1");
		icon.AddCssClass(value: "bi");
		icon.AddCssClass(value: "bi-zoom-in");

		return icon;
	}

	public static TagBuilder GetIconDisplay()
	{
		var icon = new TagBuilder(tagName: "i");

		icon.AddCssClass(value: "mx-1");
		icon.AddCssClass(value: "bi");
		icon.AddCssClass(value: "bi-eye");

		return icon;
	}

	public static TagBuilder GetIconCreate()
	{
		var icon = new TagBuilder(tagName: "i");

		icon.AddCssClass(value: "mx-1");
		icon.AddCssClass(value: "bi");
		icon.AddCssClass(value: "bi-plus-square");

		return icon;
	}

	public static TagBuilder GetIconUpdate()
	{
		var icon = new TagBuilder(tagName: "i");

		icon.AddCssClass(value: "mx-1");
		icon.AddCssClass(value: "bi");
		icon.AddCssClass(value: "bi-pencil-fill");

		return icon;
	}

	public static TagBuilder GetIconDelete()
	{
		var icon = new TagBuilder(tagName: "i");

		icon.AddCssClass(value: "mx-1");
		icon.AddCssClass(value: "bi");
		icon.AddCssClass(value: "bi-trash");

		return icon;
	}

	public static TagBuilder GetIconReset()
	{
		var icon = new TagBuilder(tagName: "i");

		icon.AddCssClass(value: "mx-1");
		icon.AddCssClass(value: "bi");
		icon.AddCssClass(value: "bi-repeat");

		return icon;
	}

	public static TagBuilder GetIconSend()
	{
		var icon = new TagBuilder(tagName: "i");

		icon.AddCssClass(value: "mx-1");
		icon.AddCssClass(value: "bi");
		icon.AddCssClass(value: "bi-send");

		return icon;
	}

	public static TagBuilder GetIconSearch()
	{
		var icon = new TagBuilder(tagName: "i");

		icon.AddCssClass(value: "mx-1");
		icon.AddCssClass(value: "bi");
		icon.AddCssClass(value: "bi-search");

		return icon;
	}

	public static TagBuilder GetIconSubmit()
	{
		var icon = new TagBuilder(tagName: "i");

		icon.AddCssClass(value: "mx-1");
		icon.AddCssClass(value: "bi");
		icon.AddCssClass(value: "bi-hand-thumbs-up");

		return icon;
	}

	public static TagBuilder GetIconCustom(string iconName)
	{
		var icon = new TagBuilder(tagName: "i");

		icon.AddCssClass(value: "mx-1");
		icon.AddCssClass(value: "bi");
		icon.AddCssClass(value: iconName);

		return icon;
	}

	public static void CreateOrMergeAttribute
		(string name, object content, TagHelperOutput output)
	{
		var currentAttribute =
			output.Attributes
			.Where(current => current.Name == name)
			.FirstOrDefault();

		if (currentAttribute is null)
		{
			var attribute = new TagHelperAttribute(name: name, value: content);

			output.Attributes.Add(attribute: attribute);
		}
		else
		{
			var value = $"{currentAttribute.Value} {content}";

			var newAttribute = new TagHelperAttribute
				(name: name, value: value, valueStyle: currentAttribute.ValueStyle);

			output.Attributes.Remove(attribute: currentAttribute);

			output.Attributes.Add(attribute: newAttribute);
		}
	}

	public static async Task<string> GenerateLabelAsync(
		IHtmlGenerator generator, ViewContext viewContext,
		ModelExpression @for, string? cssClass = null)
	{
		var tagBuilder = generator.GenerateLabel(
			viewContext: viewContext, modelExplorer: @for.ModelExplorer,
			expression: @for.Name, labelText: null, htmlAttributes: null);

		if (cssClass is null)
		{
			tagBuilder.AddCssClass(value: "form-label");
		}
		else
		{
			tagBuilder.AddCssClass(value: cssClass);
		}

		var writer = new StringWriter();

		tagBuilder.WriteTo(writer: writer, encoder: NullHtmlEncoder.Default);

		var result = writer.ToString();

		await writer.DisposeAsync();

		return result;
	}

	public static async Task<string> GenerateTextBoxAsync(
		IHtmlGenerator generator, ViewContext viewContext,
		ModelExpression @for, bool readOnly = false, string? dir = null)
	{
		var tagBuilder = generator.GenerateTextBox(
			viewContext: viewContext, modelExplorer: @for.ModelExplorer,
			expression: @for.Name, value: @for.Model, format: null, htmlAttributes: null);

		tagBuilder.AddCssClass(value: "form-control");

		if (string.IsNullOrWhiteSpace(value: dir) == false)
		{
			tagBuilder.Attributes.Add(key: "dir", value: dir);
		}

		if ((@for.ModelExplorer.ModelType == typeof(short))
			||
			(@for.ModelExplorer.ModelType == typeof(int))
			||
			(@for.ModelExplorer.ModelType == typeof(long)))
		{
			tagBuilder.AddCssClass(value: "ltr");

			tagBuilder.Attributes.Remove(key: "type");
			tagBuilder.Attributes.Add(key: "type", value: "number");
		}

		if (@for.ModelExplorer.ModelType == typeof(System.DateTime))
		{
			tagBuilder.AddCssClass(value: "ltr");

			tagBuilder.Attributes.Remove(key: "type");
			tagBuilder.Attributes.Add(key: "type", value: "text");
		}

		if (readOnly)
		{
			tagBuilder.Attributes.Add(key: "readonly", value: "readonly");
		}

		var writer = new StringWriter();

		tagBuilder.WriteTo(writer: writer, encoder: NullHtmlEncoder.Default);

		var result = writer.ToString();

		await writer.DisposeAsync();

		return result;
	}

	public static async Task<string> GeneratePasswordTextBoxAsync(
		IHtmlGenerator generator, ViewContext viewContext, ModelExpression @for)
	{
		var tagBuilder = generator.GenerateTextBox(
			viewContext: viewContext, modelExplorer: @for.ModelExplorer,
			expression: @for.Name, value: @for.Model, format: null, htmlAttributes: null);

		tagBuilder.AddCssClass(value: "form-control");

		tagBuilder.AddCssClass(value: "ltr");

		tagBuilder.Attributes.Remove(key: "type");
		tagBuilder.Attributes.Add(key: "type", value: "password");

		var writer = new StringWriter();

		tagBuilder.WriteTo(writer: writer, encoder: NullHtmlEncoder.Default);

		var result = writer.ToString();

		await writer.DisposeAsync();

		return result;
	}


	public static async Task<string> GenerateCheckBoxAsync(
		IHtmlGenerator generator, ViewContext viewContext, ModelExpression @for)
	{
		bool? isChecked = null;

		if (@for.Model is not null)
		{
			isChecked = Convert.ToBoolean(value: @for.Model);
		}

		var tagBuilder = generator.GenerateCheckBox(
			viewContext: viewContext, modelExplorer: @for.ModelExplorer,
			expression: @for.Name, isChecked: isChecked, htmlAttributes: null);

		tagBuilder.AddCssClass(value: "form-check-input");

		var writer = new StringWriter();

		tagBuilder.WriteTo(writer: writer, encoder: NullHtmlEncoder.Default);

		var result = writer.ToString();

		await writer.DisposeAsync();

		return result;
	}

	public static async Task<string> GenerateSelectAsync(
		IHtmlGenerator generator, ViewContext viewContext,
		ModelExpression @for, IEnumerable<SelectListItem> selectList)
	{
		var currentValues = new List<string>();

		if (@for is null)
		{
			return string.Empty;
		}

		if (@for.Model is not null)
		{
			string? value;

			if (@for.Model.GetType().IsEnum)
			{
				value = ((int)@for.Model).ToString();
			}
			else
			{
				value = @for.Model.ToString();
			}

			if (value is not null)
			{
				currentValues.Add(item: value);
			}
		}

		var tagBuilder = generator.GenerateSelect(
			viewContext: viewContext, modelExplorer: @for.ModelExplorer,
			optionLabel: null, expression: @for.Name, selectList: selectList,
			currentValues: currentValues, allowMultiple: false, htmlAttributes: null);

		tagBuilder.AddCssClass(value: "form-select");

		var writer = new StringWriter();

		tagBuilder.WriteTo(writer: writer, encoder: NullHtmlEncoder.Default);

		var result = writer.ToString();

		await writer.DisposeAsync();

		return result;
	}

	public static async
		Task<string> GenerateTextAreaAsync(IHtmlGenerator generator,
		ViewContext viewContext, ModelExpression @for, string? dir = null)
	{
		var tagBuilder = generator.GenerateTextArea(
			viewContext: viewContext, modelExplorer: @for.ModelExplorer,
			expression: @for.Name, rows: 3, columns: 60, htmlAttributes: null);

		tagBuilder.AddCssClass(value: "form-control");

		if (string.IsNullOrWhiteSpace(value: dir) == false)
		{
			tagBuilder.Attributes.Add(key: "dir", value: dir);
		}

		var writer = new StringWriter();

		tagBuilder.WriteTo(writer: writer, encoder: NullHtmlEncoder.Default);

		var result = writer.ToString();

		await writer.DisposeAsync();

		return result;
	}

	public static async Task<string> GenerateValidationMessageAsync(
		IHtmlGenerator generator, ViewContext viewContext, ModelExpression @for)
	{
		var tagBuilder = generator.GenerateValidationMessage(
			viewContext: viewContext, modelExplorer: @for.ModelExplorer,
			expression: @for.Name, message: null, tag: null, htmlAttributes: null);

		tagBuilder.AddCssClass(value: "text-danger");

		var writer = new StringWriter();

		tagBuilder.WriteTo(writer: writer, encoder: NullHtmlEncoder.Default);

		var result = writer.ToString();

		await writer.DisposeAsync();

		return result;
	}

	public static async Task<string> GenerateSelectAsync(
		IHtmlGenerator generator, ViewContext viewContext,
		ModelExpression @for, IList<SelectListItem> @Items, string? @OptionLabel)
	{
		var tagBuilder = generator.GenerateSelect(
			viewContext: viewContext, modelExplorer: @for.ModelExplorer,
			optionLabel: @OptionLabel, expression: @for.Name,
			selectList: @Items, allowMultiple: false, htmlAttributes: null);

		tagBuilder.AddCssClass(value: "form-control");

		var writer = new StringWriter();

		tagBuilder.WriteTo(writer: writer, encoder: NullHtmlEncoder.Default);

		var result = writer.ToString();

		await writer.DisposeAsync();

		return result;
	}
}
