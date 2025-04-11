using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dtat.AspNetCore.Mvc.TagHelpers.Full;

[HtmlTargetElement(
	tag: Constant.TagHelper.FullSelect,
	TagStructure = TagStructure.WithoutEndTag)]
public class FullSelectTagHelper : TagHelper

{
	public FullSelectTagHelper(IHtmlGenerator generator) : base()
	{
		Generator = generator;
	}

	private IHtmlGenerator Generator { get; init; }

	[ViewContext]
	[HtmlAttributeNotBound]
	public ViewContext? ViewContext { get; set; }

	[HtmlAttributeName(name: "asp-for")]
	public ModelExpression? For { get; set; }

	[HtmlAttributeName(name: "asp-items")]
	public IEnumerable<SelectListItem>? Items { get; set; }

	[HtmlAttributeName(name: "asp-option-label")]
	public string? OptionLabel { get; set; }

	public override async Task ProcessAsync
		(TagHelperContext context, TagHelperOutput output)
	{
		if (For is null)
		{
			throw new Exception(message: $"'{nameof(For)}' property is null ");
		}

		if (Items is null)
		{
			throw new Exception(message: $"'{nameof(Items)}' property is null ");
		}

		if (ViewContext is null)
		{
			throw new Exception(message: $"'{nameof(ViewContext)}' property is null ");
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
		var select =
			await
			Utility.GenerateSelectAsync
			(generator: Generator, viewContext: ViewContext, @for: For, selectList: Items);

		div.InnerHtml.AppendHtml(encoded: select);
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
