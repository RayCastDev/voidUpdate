using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using voidUpdate.Models.Post;

namespace voidUpdate.Models.Search
{
    public class SearchResultModel
    {
        public IEnumerable<PostListingModel> Posts { get; set; }
        public string SearchQuery { get; set; }
        public bool EmptySearchResults { get; set; }
    }
}
