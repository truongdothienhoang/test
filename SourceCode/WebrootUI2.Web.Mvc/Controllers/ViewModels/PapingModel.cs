namespace WebrootUI2.Web.Mvc.Controllers.ViewModels
{
    public abstract class PagingModel
    {
        public PagingModel()
        {
            Paging = new PagedList();
        }
        public PagedList Paging { get; set; }
        public string MessegerError { get; set; }
    }
}
