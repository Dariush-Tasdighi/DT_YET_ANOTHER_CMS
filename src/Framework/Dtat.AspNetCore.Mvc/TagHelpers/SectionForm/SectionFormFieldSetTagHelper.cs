using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dtat.AspNetCore.Mvc.TagHelpers.SectionForm;

/// <summary>
/// Checked
/// </summary>
[HtmlTargetElement(tag: "section-form-fieldset",
	ParentTag = "section-form",
	TagStructure = TagStructure.NormalOrSelfClosing)]
public class SectionFormFieldSetTagHelper : TagHelper
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
		var fieldset = new TagBuilder(tagName: "fieldset");

		fieldset.InnerHtml.AppendHtml(content: originalContents);
		// **************************************************

		// **************************************************
		output.TagName = null;
		output.TagMode = TagMode.StartTagAndEndTag;
		output.Content.SetHtmlContent(htmlContent: fieldset);
		// **************************************************
	}
}
