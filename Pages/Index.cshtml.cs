using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using zltArticle.Data;
using zltArticle.Models;

namespace zltArticle.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public List<Article> LastArticles { get; set; }


        public int CountGroups;
        public int CountArticles;


        public void OnGet()
        {
            CountGroups = _context.ArticleGroup.Count();
            CountArticles = _context.Article.Count();

            LastArticles = _context.Article.OrderByDescending(x => x.ArticleDateTime)
                    .Include(s => s.ArticleGroup)
                    .Take(3)
                    .ToList();
        }
    }
}
