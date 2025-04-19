using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dtat.AspNetCore.Mvc.TagHelpers.SectionForm;

/// <summary>
/// Checked
/// </summary>
[HtmlTargetElement(tag: "section-form-footer",
	ParentTag = "section-form",
	TagStructure = TagStructure.NormalOrSelfClosing)]
public class SectionFormFooterTagHelper : TagHelper
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
		var hr = new TagBuilder(tagName: "hr")
		{
			TagRenderMode = TagRenderMode.SelfClosing,
		};

		hr.AddCssClass(value: "mt-4");
		// **************************************************

		// **************************************************
		var div = new TagBuilder(tagName: "div");

		div.AddCssClass(value: "mb-3");
		div.AddCssClass(value: "text-center");

		div.InnerHtml.AppendHtml(content: originalContents);
		// **************************************************

		// **************************************************
		output.TagName = null;
		output.TagMode = TagMode.StartTagAndEndTag;
		output.Content.SetHtmlContent(htmlContent: div);

		// بر خلاف نمونه‌های قبلی
		output.PreElement.AppendHtml(htmlContent: hr);
		// **************************************************
	}
}
