using System.ComponentModel.DataAnnotations;

namespace LikeButtonFeature.Models
{
    public class LikeArticle
    {
        [Key]
        public int ArticleId { get; set; }
        public int LikeCount { get; set; }
    }
}
