using System.Linq;

namespace Dtat.AspNetCore.Mvc.TagHelpers;

public static class Utility : object
{
	public static Microsoft.AspNetCore.Mvc.Rendering.TagBuilder GetIconList()
	{
		var icon =
			new Microsoft.AspNetCore.Mvc
			.Rendering.TagBuilder(tagName: "i");

		icon.AddCssClass(value: "mx-1");
		icon.AddCssClass(value: "bi");
		icon.AddCssClass(value: "bi-card-list");

		return icon;
	}

	public static Microsoft.AspNetCore.Mvc.Rendering.TagBuilder GetIconDetails()
	{
		var icon =
			new Microsoft.AspNetCore.Mvc
			.Rendering.TagBuilder(tagName: "i");

		icon.AddCssClass(value: "mx-1");
		icon.AddCssClass(value: "bi");
		icon.AddCssClass(value: "bi-zoom-in");

		return icon;
	}

	public static Microsoft.AspNetCore.Mvc.Rendering.TagBuilder GetIconDisplay()
	{
		var icon =
			new Microsoft.AspNetCore.Mvc
			.Rendering.TagBuilder(tagName: "i");

		icon.AddCssClass(value: "mx-1");
		icon.AddCssClass(value: "bi");
		icon.AddCssClass(value: "bi-eye");

		return icon;
	}

	public static Microsoft.AspNetCore.Mvc.Rendering.TagBuilder GetIconCreate()
	{
		var icon =
			new Microsoft.AspNetCore.Mvc
			.Rendering.TagBuilder(tagName: "i");

		icon.AddCssClass(value: "mx-1");
		icon.AddCssClass(value: "bi");
		icon.AddCssClass(value: "bi-plus-square");

		return icon;
	}

	public static Microsoft.AspNetCore.Mvc.Rendering.TagBuilder GetIconUpdate()
	{
		var icon =
			new Microsoft.AspNetCore.Mvc
			.Rendering.TagBuilder(tagName: "i");

		icon.AddCssClass(value: "mx-1");
		icon.AddCssClass(value: "bi");
		icon.AddCssClass(value: "bi-pencil-fill");

		return icon;
	}

	public static Microsoft.AspNetCore.Mvc.Rendering.TagBuilder GetIconDelete()
	{
		var icon =
			new Microsoft.AspNetCore.Mvc
			.Rendering.TagBuilder(tagName: "i");

		icon.AddCssClass(value: "mx-1");
		icon.AddCssClass(value: "bi");
		icon.AddCssClass(value: "bi-trash");

		return icon;
	}

	public static Microsoft.AspNetCore.Mvc.Rendering.TagBuilder GetIconReset()
	{
		var icon =
			new Microsoft.AspNetCore.Mvc
			.Rendering.TagBuilder(tagName: "i");

		icon.AddCssClass(value: "mx-1");
		icon.AddCssClass(value: "bi");
		icon.AddCssClass(value: "bi-repeat");

		return icon;
	}

	public static Microsoft.AspNetCore.Mvc.Rendering.TagBuilder GetIconSend()
	{
		var icon =
			new Microsoft.AspNetCore.Mvc
			.Rendering.TagBuilder(tagName: "i");

		icon.AddCssClass(value: "mx-1");
		icon.AddCssClass(value: "bi");
		icon.AddCssClass(value: "bi-send");

		return icon;
	}

	public static Microsoft.AspNetCore.Mvc.Rendering.TagBuilder GetIconSearch()
	{
		var icon =
			new Microsoft.AspNetCore.Mvc
			.Rendering.TagBuilder(tagName: "i");

		icon.AddCssClass(value: "mx-1");
		icon.AddCssClass(value: "bi");
		icon.AddCssClass(value: "bi-search");

		return icon;
	}

	public static Microsoft.AspNetCore.Mvc.Rendering.TagBuilder GetIconSubmit()
	{
		var icon =
			new Microsoft.AspNetCore.Mvc
			.Rendering.TagBuilder(tagName: "i");

		icon.AddCssClass(value: "mx-1");
		icon.AddCssClass(value: "bi");
		icon.AddCssClass(value: "bi-hand-thumbs-up");

		return icon;
	}

	public static Microsoft.AspNetCore.Mvc.Rendering.TagBuilder GetIconCustom(string iconName)
	{
		var icon =
			new Microsoft.AspNetCore.Mvc
			.Rendering.TagBuilder(tagName: "i");

		icon.AddCssClass(value: "mx-1");
		icon.AddCssClass(value: "bi");
		icon.AddCssClass(value: iconName);

		return icon;
	}

