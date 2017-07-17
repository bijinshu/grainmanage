using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GrainManage.Web.Helper
{
    public static class ImageHelper
    {
        private const string empty = "";
        public static MvcHtmlString ImageFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null)
        {
            dynamic body = expression.Body;
            string id = body.Member.Name;
            var builder = new TagBuilder("img");
            if (!string.IsNullOrEmpty(id))
            {
                // 增加id属性
                builder.GenerateId(id);
                builder.MergeAttribute("name", id);
            }
            if (htmlAttributes != null)
            {
                builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            }

            return new MvcHtmlString(builder.ToString(TagRenderMode.SelfClosing));
        }

        public static MvcHtmlString Image(this HtmlHelper htmlHelper, string src = empty, string id = empty, string alt = empty, object htmlAttributes = null)
        {
            // 创建IMG标签
            var builder = new TagBuilder("img");

            if (!string.IsNullOrEmpty(id))
            {
                // 增加id属性
                builder.GenerateId(id);
            }
            if (!string.IsNullOrEmpty(src))
            {
                // 增加src属性
                builder.MergeAttribute("src", src);
            }
            if (!string.IsNullOrEmpty(alt))
            {
                // 增加alt属性
                builder.MergeAttribute("alt", alt);
            }

            if (htmlAttributes != null)
            {
                builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            }

            // 输出完整的img标签
            return new MvcHtmlString(builder.ToString(TagRenderMode.SelfClosing));
        }
    }
}