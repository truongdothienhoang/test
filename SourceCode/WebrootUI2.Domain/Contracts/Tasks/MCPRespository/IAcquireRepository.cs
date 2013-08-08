using System.Collections.Generic;
using SharpArch.Domain.PersistenceSupport;
using WebrootUI2.Domain.Models.MCP;

namespace WebrootUI2.Domain.Contracts.Tasks.MCPRespository
{
    public interface IAcquireRepository : IRepositoryWithTypedId<Acquire, int>
    {

        Acquire GetName(string name);
        IList<Acquire> GetByIndex(int pageIndex, int pageItem);
        int Count();
    }
}
