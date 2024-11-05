using LikeButtonFeature.Models;
using Microsoft.EntityFrameworkCore;

namespace LikeButtonFeature.Data
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<LikeArticle> ArticleLikes { get; set; }
    }
    
}
