using System;
using System.Web;

namespace WebrootUI2.Web.Mvc.Helper.Localization
{
    public class CookieHelper
    {

        public static string SetCookie(string key, string value)
        {
            var cookie = HttpContext.Current.Request.Cookies[key];
            if (cookie == null)
            {
                cookie = new HttpCookie(key, value);
                // set the cookie's expiration date 
                cookie.Expires = DateTime.Now.AddDays(10);
                // set the cookie on client's browser
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
            else
            {
                cookie.Value = value;
                HttpContext.Current.Response.Cookies.Add(cookie);
            }

            return cookie.Value;
        }

        public static string GetCookie(string key)
        {
            var cookie = HttpContext.Current.Request.Cookies[key];
            return cookie.Value;
        }
    }
}
