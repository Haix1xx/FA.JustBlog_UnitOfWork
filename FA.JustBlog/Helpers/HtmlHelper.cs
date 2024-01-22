using FA.JustBlog.Core.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NuGet.Protocol;

namespace FA.JustBlog.Helpers
{
    public static class HtmlHelper
    {
        public static IHtmlContent CategoryLink(this IHtmlHelper htmlHelper, Category category)
        {
            //var aTag = new TagBuilder("a");
            ////aTag.Attributes["asp-controller"] = "Post";
            //aTag.MergeAttribute("asp-controller", "Post");
            //aTag.Attributes["asp-action"] = "PostsByCategory";
            //aTag.MergeAttribute("asp-action", "PostsByCategory");
            //aTag.Attributes["asp-route-category"] = category.Name;
            //aTag.MergeAttribute("asp-route-category", category.Name);
            //aTag.MergeAttribute("href", htmlHelper.ActionLink);
            //aTag.AddCssClass("text-danger");
            return htmlHelper.ActionLink(category.Name, "PostsByCategory", 
                new { controller = "Post", category = category.Name }, 
                new { @class = "text-decoration-underline", @style = "color: var(--bs-teal)" });

        }

        public static IHtmlContent TagLink(this IHtmlHelper htmlHelper, Tag tag)
        {
            return htmlHelper.ActionLink(tag.Name, "",
                new { controller = tag.Name },
                new { @class = "btn btn-outline-info border-2 p-2 m-1" });
        }

        public static IHtmlContent FriendlyDateTime(this IHtmlHelper htmlHelper, DateTime postedOn, decimal rate, int viewCount)
        {
            var builder = new TagBuilder("p");
            builder.AddCssClass("post-meta");
            builder.InnerHtml.Append($"Posted {postedOn.FriendlyDateTimeFormat()} with rate {rate:F} by {viewCount} view(s)");
            return builder;
        }
    }
}
