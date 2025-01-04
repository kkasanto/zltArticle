using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using zltArticle.Data;
using zltArticle.Models;

namespace zltArticle.Pages.manage
{
    public class articlegroupModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        // ** Constructor
        public articlegroupModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // ** Properties
        [BindProperty]
        public ArticleGroup NewArticle { get; set; }

        public IList<ArticleGroup> ArticleGroup { get; set; } = default!;


        // ** Methods
        public async Task OnGetAsync()
        {
            ArticleGroup = await _context.ArticleGroup
                .Include(static z => z.Articles.OrderBy(x => x.ArticleSortOrder))
                .OrderByDescending(x => x.ArticleGroupCreateDate)
                .ToListAsync();
        }

        // Save new record
        public async Task OnPostSaveNew(string NewArticleGroupName, string NewArticleGroupActive)
        {

            // Because the bool checkbox is not coming from a property - we have to do the conversion ourselves
            if (NewArticleGroupName != null)
            {
                var Acti = true;
                if (NewArticleGroupActive == null)
                    Acti = false;


                _context.ArticleGroup.Add(new ArticleGroup
                {
                    ArticleGroupActive = Acti,
                    ArticleGroupName = NewArticleGroupName
                });
                _context.SaveChanges();
            }

            // Rereads intial data
            await OnGetAsync();
        }


        // Save updated fields
        public async Task OnPostSaveUpdate(string UpdGroupName, bool UpdGrpActive, int Id)
        {
            var RecToUpdate = _context.ArticleGroup.FirstOrDefault(x => x.ArticleGroupId == Id);

            if (UpdGroupName != null)
            {
                {
                    if (RecToUpdate != null)
                    {
                        RecToUpdate.ArticleGroupName = UpdGroupName;
                        RecToUpdate.ArticleGroupActive = UpdGrpActive;
                    }
                    _context.SaveChanges();
                }
            }

            await OnGetAsync();
        }


        // Delete record
        public async Task OnPostDelete(int Id)
        {

            var delpost = _context.ArticleGroup.SingleOrDefault(x => x.ArticleGroupId.Equals(Id));

            if (delpost != null)
            {
                _context.ArticleGroup.Remove(delpost);
                _context.SaveChanges();
            }

            await OnGetAsync();
        }

    }
}
