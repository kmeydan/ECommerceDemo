using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace ECommerceWebUI.TagHelpers
{
    [HtmlTargetElement("Slider")]
    public class SliderTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            StringBuilder x = new StringBuilder();

            base.Process(context, output);
        }
    }
}
