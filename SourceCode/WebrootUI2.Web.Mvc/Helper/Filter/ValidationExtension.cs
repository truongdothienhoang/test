using System.Web.Mvc;
using NHibernate.Validator.Cfg;
using NHibernate.Validator.Engine;

namespace WebrootUI2.Web.Mvc.Helper.Filter
{
    public static class ValidationExtension
    {
        public static void Validate(this Controller controller, object entity)
        {
            controller.ModelState.Clear();
            ValidatorEngine vtor = Environment.SharedEngineProvider.GetEngine();
            InvalidValue[] errors = vtor.Validate(entity);      
            foreach (InvalidValue error in errors)
            {
                controller.ModelState.AddModelError(error.PropertyName, error.Message);
            }

        }
    }
}