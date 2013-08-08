using System;
using System.IO;
using System.Web.Mvc;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;

namespace WebrootUI2.Web.Mvc.Helper.Filter
{
    public class JsonFilter : ActionFilterAttribute
    {
        #region Properties

        /// <summary>
        /// Gets or sets the parameter name.
        /// </summary>
        public string Param { get; set; }

        /// <summary>
        /// Gets or sets the type of the parameter.
        /// </summary>
        public Type JsonDataType { get; set; }

        #endregion

        #region Methods

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if ((filterContext.HttpContext.Request.ContentType ?? string.Empty).Contains("application/json"))
            {
                object o =
                    new DataContractJsonSerializer(JsonDataType).ReadObject(
                        filterContext.HttpContext.Request.InputStream);

                filterContext.ActionParameters[Param] = o;
            }

            else
            {
                XElement xmlRoot = XElement.Load(new StreamReader(filterContext.HttpContext.Request.InputStream,
                                                                  filterContext.HttpContext.Request.ContentEncoding));

                object o = new XmlSerializer(JsonDataType).Deserialize(xmlRoot.CreateReader());

                filterContext.ActionParameters[Param] = o;
            }
        }

        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    var request = filterContext.HttpContext.Request;

        //    string contentType = request.ContentType;
        //    if (!string.IsNullOrEmpty(contentType) && contentType.ToLower().Contains("application/json"))
        //    {
        //        var serialiser = new DataContractJsonSerializer(this.JsonDataType);
        //        var @object = serialiser.ReadObject(request.InputStream);

        //        filterContext.ActionParameters[Param] = @object;
        //    }
        //}

        #endregion

        //public string Param { get; set; }
        //public Type JsonDataType { get; set; }

        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    if ((filterContext.HttpContext.Request.ContentType ?? string.Empty).Contains("application/json"))
        //    {
        //        object o =
        //        new DataContractJsonSerializer(JsonDataType).ReadObject(filterContext.HttpContext.Request.InputStream);
        //        filterContext.ActionParameters[Param] = o;
        //    }

        //}
    }
}