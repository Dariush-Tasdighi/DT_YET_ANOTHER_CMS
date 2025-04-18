using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dtat.AspNetCore.Mvc.TagHelpers.SectionPage;

/// <summary>
/// Checked
/// </summary>
[HtmlTargetElement(tag: "section-page-header",
	TagStructure = TagStructure.NormalOrSelfClosing)]
public class SectionPageHeaderTagHelper : TagHelper
{
	//public override void Process(TagHelperContext context, TagHelperOutput output)
	//{
	//	base.Process(context, output);
	//}

	public async override Task ProcessAsync
		(TagHelperContext context, TagHelperOutput output)
	{
		// **************************************************
		var originalContents =
			await
			output.GetChildContentAsync();
		// **************************************************

		// **************************************************
		var h3 = new TagBuilder(tagName: "h3");

		h3.AddCssClass(value: "mt-3");
		h3.AddCssClass(value: "mb-3");
		h3.AddCssClass(value: "text-center");

		h3.InnerHtml.AppendHtml(content: originalContents);
		// **************************************************

		// **************************************************
		var horizontalRule = new TagBuilder(tagName: "hr")
		{
			TagRenderMode = TagRenderMode.SelfClosing,
		};

		horizontalRule.AddCssClass(value: "mt-4");

		h3.InnerHtml.AppendHtml(content: horizontalRule);
		// **************************************************

		// **************************************************
		output.TagName = null;
		output.TagMode = TagMode.StartTagAndEndTag;
		output.Content.SetHtmlContent(htmlContent: h3);
		// **************************************************
	}
}
