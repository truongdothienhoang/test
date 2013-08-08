using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpArch.Domain.DomainModel;

namespace WebrootUI2.Domain.Models.MCP
{
    public class Acquire : EntityWithTypedId<int>
    {
        public virtual string Name { get; set; }
        public virtual bool Enabled { get; set; }
        public virtual int LogicalId { get; set; }
    }
}
