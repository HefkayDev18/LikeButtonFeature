using LikeButtonFeature.Data;
using LikeButtonFeature.Interfaces;
using LikeButtonFeature.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace LikeButtonFeature.Repositories
{
    public class LikeRepository : ILikeRepository
    {
        private readonly ApplicationDbContext _context;

        public LikeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int?> GetLikeCountAsync(int articleId)
        {
            return await _context.ArticleLikes
                .Where(a => a.ArticleId == articleId)
                .Select(a => a.LikeCount)
                .SingleOrDefaultAsync();
        }

        public async Task IncrementLikeCountAsync(int articleId)
        {
            var article = await _context.ArticleLikes.FindAsync(articleId);
            if (article != null)
            {
                article.LikeCount++;
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.ArticleLikes.Add(new LikeArticle { ArticleId = articleId, LikeCount = 1 });
                await _context.SaveChangesAsync();
            }
        }
    }

}
