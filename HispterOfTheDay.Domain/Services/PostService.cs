using HispterOfTheDay.Domain.Repositories;

namespace HispterOfTheDay.Domain.Services
{
    public class PostService : IPostService
    {
        readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
    }
}