	public static void CreateOrMergeAttribute
		(string name, object content,
		Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput output)
	{
		var currentAttribute =
			output.Attributes
			.Where(current => current.Name == name)
			.FirstOrDefault();

		if (currentAttribute is null)
		{
			var attribute =
				new Microsoft.AspNetCore.Razor.TagHelpers
				.TagHelperAttribute(name: name, value: content);

			output.Attributes
				.Add(attribute: attribute);
		}
		else
		{
			var value =
				$"{currentAttribute.Value} {content}";

			var newAttribute =
				new Microsoft.AspNetCore.Razor.TagHelpers
				.TagHelperAttribute(name: name, value: value,
				valueStyle: currentAttribute.ValueStyle);

			output.Attributes
				.Remove(attribute: currentAttribute);

			output.Attributes
				.Add(attribute: newAttribute);
		}
	}

	public static async
		System.Threading.Tasks.Task<string> GenerateLabelAsync
		(Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator generator,
		Microsoft.AspNetCore.Mvc.Rendering.ViewContext viewContext,
		Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExpression @for, string? cssClass = null)
	{
		var tagBuilder =
			generator.GenerateLabel
			(viewContext: viewContext,
			modelExplorer: @for.ModelExplorer,
			expression: @for.Name, labelText: null, htmlAttributes: null);

		if (cssClass is null)
		{
			tagBuilder.AddCssClass
				(value: "form-label");
		}
		else
		{
			tagBuilder.AddCssClass(value: cssClass);
		}

		var writer =
			new System.IO.StringWriter();

		tagBuilder.WriteTo(writer: writer,
			encoder: Microsoft.AspNetCore.Razor.TagHelpers.NullHtmlEncoder.Default);

		var result =
			writer.ToString();

		await writer.DisposeAsync();

		return result;
	}

	public static async
		System.Threading.Tasks.Task<string> GenerateTextBoxAsync
		(Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator generator,
		Microsoft.AspNetCore.Mvc.Rendering.ViewContext viewContext,
		Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExpression @for,
		bool readOnly = false, string? dir = null)
	{
		var tagBuilder =
			generator.GenerateTextBox
			(viewContext: viewContext,
			modelExplorer: @for.ModelExplorer, expression: @for.Name,
			value: @for.Model, format: null, htmlAttributes: null);

		tagBuilder.AddCssClass
			(value: "form-control");

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

		var writer =
			new System.IO.StringWriter();

		tagBuilder.WriteTo(writer: writer,
			encoder: Microsoft.AspNetCore.Razor.TagHelpers.NullHtmlEncoder.Default);

		var result =
			writer.ToString();

		await writer.DisposeAsync();

		return result;
	}

	public static async
		System.Threading.Tasks.Task<string> GeneratePasswordTextBoxAsync
		(Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator generator,
		Microsoft.AspNetCore.Mvc.Rendering.ViewContext viewContext,
		Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExpression @for)
	{
		var tagBuilder =
			generator.GenerateTextBox
			(viewContext: viewContext,
			modelExplorer: @for.ModelExplorer, expression: @for.Name,
			value: @for.Model, format: null, htmlAttributes: null);

		tagBuilder.AddCssClass
			(value: "form-control");

		tagBuilder.AddCssClass(value: "ltr");

		tagBuilder.Attributes.Remove(key: "type");
		tagBuilder.Attributes.Add(key: "type", value: "password");

		var writer =
			new System.IO.StringWriter();

		tagBuilder.WriteTo(writer: writer,
			encoder: Microsoft.AspNetCore.Razor.TagHelpers.NullHtmlEncoder.Default);

		var result =
			writer.ToString();

		await writer.DisposeAsync();

		return result;
	}


	public static async
		System.Threading.Tasks.Task<string> GenerateCheckBoxAsync
		(Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator generator,
		Microsoft.AspNetCore.Mvc.Rendering.ViewContext viewContext,
		Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExpression @for)
	{
		bool? isChecked = null;

		if (@for.Model is not null)
		{
			isChecked =
				System.Convert
				.ToBoolean(value: @for.Model);
		}

		var tagBuilder =
			generator.GenerateCheckBox
			(viewContext: viewContext, modelExplorer: @for.ModelExplorer,
			expression: @for.Name, isChecked: isChecked, htmlAttributes: null);

		tagBuilder.AddCssClass
			(value: "form-check-input");

		var writer =
			new System.IO.StringWriter();

		tagBuilder.WriteTo(writer: writer,
			encoder: Microsoft.AspNetCore.Razor.TagHelpers.NullHtmlEncoder.Default);

		var result =
			writer.ToString();

		await writer.DisposeAsync();

		return result;
	}

