using System;
using System.Web.Compilation;

namespace WebrootUI2.Web.Mvc.Helper.Localization
{
    public class ResourceHelper
    {
        public virtual string GetString(string expression, params object[] args)
        {
            ResourceExpressionFields fields = GetResourceFields(expression, "~/");
            if (string.IsNullOrEmpty(fields.ClassKey))
                throw new InvalidOperationException("The resource helper does not support local resources.");

            return GetGlobalResource(fields, args);
        }

        protected string GetGlobalResource(ResourceExpressionFields fields, object[] args)
        {
            return ResourceExtensions.GetGlobalResource(fields, args);
        }

        protected ResourceExpressionFields GetResourceFields(string expression, string virtualPath)
        {
            return ResourceExtensions.GetResourceFields(expression, virtualPath);
        }

    }
}