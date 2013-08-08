using System.Text;
using System.Web.Mvc;

namespace WebrootUI2.Web.Mvc.Helper.PagingHelper
{
    public static class PagingHelper
    {
        public static MvcHtmlString Paging(this HtmlHelper html, Controllers.ViewModels.PagedList pagedList, string url, string pagePlaceHolder)
        {
            var sb = new StringBuilder();
            sb.Append("<div class='dataTables_paginate paging_bootstrap_alt pagination'>");
            sb.Append("<div style='width: 50%; float: left; text-align: right;'>");
            sb.Append("<div id=\"dt_a_info\" style=\"float:right\" class=\"dataTables_info\">Page ");

            sb.Append(pagedList.PageIndex + 1);
            sb.Append(" of " + pagedList.PageCount + "</div>");
            sb.Append("</div>");
            sb.Append("<div style='width: 50%; float: left;'>");
            // only show paging if we have more items than the page size)
            if (pagedList.ItemCount > pagedList.PageSize)
            {

                sb.Append("<ul class=\"paging\">");

                if (pagedList.IsPreviousPage)
                {
                    // previous link
                    sb.Append("<li class=\"prev\"><a href=\"");
                    sb.Append(url.Replace(pagePlaceHolder, pagedList.PageIndex.ToString()));
                    sb.Append("\" title=\"Go to Previous Page\">Prev</a></li>");
                }

                for (int i = 0; i < pagedList.PageCount; i++)
                {
                    sb.Append("<li class='disabled'>");

                    if (i == pagedList.PageIndex)
                    {
                        sb.Append("<span  class=\"current\">").Append((i + 1).ToString()).Append("</span>");

                    }
                    else
                    {
                        sb.Append("<a href=\"");
                        sb.Append(url.Replace(pagePlaceHolder, (i + 1).ToString()));
                        sb.Append("\">").Append((i + 1).ToString()).Append("</a>");
                    }
                    sb.Append("</li>");

                }

                if (pagedList.IsNextPage)
                { // next link
                    sb.Append("<li class=\"next\"><a href=\"");
                    sb.Append(url.Replace(pagePlaceHolder, (pagedList.PageIndex + 2).ToString()));
                    sb.Append("\" title=\"Go to Next Page\">Next</a></li>");
                }

                sb.Append("</ul>");

            }
            sb.Append("</div>");
            sb.Append("</div>");
            return MvcHtmlString.Create(sb.ToString());
        }

        public static MvcHtmlString PagingAjax(this HtmlHelper html, PagedList pagedList, string url, string pagePlaceHolder)
        {

            var sb = new StringBuilder();
            sb.Append("<div class='dataTables_paginate paging_bootstrap_alt pagination'>");
            sb.Append("<div style='width: 50%; float: left; text-align: right;'>");
            sb.Append("<div id=\"dt_a_info\" style=\"float:right\" class=\"dataTables_info\">Page ");

            sb.Append(pagedList.PageIndex + 1);
            sb.Append(" of " + pagedList.PageCount + "</div>");
            sb.Append("</div>");
            sb.Append("<div style='width: 50%; float: left;'>");
            // only show paging if we have more items than the page size)
            if (pagedList.ItemCount > pagedList.PageSize)
            {

                sb.Append("<ul class=\"paging\">");

                if (pagedList.IsPreviousPage)
                {
                    // previous link
                    sb.Append("<li class=\"prev\"><a onclick=\"");
                    sb.Append(url.Replace(pagePlaceHolder, pagedList.PageIndex.ToString()));
                    sb.Append("\" title=\"Go to Previous Page\">Prev</a></li>");
                }

                for (int i = 0; i < pagedList.PageCount; i++)
                {
                    sb.Append("<li>");

                    if (i == pagedList.PageIndex)
                    {
                        sb.Append("<span  class=\"current\">").Append((i + 1).ToString()).Append("</span>");

                    }
                    else
                    {
                        sb.Append("<a onclick=\"");
                        sb.Append(url.Replace(pagePlaceHolder, (i + 1).ToString()));
                        sb.Append("\">").Append((i + 1).ToString()).Append("</a>");
                    }
                    sb.Append("</li>");

                }

                if (pagedList.IsNextPage)
                { // next link
                    sb.Append("<li class=\"next\"><a onclick=\"");
                    sb.Append(url.Replace(pagePlaceHolder, (pagedList.PageIndex + 2).ToString()));
                    sb.Append("\" title=\"Go to Next Page\">Next</a></li>");
                }

                sb.Append("</ul>");

            }
            sb.Append("</div>");
            sb.Append("</div>");
            return MvcHtmlString.Create(sb.ToString());
        }

