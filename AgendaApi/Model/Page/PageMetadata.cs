using System;

namespace AgendaApi.Model.Page
{
    public class PageMetadata
    {
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public int? PrevPage { get; set; }
        public int? NextPage { get; set; }
        public int LastPage { get; set; }
        public int Step { get; set; }

        public PageMetadata(int page, int limit, int count)
        {
            var lastPage = (int) Math.Ceiling((decimal) count / limit);
            TotalCount = count;
            CurrentPage = page;
            PrevPage = page + 1 <= lastPage ? page + 1 : null;
            NextPage = page - 1 > 0 ? page - 1 : null;
            LastPage = lastPage;
            Step = limit;
        }
    }
}