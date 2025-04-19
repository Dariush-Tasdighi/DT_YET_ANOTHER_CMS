using Dtat.Resources;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dtat.AspNetCore.Mvc.TagHelpers.Buttons;

/// <summary>
/// Checked
/// </summary>
[HtmlTargetElement(tag: "button-create",
	ParentTag = "section-form-buttons",
	TagStructure = TagStructure.WithoutEndTag)]
public class ButtonCreateTagHelper : TagHelper
{
	public override void Process
		(TagHelperContext context, TagHelperOutput output)
	{
		// **************************************************
		var icon = Utility.GetIconCreate();
		// **************************************************

		// **************************************************
		var button = new TagBuilder(tagName: "button");

		button.Attributes.Add(key: "type", value: "submit");

		button.AddCssClass(value: "btn");
		button.AddCssClass(value: "btn-primary");

		button.InnerHtml.AppendHtml(content: icon);
		button.InnerHtml.Append(unencoded: DataDictionary.Create);
		// **************************************************

		// **************************************************
		output.TagName = null;
		output.TagMode = TagMode.StartTagAndEndTag;
		output.Content.SetHtmlContent(htmlContent: button);
		// **************************************************
	}
}
