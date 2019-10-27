using System.Collections.Generic;
using System.Threading.Tasks;
using voidUpdate.Data.Models;

namespace voidUpdate.Data
{
    public interface IPost
    {
        Post GetById(int id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetFilteredPosts(string searchQuery);
        IEnumerable<Post> GetPostsByForum(int id);

        Task Add(Post post); 
        Task Delete(int id);
        Task Edit(int id, string newContent);

        Task AddReply(PostReply reply);
      
    }
}
