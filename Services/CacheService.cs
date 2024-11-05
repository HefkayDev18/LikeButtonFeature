using LikeButtonFeature.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;

public class CacheService : ICacheService
{
    private readonly IMemoryCache _memoryCache;

    public CacheService(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    public Task<int?> GetLikeCountAsync(int articleId)
    {
        if (_memoryCache.TryGetValue($"article:{articleId}:likes", out int likeCount))
        {
            return Task.FromResult<int?>(likeCount);
        }
        return Task.FromResult<int?>(null);
    }

    public Task SetLikeCountAsync(int articleId, int likeCount)
    {
        _memoryCache.Set($"article:{articleId}:likes", likeCount);
        return Task.CompletedTask;
    }

    public Task IncrementLikeCountAsync(int articleId)
    {
        _memoryCache.TryGetValue($"article:{articleId}:likes", out int likeCount);
        likeCount++;
        _memoryCache.Set($"article:{articleId}:likes", likeCount);
        return Task.CompletedTask;
    }
}
