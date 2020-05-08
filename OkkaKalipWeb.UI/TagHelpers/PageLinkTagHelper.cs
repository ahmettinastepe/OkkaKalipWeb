using Microsoft.AspNetCore.Razor.TagHelpers;
using OkkaKalipWeb.UI.Models;
using System.Text;

namespace OkkaKalipWeb.UI.TagHelpers
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        public PageInfo PageModel { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<ul class='page-pagination shop-pagination none-style'>");

            for (int i = 1; i <= PageModel.TotalPages(); i++)
            {
                stringBuilder.Append("<li>");

                if (string.IsNullOrEmpty(PageModel.CurrentCategory))
                    stringBuilder.AppendFormat("<a class='page-numbers {0}' href='/" + PageModel.Controller + "?page={1}'>{1}</a>", i == PageModel.CurrentPage ? "current-paging" : "", i);
                else
                    stringBuilder.AppendFormat("<a class='page-numbers {0}' href='/products/{1}?page={2}'>{2}</a>", i == PageModel.CurrentPage ? "current-paging" : "", PageModel.CurrentCategory, i);

                stringBuilder.Append("</li>");
            }

            output.Content.SetHtmlContent(stringBuilder.ToString());

            base.Process(context, output);
        }
    }
}