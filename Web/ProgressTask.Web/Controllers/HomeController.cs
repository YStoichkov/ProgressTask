namespace ProgressTask.Web.Controllers
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using ProgressTask.Data.Models;
    using ProgressTask.Services.Data;
    using ProgressTask.Web.ViewModels;
    using ProgressTask.Web.ViewModels.HtmlData;

    public class HomeController : BaseController
    {
        private readonly IHtmlDataService service;

        public HomeController(IHtmlDataService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [RequestSizeLimit(5000000)]
        public async Task<IActionResult> Create(CreateHtmlDataInputModel input)
        {
            try
            {
                await this.service.CreateAsync(input);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(input);
            }

            return this.RedirectToAction("Index");
        }

        public IActionResult All(int id = 1)
        {
            const int ItemsPerPage = 12;
            var viewModel = new HtmlDataListViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                DataCount = this.service.GetCount(),
                HtmlData = this.service.GetAll<HtmlDataInListViewModel>(id, ItemsPerPage),
            };
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult ParseHtml(HtmlDataInListViewModel inputModel)
        {
            var model = new HtmlData
            {
                OriginalText = inputModel.OriginalText,
            };
            return this.View(model);
        }

        public IActionResult ById(string id)
        {
            var htmlModel = this.service.GetById<SingleHtmlViewModel>(id);

            return this.View(htmlModel);
        }

        public IActionResult SiteError(int errorCode)
        {
            return this.View();
        }
    }
}
