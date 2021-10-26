namespace ProgressTask.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ProgressTask.Web.ViewModels.HtmlData;

    public interface IHtmlDataService
    {
        Task CreateAsync(CreateHtmlDataInputModel input);

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 12);

        int GetCount();

        T GetById<T>(string id);
    }
}
