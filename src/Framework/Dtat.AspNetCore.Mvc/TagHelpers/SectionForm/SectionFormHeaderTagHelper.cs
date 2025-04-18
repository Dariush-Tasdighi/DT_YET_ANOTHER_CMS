using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dtat.AspNetCore.Mvc.TagHelpers.SectionForm;

/// <summary>
/// Checked
/// </summary>
[HtmlTargetElement(tag: "section-form-header",
	ParentTag = "fieldset",
	TagStructure = TagStructure.NormalOrSelfClosing)]
public class SectionFormHeaderTagHelper : TagHelper
{
	public async override Task ProcessAsync
		(TagHelperContext context, TagHelperOutput output)
	{
		// **************************************************
		var originalContents =
			await
			output.GetChildContentAsync();
		// **************************************************

		// **************************************************
		var horizontalRule = new TagBuilder(tagName: "hr")
		{
			TagRenderMode = TagRenderMode.SelfClosing,
		};

		horizontalRule.AddCssClass(value: "mt-4");
		// **************************************************

		// **************************************************
		var body = new TagBuilder(tagName: "legend");

		body.AddCssClass(value: "text-center");

		body.InnerHtml.AppendHtml(content: originalContents);
		// **************************************************

		// **************************************************
		output.TagName = null;
		output.TagMode = TagMode.StartTagAndEndTag;
		output.Content.SetHtmlContent(htmlContent: body);

		// بر خلاف نمونه‌های قبلی
		output.PostElement.AppendHtml(htmlContent: horizontalRule);
		// **************************************************
	}
}
