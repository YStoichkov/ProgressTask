namespace ProgressTask.Web.ViewModels.HtmlData
{
    using System;

    using ProgressTask.Data.Models;
    using ProgressTask.Services.Mapping;

    public class SingleHtmlViewModel : IMapFrom<HtmlData>
    {
        public string Id { get; init; }

        public DateTime CreatedOn { get; init; }

        public DateTime? ModifiedOn { get; init; }

        public string OriginalText { get; init; }

        public string ModifiedText { get; init; }
    }
}
