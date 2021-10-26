namespace ProgressTask.Data.Models
{
    using System;

    using ProgressTask.Data.Common.Models;

    public class HtmlData : BaseModel<string>
    {
        public HtmlData()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string OriginalText { get; init; }

        public string ModifiedText { get; init; }
    }
}
