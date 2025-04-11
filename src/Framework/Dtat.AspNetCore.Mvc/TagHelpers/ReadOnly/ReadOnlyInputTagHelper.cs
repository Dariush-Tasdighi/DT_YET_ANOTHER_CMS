using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Dtat.AspNetCore.Mvc.TagHelpers.ReadOnly;

/// <summary>
/// https://stackoverflow.com/questions/51904629/how-to-create-custom-tag-helper-containing-other-tag-helpers
/// https://stackoverflow.com/questions/47547844/tag-helper-embedded-in-another-tag-helpers-code-doesnt-render
/// https://stackoverflow.com/questions/46681692/combine-taghelper-statements
/// </summary>
[HtmlTargetElement(
	tag: Constant.TagHelper.ReadOnlyInput,
	TagStructure = TagStructure.WithoutEndTag)]
public class ReadOnlyInputTagHelper : TagHelper
{
	public ReadOnlyInputTagHelper(IHtmlGenerator generator) : base()
	{
		Generator = generator;
	}

	private IHtmlGenerator Generator { get; init; }

	[ViewContext]
	[HtmlAttributeNotBound]
	public ViewContext? ViewContext { get; set; }

	[HtmlAttributeName(name: "asp-for")]
	public ModelExpression? For { get; set; }

	public override async Task ProcessAsync
		(TagHelperContext context, TagHelperOutput output)
	{
		// **************************************************
		var div = new TagBuilder(tagName: "div");

		div.AddCssClass(value: "mb-3");
		// **************************************************

		// **************************************************
		var labelElement =
			await
			CreateLabelElementAsync();

		div.InnerHtml.AppendHtml(encoded: labelElement);
		// **************************************************

		// **************************************************
		string? dirString = null;

		var dirAttribute = output.Attributes["dir"];

		if (dirAttribute is not null)
		{
			var dirValue = dirAttribute.Value;

			if (dirValue is not null)
			{
				dirString = dirValue.ToString()?
					.Replace(oldValue: "{", newValue: string.Empty)
					.Replace(oldValue: "}", newValue: string.Empty);
			}
		}
		// **************************************************

		// **************************************************
		var textBoxElement =
			await
			CreateTextBoxElementAsync(dir: dirString);

		div.InnerHtml.AppendHtml(encoded: textBoxElement);
		// **************************************************

		// **************************************************
		output.TagName = null;

		output.TagMode = TagMode.StartTagAndEndTag;

		output.Content.SetHtmlContent(htmlContent: div);
		// **************************************************
	}

	private async Task<string> CreateLabelElementAsync()
	{
		if (For is null)
		{
			throw new ArgumentNullException(paramName: nameof(For));
		}

		var tagBuilder =
			Generator.GenerateLabel
			(viewContext: ViewContext,
			modelExplorer: For.ModelExplorer, expression: For.Name, labelText: null,
			htmlAttributes: new { @class = "form-label" });

		var writer = new StringWriter();

		tagBuilder.WriteTo(writer: writer, encoder: NullHtmlEncoder.Default);

		var result = writer.ToString();

		await writer.DisposeAsync();

		return result;
	}

	private async Task<string> CreateTextBoxElementAsync(string? dir = null)
	{
		if (For is null)
		{
			throw new Exception(message: $"'{nameof(For)}' property is null ");
		}

		TagBuilder tagBuilder;

		var converter = new ModelExpressionConverter(modelExpression: For);

		if (converter.HasBeenConverted)
		{
			tagBuilder =
				Generator.GenerateTextBox
				(viewContext: ViewContext,
				modelExplorer: For.ModelExplorer,
				expression: For.Name, value: converter.Value,
				format: null, htmlAttributes: null);
		}
		else
		{
			tagBuilder =
				Generator.GenerateTextBox
				(viewContext: ViewContext,
				modelExplorer: For.ModelExplorer,
				expression: For.Name, value: For.Model,
				format: null, htmlAttributes: null);
		}

		tagBuilder.AddCssClass(value: "form-control");

		tagBuilder.Attributes.Add(key: "disabled", value: null);
		//tagBuilder.Attributes.Add(key: "disabled", value: "disabled");
		//tagBuilder.Attributes.Add(key: "readonly", value: null);
		//tagBuilder.Attributes.Add(key: "readonly", value: "readonly");

		if (converter.IsLeftToRight)
		{
			tagBuilder.AddCssClass(value: "ltr");
		}
		else
		{
			if (string.IsNullOrWhiteSpace(value: dir) == false)
			{
				tagBuilder.Attributes.Add(key: "dir", value: dir);
			}
		}

		var writer = new StringWriter();

		tagBuilder.WriteTo(writer: writer, encoder: NullHtmlEncoder.Default);

		var result = writer.ToString();

		await writer.DisposeAsync();

		return result;
	}
}
