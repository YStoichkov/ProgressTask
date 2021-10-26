namespace ProgressTask.Web.ViewModels.HtmlData
{
    using System;
    using System.Net;
    using System.Text.RegularExpressions;

    using ProgressTask.Data.Models;
    using ProgressTask.Services.Mapping;

    public class HtmlDataInListViewModel : IMapFrom<HtmlData>
    {
        public string Id { get; init; }

        public string OriginalText { get; init; }

        public string ShortContent
        {
            get
            {
                var content = this.OriginalText;
                return content.Length > 60
                        ? content.Substring(0, 60) + "..."
                        : content;
            }
        }

        public DateTime CreatedOn { get; init; }
    }
}
