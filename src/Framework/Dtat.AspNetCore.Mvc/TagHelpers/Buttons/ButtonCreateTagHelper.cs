using Dtat.Resources;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dtat.AspNetCore.Mvc.TagHelpers.Buttons;

[HtmlTargetElement
	(tag: "button-create",
	ParentTag = "section-form-buttons",
	TagStructure = TagStructure.WithoutEndTag)]
public class ButtonCreateTagHelper : TagHelper
{
	public override void Process(TagHelperContext context, TagHelperOutput output)
	{
		// **************************************************
		var icon = Utility.GetIconCreate();
		// **************************************************

		// **************************************************
		var body = new TagBuilder(tagName: "button");

		body.Attributes.Add(key: "type", value: "submit");

		body.AddCssClass(value: "btn");
		body.AddCssClass(value: "btn-primary");

		body.InnerHtml.AppendHtml(content: icon);
		body.InnerHtml.Append(unencoded: DataDictionary.Create);
		// **************************************************

		// **************************************************
		output.TagName = null;

		output.TagMode =
			Microsoft.AspNetCore.Razor
			.TagHelpers.TagMode.StartTagAndEndTag;

		output.Content.SetHtmlContent(htmlContent: body);
		// **************************************************
	}
}
