using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dtat.AspNetCore.Mvc.TagHelpers.Table;

/// <summary>
/// Checked
/// </summary>
[HtmlTargetElement(tag: "table",
	// بر خلاف نمونه‌های قبلی
	ParentTag = "section-table",
	TagStructure = TagStructure.NormalOrSelfClosing)]
public class TableTagHelper : TagHelper
{
	public async override Task ProcessAsync
		(TagHelperContext context, TagHelperOutput output)
	{
		// **************************************************
		//var originalContents =
		//	await
		//	output.GetChildContentAsync()
		//	;

		// بر خلاف نمونه‌های قبلی
		var originalContents =
			(await
			output.GetChildContentAsync())
			.GetContent()
			;

		originalContents = originalContents.Replace
			(oldValue: "thead", newValue: "thead class=\"table-primary text-center\"");

		originalContents = originalContents.Replace
			(oldValue: "tfooter", newValue: "tfooter class=\"table-secondary\"");
		// **************************************************

		// **************************************************
		//output.TagName = null;

		// بر خلاف نمونه‌های قبلی
		output.TagName = "table";
		output.TagMode = TagMode.StartTagAndEndTag;

		// بر خلاف نمونه‌های قبلی
		output.Attributes.SetAttribute(name: "class",
			value: "table table-bordered table-sm table-striped table-hover align-items-center");

		//output.Content.SetHtmlContent(htmlContent: divRow);

		// بر خلاف نمونه‌های قبلی
		output.Content.SetHtmlContent(encoded: originalContents);
		// **************************************************
	}
}
