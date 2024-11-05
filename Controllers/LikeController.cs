using LikeButtonFeature.Interfaces;
using LikeButtonFeature.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LikeButtonFeature.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController(ILikeService likeService) : ControllerBase
    {
        private readonly ILikeService _likeService = likeService;


        [HttpGet("{articleId}/like-count")]
        public async Task<IActionResult> GetLikeCount(int articleId)
        {
            int likeCount = await _likeService.GetLikeCountAsync(articleId);
            return Ok(new { ArticleId = articleId, LikeCount = likeCount });
        }

        [HttpPost("{articleId}/like")]
        public async Task<IActionResult> LikeArticle(int articleId)
        {
            await _likeService.IncrementLikeAsync(articleId);
            return Ok(new { ArticleId = articleId, Message = "Liked successfully!" });
        }

    }
}
