using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using SharpArch.NHibernate;
using WebrootUI2.Domain.Contracts.Tasks.MCP;
using WebrootUI2.Domain.Contracts.Tasks.MCPRespository;
using WebrootUI2.Domain.Models.MCP;

namespace WebrootUI2.Infrastructure.MCP
{
    public class AcquireRespository : NHibernateRepositoryWithTypedId<Acquire, int>, IAcquireRepository
    {

        public Acquire GetName(string name)
        {
            var criteria = this.Session.CreateCriteria(typeof(Acquire)).Add(Restrictions.Eq("Name", name));

            if (criteria.List().Count > 0)
            {
                var p = (Acquire)criteria.List()[0];
                return p;
            }
            return new Acquire();
        }

        public IList<Acquire> GetByIndex(int pageIndex, int pageItem)
        {
            ICriteria criteria = Session.CreateCriteria(typeof(Acquire))
               .AddOrder(Order.Desc("Id"))
               .SetFirstResult(pageIndex * pageItem)
               .SetMaxResults(pageItem);

            return criteria.List<Acquire>() as List<Acquire>;
        }

        public int Count()
        {
            ICriteria criteria = Session.CreateCriteria(typeof(Acquire))
                .SetProjection(Projections.Count("Id"));

            return (int)criteria.UniqueResult();
        }
    }
}