        public static string Paging(this HtmlHelper html, PagedList pagedList, string url, string pagePlaceHolder, string textPre, string textNext)
        {

            var sb = new StringBuilder();

            // only show paging if we have more items than the page size)
            if (pagedList.ItemCount > pagedList.PageSize)
            {

                sb.Append("<ul class=\"paging\">");

                if (pagedList.IsPreviousPage)
                {
                    // previous link
                    sb.Append("<li class=\"prev\"><a href=\"");
                    sb.Append(url.Replace(pagePlaceHolder, pagedList.PageIndex.ToString()));
                    sb.Append("\" title=\"Go to Previous Page\">");
                    sb.Append(textPre);
                    sb.Append("</a></li>");
                }

                for (int i = 0; i < pagedList.PageCount; i++)
                {
                    sb.Append("<li>");

                    if (i == pagedList.PageIndex)
                    {
                        sb.Append("<span  class=\"current\">").Append((i + 1).ToString()).Append("</span>");

                    }
                    else
                    {
                        sb.Append("<a href=\"");
                        sb.Append(url.Replace(pagePlaceHolder, (i + 1).ToString()));
                        sb.Append("\">").Append((i + 1).ToString()).Append("</a>");
                    }
                    sb.Append("</li>");

                }

                if (pagedList.IsNextPage)
                { // next link
                    sb.Append("<li class=\"next\"><a href=\"");
                    sb.Append(url.Replace(pagePlaceHolder, (pagedList.PageIndex + 2).ToString()));
                    sb.Append("\" title=\"Go to Next Page\">");
                    sb.Append(textNext);
                    sb.Append("</a></li>");
                }

                sb.Append("</ul>");

            }

            return sb.ToString();
        }

        public static string PagingAjax(this HtmlHelper html, PagedList pagedList, string url, string pagePlaceHolder, string textPre, string textNext)
        {

            var sb = new StringBuilder();

            // only show paging if we have more items than the page size)
            if (pagedList.ItemCount > pagedList.PageSize)
            {

                sb.Append("<ul class=\"paging\">");

                if (pagedList.IsPreviousPage)
                {
                    // previous link
                    sb.Append("<li class=\"prev\"><a onclick=\"");
                    sb.Append(url.Replace(pagePlaceHolder, pagedList.PageIndex.ToString()));
                    sb.Append("\" title=\"Go to Previous Page\">");
                    sb.Append(textPre);
                    sb.Append("</a></li>");

                }

                for (int i = 0; i < pagedList.PageCount; i++)
                {
                    sb.Append("<li>");

                    if (i == pagedList.PageIndex)
                    {
                        sb.Append("<span  class=\"current\">").Append((i + 1).ToString()).Append("</span>");

                    }
                    else
                    {
                        sb.Append("<a onclick=\"");
                        sb.Append(url.Replace(pagePlaceHolder, (i + 1).ToString()));
                        sb.Append("\">").Append((i + 1).ToString()).Append("</a>");
                    }
                    sb.Append("</li>");

                }

                if (pagedList.IsNextPage)
                { // next link
                    sb.Append("<li class=\"next\"><a onclick=\"");
                    sb.Append(url.Replace(pagePlaceHolder, (pagedList.PageIndex + 2).ToString()));
                    sb.Append("\" title=\"Go to Next Page\">");
                    sb.Append(textNext);
                    sb.Append("</a></li>");
                }

                sb.Append("</ul>");

            }

            return sb.ToString();
        }

    }
}

