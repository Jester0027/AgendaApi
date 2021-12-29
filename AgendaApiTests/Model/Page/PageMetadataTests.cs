using System;
using AgendaApi.Model.Page;
using Xunit;

namespace AgendaApiTests.Model.Page
{
    public class PageMetadataTests
    {
        [Fact]
        public void PaginationMetadata_5ItemsFirstPage()
        {
            var meta = new PageMetadata(1, 10, 5);
            
            Assert.Equal(10, meta.Step);
            Assert.Equal(1, meta.CurrentPage);
            Assert.Equal(1, meta.LastPage);
            Assert.Null(meta.PrevPage);
            Assert.Null(meta.NextPage);
            Assert.Equal(5, meta.TotalCount);
        }
        
        [Fact]
        public void PaginationMetadata_20ItemsFirstPage()
        {
            var meta = new PageMetadata(1, 10, 20);
            
            Assert.Equal(10, meta.Step);
            Assert.Equal(1, meta.CurrentPage);
            Assert.Equal(2, meta.LastPage);
            Assert.Null(meta.PrevPage);
            Assert.Equal(2, meta.NextPage);
            Assert.Equal(20, meta.TotalCount);
        }
        
        [Fact]
        public void PaginationMetadata_20ItemsLastPage()
        {
            var meta = new PageMetadata(2, 10, 20);
            
            Assert.Equal(10, meta.Step);
            Assert.Equal(2, meta.CurrentPage);
            Assert.Equal(2, meta.LastPage);
            Assert.Equal(1, meta.PrevPage);
            Assert.Null(meta.NextPage);
            Assert.Equal(20, meta.TotalCount);
        }
    }
}