	public static async
		System.Threading.Tasks.Task<string> GenerateSelectAsync
		(Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator generator,
		Microsoft.AspNetCore.Mvc.Rendering.ViewContext viewContext,
		Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExpression @for,
		System.Collections.Generic.IEnumerable
			<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> selectList)
	{
		var currentValues =
			new System.Collections.Generic.List<string>();

		if (@for is null)
		{
			return string.Empty;
		}

		if (@for.Model is not null)
		{
			string? value;

			if(@for.Model.GetType().IsEnum)
			{
				value =
					((int)@for.Model).ToString();
			}
			else
			{
				value =
					@for.Model.ToString();
			}

			if (value is not null)
			{
				currentValues.Add(item: value);
			}
		}

		var tagBuilder =
			generator.GenerateSelect
			(viewContext: viewContext,
			modelExplorer: @for.ModelExplorer,
			optionLabel: null, expression: @for.Name, selectList: selectList,
			currentValues: currentValues, allowMultiple: false, htmlAttributes: null);

		tagBuilder.AddCssClass
			(value: "form-select");

		var writer =
			new System.IO.StringWriter();

		tagBuilder.WriteTo(writer: writer,
			encoder: Microsoft.AspNetCore.Razor.TagHelpers.NullHtmlEncoder.Default);

		var result =
			writer.ToString();

		await writer.DisposeAsync();

		return result;
	}

	public static async
		System.Threading.Tasks.Task<string> GenerateTextAreaAsync
		(Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator generator,
		Microsoft.AspNetCore.Mvc.Rendering.ViewContext viewContext,
		Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExpression @for, string? dir = null)
	{
		var tagBuilder =
			generator.GenerateTextArea
			(viewContext: viewContext, modelExplorer: @for.ModelExplorer,
			expression: @for.Name, rows: 3, columns: 60, htmlAttributes: null);

		tagBuilder.AddCssClass
			(value: "form-control");

		if (string.IsNullOrWhiteSpace(value: dir) == false)
		{
			tagBuilder.Attributes.Add(key: "dir", value: dir);
		}

		var writer =
			new System.IO.StringWriter();

		tagBuilder.WriteTo(writer: writer,
			encoder: Microsoft.AspNetCore.Razor.TagHelpers.NullHtmlEncoder.Default);

		var result =
			writer.ToString();

		await writer.DisposeAsync();

		return result;
	}

	public static async
		System.Threading.Tasks.Task<string> GenerateValidationMessageAsync
		(Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator generator,
		Microsoft.AspNetCore.Mvc.Rendering.ViewContext viewContext,
		Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExpression @for)
	{
		var tagBuilder =
			generator.GenerateValidationMessage
			(viewContext: viewContext,
			modelExplorer: @for.ModelExplorer,
			expression: @for.Name, message: null, tag: null, htmlAttributes: null);

		tagBuilder.AddCssClass(value: "text-danger");

		var writer =
			new System.IO.StringWriter();

		tagBuilder.WriteTo(writer: writer,
			encoder: Microsoft.AspNetCore.Razor.TagHelpers.NullHtmlEncoder.Default);

		var result =
			writer.ToString();

		await writer.DisposeAsync();

		return result;
	}

	public static async
		System.Threading.Tasks.Task<string> GenerateSelectAsync
		(Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator generator,
		Microsoft.AspNetCore.Mvc.Rendering.ViewContext viewContext,
		Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExpression @for,
		System.Collections.Generic.IList
		<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> @Items,
		string? @OptionLabel)
	{
		var tagBuilder =
			generator.GenerateSelect
			(viewContext: viewContext, modelExplorer: @for.ModelExplorer, optionLabel: @OptionLabel,
			expression: @for.Name, selectList: @Items, allowMultiple: false, htmlAttributes: null);

		tagBuilder.AddCssClass
			(value: "form-control");

		var writer =
			new System.IO.StringWriter();

		tagBuilder.WriteTo(writer: writer,
			encoder: Microsoft.AspNetCore.Razor.TagHelpers.NullHtmlEncoder.Default);

		var result =
			writer.ToString();

		await writer.DisposeAsync();

		return result;
	}
}
