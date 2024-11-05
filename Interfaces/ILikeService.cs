namespace LikeButtonFeature.Interfaces
{
    public interface ILikeService
    {
        Task<int> GetLikeCountAsync(int articleId);
        Task IncrementLikeAsync(int articleId);
    }
}
