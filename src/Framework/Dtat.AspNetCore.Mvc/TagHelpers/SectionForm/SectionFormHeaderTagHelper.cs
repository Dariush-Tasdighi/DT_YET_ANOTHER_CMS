using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dtat.AspNetCore.Mvc.TagHelpers.SectionForm;

/// <summary>
/// Checked
/// </summary>
[HtmlTargetElement(tag: "section-form-header",
	ParentTag = "section-form-fieldset",
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
		var hr = new TagBuilder(tagName: "hr")
		{
			TagRenderMode = TagRenderMode.SelfClosing,
		};

		hr.AddCssClass(value: "mt-4");
		// **************************************************

		// **************************************************
		var legend = new TagBuilder(tagName: "legend");

		legend.AddCssClass(value: "text-center");

		legend.InnerHtml.AppendHtml(content: originalContents);
		// **************************************************

		// **************************************************
		output.TagName = null;
		output.TagMode = TagMode.StartTagAndEndTag;
		output.Content.SetHtmlContent(htmlContent: legend);

		// بر خلاف نمونه‌های قبلی
		output.PostElement.AppendHtml(htmlContent: hr);
		// **************************************************
	}
}
