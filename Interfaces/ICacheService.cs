namespace LikeButtonFeature.Interfaces
{
    public interface ICacheService
    {
        Task<int?> GetLikeCountAsync(int articleId);
        Task SetLikeCountAsync(int articleId, int likeCount);
        Task IncrementLikeCountAsync(int articleId);
    }
}
