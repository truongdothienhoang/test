using System;

namespace WebrootUI2.Web.Mvc.Helper.PagingHelper
{
    public class PagedList
    {

        public int ItemCount
        {
            get;
            set;
        }

        public int PageCount
        {
            get { return (int)Math.Ceiling((double)this.ItemCount / this.PageSize); }
        }

        public int PageIndex
        {
            get;
            set;
        }

        public int PageSize
        {
            get;
            set;
        }

        public bool IsPreviousPage
        {
            get
            {
                return (PageIndex > 0);
            }
        }

        public bool IsNextPage
        {
            get
            {
                return (PageIndex + 1) * PageSize <= ItemCount;
            }
        }
    }
}
