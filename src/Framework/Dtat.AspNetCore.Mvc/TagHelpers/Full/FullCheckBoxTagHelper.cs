using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Threading.Tasks;

namespace Dtat.AspNetCore.Mvc.TagHelpers.Full;

[HtmlTargetElement(
	tag: Constant.TagHelper.FullCheckBox,
	TagStructure = TagStructure.WithoutEndTag)]
public class FullCheckBoxTagHelper : TagHelper
{
	public FullCheckBoxTagHelper(IHtmlGenerator generator) : base()
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
		var innerDiv = new TagBuilder(tagName: "div");

		innerDiv.AddCssClass(value: "form-check");

		div.InnerHtml.AppendHtml(content: innerDiv);
		// **************************************************

		// **************************************************
		var checkBox =
			await
			Utility.GenerateCheckBoxAsync
			(generator: Generator, viewContext: ViewContext, @for: For);

		innerDiv.InnerHtml.AppendHtml(encoded: checkBox);
		// **************************************************

		// **************************************************
		var label =
			await
			Utility.GenerateLabelAsync(generator: Generator,
			viewContext: ViewContext, @for: For, cssClass: "form-check-label");

		innerDiv.InnerHtml.AppendHtml(encoded: label);
		// **************************************************

		// **************************************************
		output.TagName = null;

		output.TagMode = TagMode.StartTagAndEndTag;

		output.Content.SetHtmlContent(htmlContent: div);
		// **************************************************
	}

	//private async System.Threading.Tasks.Task<string> CreateLabelElementAsync()
	//{
	//	var tagBuilder =
	//		Generator.GenerateLabel
	//		(viewContext: ViewContext,
	//		modelExplorer: For.ModelExplorer, expression: For.Name, labelText: null,
	//		htmlAttributes: new { @class =  });

	//	var writer =
	//		new System.IO.StringWriter();

	//	tagBuilder.WriteTo(writer: writer,
	//		encoder: Microsoft.AspNetCore.Razor.TagHelpers.NullHtmlEncoder.Default);

	//	var result =
	//		writer.ToString();

	//	await writer.DisposeAsync();

	//	return result;
	//}
}
