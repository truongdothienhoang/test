using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebrootUI2.Domain.Models.MCP;

namespace WebrootUI2.Infrastructure.NHibernateMaps.MCP
{
    class AcquireMap : ClassMap<Acquire>
    {
        public AcquireMap()
        {
            this.Table("MCP_Acquirer");
            this.Id(x => x.Id, "Id")
                .UnsavedValue(0)
                .GeneratedBy.Identity();
            this.Map(c => c.Name, "Name");
            this.Map(c => c.Enabled, "Enabled");
            this.Map(c => c.LogicalId, "LogicalId");
        }
    }
}
