using System;
using System.ComponentModel;
using System.Threading;
using System.Web;
using NHibernate.Validator.Constraints;

namespace WebrootUI2.Web.Mvc.Helper.Localization
{

    public class DisplayNameLocalizedAttribute : DisplayNameAttribute
    {
        private readonly string m_ResourceName;
        private readonly string m_ClassName;
        public DisplayNameLocalizedAttribute(string className, string resourceName)
        {
            m_ResourceName = resourceName;
            m_ClassName = className;
        }

        public override string DisplayName
        {
            get
            {
                // get and return the resource object
                return HttpContext.GetGlobalResourceObject(
                       m_ClassName,
                       m_ResourceName,
                       Thread.CurrentThread.CurrentCulture).ToString();
            }
        }
    }
    [Serializable]
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class NotNullNotEmptyLocalized : NotNullNotEmptyAttribute
    {
        private readonly string m_ResourceName;
        private readonly string m_ClassName;
        public NotNullNotEmptyLocalized(string className, string resourceName)
        {
            m_ResourceName = resourceName;
            m_ClassName = className;
            Message = HttpContext.GetGlobalResourceObject(
                       m_ClassName,
                       m_ResourceName,
                       Thread.CurrentThread.CurrentCulture).ToString();
        }
    }
    [Serializable]
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class IsNumericLocalized : IsNumericAttribute
    {
        private readonly string m_ResourceName;
        private readonly string m_ClassName;
        public IsNumericLocalized(string className, string resourceName)
        {
            m_ResourceName = resourceName;
            m_ClassName = className;
            Message = HttpContext.GetGlobalResourceObject(
                       m_ClassName,
                       m_ResourceName,
                       Thread.CurrentThread.CurrentCulture).ToString();
        }
    }
    [Serializable]
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class LengthLocalized : LengthAttribute
    {
        private readonly string m_ResourceName;
        private readonly string m_ClassName;
        public LengthLocalized(int min, int max, string className, string resourceName)
        {
            m_ResourceName = resourceName;
            m_ClassName = className;
            Min = min;
            Max = max;
            Message = HttpContext.GetGlobalResourceObject(
                       m_ClassName,
                       m_ResourceName,
                       Thread.CurrentThread.CurrentCulture).ToString() + "(" + min + "," + max + ") characters";
        }
        public LengthLocalized(int max, string className, string resourceName)
        {
            m_ResourceName = resourceName;
            m_ClassName = className;
            Max = max;
            Message = HttpContext.GetGlobalResourceObject(
                       m_ClassName,
                       m_ResourceName,
                       Thread.CurrentThread.CurrentCulture).ToString() + "(" + max + ") characters";
        }
    }
    [Serializable]
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class EmailLocalized : EmailAttribute
    {
        private readonly string m_ResourceName;
        private readonly string m_ClassName;
        public EmailLocalized(string className, string resourceName)
        {
            m_ResourceName = resourceName;
            m_ClassName = className;
            Message = HttpContext.GetGlobalResourceObject(
                       m_ClassName,
                       m_ResourceName,
                       Thread.CurrentThread.CurrentCulture).ToString();
        }
    }
}

