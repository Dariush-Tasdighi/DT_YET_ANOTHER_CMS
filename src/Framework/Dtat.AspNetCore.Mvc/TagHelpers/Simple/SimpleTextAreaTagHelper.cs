using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Dtat.AspNetCore.Mvc.TagHelpers.Simple;

[HtmlTargetElement(
	tag: Constant.TagHelper.TextArea,
	TagStructure = TagStructure.WithoutEndTag)]
public class SimpleTextAreaTagHelper : TextAreaTagHelper
{
	public SimpleTextAreaTagHelper(IHtmlGenerator generator) : base(generator: generator)
	{
	}

	public override Task ProcessAsync
		(TagHelperContext context, TagHelperOutput output)
	{
		Utility.CreateOrMergeAttribute
			(name: "class", content: "form-control", output: output);

		return base.ProcessAsync(context, output);
	}
}
