using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dtat.AspNetCore.Mvc.TagHelpers.SectionPage;

[HtmlTargetElement(
	tag: "section-page-header",
	TagStructure = TagStructure.NormalOrSelfClosing)]
public class SectionPageHeaderTagHelper : TagHelper
{
	//public override void Process
	//	(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext context,
	//	Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput output)
	//{
	//	base.Process(context, output);
	//}

	public async override Task ProcessAsync(
		TagHelperContext context, TagHelperOutput output)
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
		var body = new TagBuilder(tagName: "h3");

		body.AddCssClass(value: "mt-3");
		body.AddCssClass(value: "mb-3");
		body.AddCssClass(value: "text-center");

		body.InnerHtml.AppendHtml(content: originalContents);
		//body.InnerHtml.AppendHtml(content: horizontalRule);
		// **************************************************

		// **************************************************
		output.TagName = null;
		output.TagMode = TagMode.StartTagAndEndTag;
		output.Content.SetHtmlContent(htmlContent: body);
		// **************************************************
	}
}
