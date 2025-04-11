using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Threading.Tasks;

namespace Dtat.AspNetCore.Mvc.TagHelpers.Full;

[HtmlTargetElement(
	tag: Constant.TagHelper.FullTextArea,
	TagStructure = TagStructure.WithoutEndTag)]
public class FullTextAreaTagHelper : TagHelper
{
	public FullTextAreaTagHelper(IHtmlGenerator generator) : base()
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
		if (For is null)
		{
			throw new ArgumentNullException(paramName: nameof(For));
		}

		if (ViewContext is null)
		{
			throw new ArgumentNullException(paramName: nameof(ViewContext));
		}

		// **************************************************
		var div = new TagBuilder(tagName: "div");

		div.AddCssClass(value: "mb-3");
		// **************************************************

		// **************************************************
		var label =
			await
			Utility.GenerateLabelAsync
			(generator: Generator, viewContext: ViewContext, @for: For);

		div.InnerHtml.AppendHtml(encoded: label);
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
		var textBox =
			await
			Utility.GenerateTextAreaAsync(generator: Generator,
			viewContext: ViewContext, @for: For, dir: dirString);

		div.InnerHtml.AppendHtml(encoded: textBox);
		// **************************************************

		// **************************************************
		var validationMessage =
			await
			Utility.GenerateValidationMessageAsync
			(generator: Generator, viewContext: ViewContext, @for: For);

		div.InnerHtml.AppendHtml(encoded: validationMessage);
		// **************************************************

		// **************************************************
		output.TagName = null;

		output.TagMode = TagMode.StartTagAndEndTag;

		output.Content.SetHtmlContent(htmlContent: div);
		// **************************************************
	}
}
