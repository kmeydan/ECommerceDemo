using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System;
using System.Text;

namespace ECommerceWebUI.TagHelpers
{
	[HtmlTargetElement("product-list-pager")]
	public class PagingTagHelper : TagHelper
	{
		[HtmlAttributeName("page-size")]
		public int PageSize { get; set; }
		[HtmlAttributeName("page-count")]
		public int PageCount { get; set; }
		[HtmlAttributeName("current-category")]
		public int CurrentCategory { get; set; }
		[HtmlAttributeName("current-page")]
		public int CurrentPage { get; set; }



		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			
			if (PageCount>1)
			{
				StringBuilder str = new StringBuilder();
				output.TagName = "ul";
				output.Attributes.SetAttribute("class", "pagination justify-content-center");
				str.AppendFormat("<li class='page-item'><a class='page-link' href='/Urunler?p={0}&c={1}'>Önceki</a></li>", CurrentPage - 1, CurrentCategory);

				for (int i = 1; i < PageCount; i++)
				{
					str.AppendFormat("<li class='page-item {0}'>", i == CurrentPage ? "active" : " ");
					str.AppendFormat("<a class='page-link' href='/Urunler?p={0}&c={1}'>{2}</a></li>", i, CurrentCategory, i);
				}
				str.AppendFormat("<li class='page-item'><a class='page-link' href='/Urunler?p={0}&c={1}'>Sonraki</a></li>", CurrentPage + 1, CurrentCategory);
				output.Content.SetHtmlContent(str.ToString());
				base.Process(context, output);

			}
			
				

		}
	}

}
