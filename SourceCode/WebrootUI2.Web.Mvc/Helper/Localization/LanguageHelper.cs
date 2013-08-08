using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Web;

namespace WebrootUI2.Web.Mvc.Helper.Localization
{
    public static class LanguageHelper
    {
        private const string LanguageKey = "lukeportallanguage";

        public static void SetLanguage(string language)
        {


            CultureInfo culture = new CultureInfo(language);

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            var cookie = HttpContext.Current.Request.Cookies[LanguageKey];
            cookie.Value = language;
            HttpContext.Current.Response.Cookies.Add(cookie);

        }

        public static string GetLanguage()
        {
            var cookie = HttpContext.Current.Request.Cookies[LanguageKey];
            if (cookie == null)
            {
                cookie = new HttpCookie(LanguageKey, "en-US");
                // set the cookie's expiration date 
                cookie.Expires = DateTime.Now.AddDays(10);
                // set the cookie on client's browser
                HttpContext.Current.Response.Cookies.Add(cookie);
            }


            return cookie.Value;
        }
        public static Language GetLanguage(string culture)
        {
            Language lang = null;
            foreach (var language in GetUiLanguages())
            {
                if (language.Culture == culture)
                    return language;
            }
            return lang;
        }
        public static string GetLanguageDefault()
        {
            return "en-US";
        }
        public static List<Language> GetVersionLanguages(string cultureDefault)
        {
            var list = new List<Language>();

            foreach (var uiLanguage in GetUiLanguages())
            {
                if (uiLanguage.Culture != cultureDefault)
                    list.Add(uiLanguage);
            }
            return list;
        }
        public static List<Language> GetUiLanguages()
        {
            return new List<Language>()
                       {
                         
                           new Language("zh-CN","Chine"),
                             new Language("en-US", "Enghlish"),
                       };
        }
        public static string ShortCulture(string culture)
        {
            var s = culture.Split('-');
            return s[0];
        }

    }
    public class Language
    {
        public Language(string culture, string languageName)
        {
            Culture = culture;
            LanguageName = languageName;
        }

        public string Culture { get; set; }

        public string LanguageName { get; set; }
    }


}
