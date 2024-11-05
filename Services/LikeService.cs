using LikeButtonFeature.Interfaces;

namespace LikeButtonFeature.Service
{
    public class LikeService : ILikeService
    {
        private readonly ILikeRepository _likeRepository;
        private readonly ICacheService _cacheService;

        public LikeService(ILikeRepository likeRepository, ICacheService cacheService)
        {
            _likeRepository = likeRepository;
            _cacheService = cacheService;
        }

        public async Task<int> GetLikeCountAsync(int articleId)
        {
            // Check cache first
            var likeCount = await _cacheService.GetLikeCountAsync(articleId);
            if (likeCount == null)
            {
                likeCount = await _likeRepository.GetLikeCountAsync(articleId);
                // Cache the like count for future requests
                await _cacheService.SetLikeCountAsync(articleId, likeCount.Value);
            }
            return likeCount.Value;
        }

        public async Task IncrementLikeAsync(int articleId)
        {
            // Update in the cache and database asynchronously
            await _cacheService.IncrementLikeCountAsync(articleId);
            await _likeRepository.IncrementLikeCountAsync(articleId);
        }
    }

}
