using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SharpArch.NHibernate.Web.Mvc;
using WebrootUI2.Domain.Contracts.Tasks;
using WebrootUI2.Domain.Contracts.Tasks.MCP;
using WebrootUI2.Domain.Contracts.Tasks.MCPRespository;
using WebrootUI2.Domain.Models;
using WebrootUI2.Domain.Models.MCP;
using WebrootUI2.Infrastructure.Common.Log;
using WebrootUI2.Web.Mvc.Controllers.Queries;
using WebrootUI2.Web.Mvc.Controllers.ViewModels;
using WebrootUI2.Web.Mvc.Filters;
using WebrootUI2.Domain;
using WebrootUI2.Web.Mvc.Helper.Filter;
using WebrootUI2.Web.Mvc.Helper.Localization;

namespace WebrootUI2.Web.Mvc.Controllers
{
    [Authorize]
    [Permissions(AllowedPermissions = new Common.AdminPermission[]{
    Common.AdminPermission.EditSystemSettings})]
    public class AcquireController : Controller
    {

        private readonly IAcquireRepository _acquireRepository;

        public AcquireController(IAcquireRepository acquireTask)
        {
            this._acquireRepository = acquireTask;
        }
        /// <summary>
        /// Fetch data from the cached users list in the page index change
        /// </summary>
        [HttpGet]
        public JsonResult PagingIndexChanged(int index)
        {
            var count = 0;
            var p = new List<Acquire>();
            var cachedAuditModel = (AcquireSystemModel)HttpContext.Cache["AcquireSystemModel"];

            if (cachedAuditModel == null)
                return Json(new { status = "failed" });

            p = cachedAuditModel.List.Skip((index - 1) * Setting.Page_Size).Take(Setting.Page_Size).ToList<Acquire>();
            count = cachedAuditModel.List.Count;

            return Json(new { status = "success", list = p, currentIndex = index, recordsCount = count }, JsonRequestBehavior.AllowGet);

        }
        [LocalizedFilter]
        public ActionResult Index()
        {
            var model = new AcquireSystemModel();
            if (HttpContext.Cache["auditModel"] != null)
            {
                var cachedAuditModel = (AcquireSystemModel)HttpContext.Cache["AcquireSystemModel"];
                model.TotalRecordsCount = cachedAuditModel.List.Count;
                model.List = cachedAuditModel.List.Take(Setting.Page_Size).ToList<Acquire>();
            }
            else
            {
                var list = _acquireRepository.GetAll().ToList();
                model.List = list.Take(Setting.Page_Size).ToList<Acquire>();
                model.TotalRecordsCount = _acquireRepository.Count();
                HttpContext.Cache["AcquireSystemModel"] = new AcquireSystemModel() { List = list };
            }
            return View(model);
        }
        public ActionResult Search(string query)
        {
            var model = new AcquireSystemModel();
            var count = 0;
            var list =
                _acquireRepository.GetAll().Where(
                p => p.Name.Contains(query)).ToList();

            count = list.Count;
            model.List = list.Take(Setting.Page_Size).ToList<Acquire>();
            HttpContext.Cache["AcquireSystemModel"] = new AcquireSystemModel() { List = list };
            model.Query = query;
            return Json(new { status = "success", list = list.Take(Setting.Page_Size).ToList<Acquire>(), recordsCount = count }
               , JsonRequestBehavior.AllowGet);
        }
        [LocalizedFilter]
        public ActionResult Create()
        {
            var model = new AcquireSystemModel();
            return View(model);
        }
        [LocalizedFilter]
        [AcceptVerbs(HttpVerbs.Post)]
        [Transaction]
        [ValidateInput(false)]
        public ActionResult Create(AcquireSystemModel model)
        {
            this.Validate(model);
            if (ModelState.IsValid)
            {
                var acquire = new Acquire();
                acquire.Name = model.Name;
                acquire.Enabled = model.Enabled;
                acquire.LogicalId = 1;
                _acquireRepository.SaveOrUpdate(acquire);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [LocalizedFilter]
        public ActionResult Edit(int id)
        {
            var model = new AcquireSystemModel();
            var acquire = _acquireRepository.Get(id);
            model.Name = acquire.Name;
            model.Enabled = acquire.Enabled;
            model.Id = acquire.Id;
            return View(model);
        }
        [LocalizedFilter]
        [AcceptVerbs(HttpVerbs.Post)]
        [Transaction]
        [ValidateInput(false)]
        public ActionResult Edit(AcquireSystemModel model)
        {
            var acquire = _acquireRepository.Get(model.Id);
            this.Validate(model);
            if (ModelState.IsValid)
            {

                acquire.Name = model.Name;
                acquire.Enabled = model.Enabled;
                _acquireRepository.SaveOrUpdate(acquire);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            var model = new AcquireSystemModel();
            var acquire = _acquireRepository.Get(id);
            model.Name = acquire.Name;
            model.Enabled = acquire.Enabled;
            model.Id = acquire.Id;
            return View(model);
        }
        [LocalizedFilter]
        [AcceptVerbs(HttpVerbs.Post)]
        [Transaction]
        [ValidateInput(false)]
        public ActionResult Delete(AcquireSystemModel model)
        {
            var acquire = _acquireRepository.Get(model.Id);

            try
            {
                _acquireRepository.Delete(acquire);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

            }


            return View(model);
        }
        [LocalizedFilter]
        public ActionResult ChangeLanguage(string culture, string urlReturn)
        {
            LanguageHelper.SetLanguage(culture);

            return Redirect(urlReturn);
        }



    }
}
