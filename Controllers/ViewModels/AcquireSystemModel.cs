using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebrootUI2.Domain.Models.MCP;
using WebrootUI2.Web.Mvc.Helper.Localization;

namespace WebrootUI2.Web.Mvc.Controllers.ViewModels
{
    public class AcquireSystemModel
    {
        public AcquireSystemModel()
        {
            List = new List<Acquire>();
        }
        public int Id { get; set; }
        [NotNullNotEmptyLocalized("ValidatorResources", "IsNullOrEmpty")]
        [LengthLocalized(200, "ValidatorResources", "MaxRange")]
        [DisplayNameLocalized("CmResources", "Name")]
        public string Name { get; set; }
        [DisplayNameLocalized("CmResources", "Enable")]
        public bool Enabled { get; set; }
        public List<Acquire> List { get; set; }
        public string Query { get; set; }
        public int TotalRecordsCount { get; set; }

    }
}