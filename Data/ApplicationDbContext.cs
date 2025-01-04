using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using zltArticle.Models;

namespace zltArticle.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Article> Article { get; set; } = default!;
        public DbSet<ArticleGroup> ArticleGroup { get; set; } = default!;



    }
}
