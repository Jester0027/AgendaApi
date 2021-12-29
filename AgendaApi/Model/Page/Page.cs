using System.Collections.Generic;

namespace AgendaApi.Model.Page
{
    public class Page<T>
    {
        public List<T> Data { get; set; }
        public PageMetadata Meta { get; set; }
    }
}