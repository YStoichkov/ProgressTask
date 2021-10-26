namespace ProgressTask.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ProgressTask.Data.Common.Repositories;
    using ProgressTask.Data.Models;
    using ProgressTask.Services.Mapping;
    using ProgressTask.Web.ViewModels.HtmlData;

    public class HtmlDataService : IHtmlDataService
    {
        private readonly IRepository<HtmlData> repository;

        public HtmlDataService(IRepository<HtmlData> repository)
        {
            this.repository = repository;
        }

        public async Task CreateAsync(CreateHtmlDataInputModel input)
        {
            var htmldata = new HtmlData
            {
                OriginalText = input.OriginalText,
                CreatedOn = DateTime.UtcNow,
            };
            await this.repository.AddAsync(htmldata);
            await this.repository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 12)
        {
            var htmlData = this.repository.AllAsNoTracking()
              .OrderByDescending(x => x.CreatedOn)
              .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
              .To<T>().ToList();
            return htmlData;
        }

        public T GetById<T>(string id)
        {
            var htmlData = this.repository.AllAsNoTracking().Where(x => x.Id == id)
                 .To<T>().FirstOrDefault();
            return htmlData;
        }

        public int GetCount()
        {
            return this.repository.All().Count();
        }
    }
}
