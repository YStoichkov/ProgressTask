namespace ProgressTask.Web.ViewModels.HtmlData
{
    using System.Collections.Generic;

    public class HtmlDataListViewModel : PagingViewModel
    {
        public IEnumerable<HtmlDataInListViewModel> HtmlData { get; set; }
    }
}
