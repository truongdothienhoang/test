using System;
using System.Web;
using System.Web.Mvc;

namespace WebrootUI2.Web.Mvc.Helper.Filter
{
    [HandleError]
    public class AuthorizeFilter : AuthorizeAttribute
    {
        #region Private members

        #endregion

        #region Constructors

        #endregion

        public String RedirectResultUrl { get; set; }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (String.IsNullOrEmpty(RedirectResultUrl))
                base.HandleUnauthorizedRequest(filterContext);

            else
                filterContext.Result = new RedirectResult(RedirectResultUrl + "?urlReturn=" + HttpContext.Current.Request.Url);
        }
    }
}