namespace LikeButtonFeature.Interfaces
{
    public interface ILikeRepository
    {
        Task<int?> GetLikeCountAsync(int articleId);
        Task IncrementLikeCountAsync(int articleId);
    }
}
