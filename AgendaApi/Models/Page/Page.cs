using System.Collections.Generic;

namespace AgendaApi.Models.Page
{
    public class Page<T>
    {
        public List<T> Data { get; set; }
        public PageMetadata Meta { get; set; }
    }
}