using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace zltArticle.Models
{
    public class Article
    {
        [Key]
        public int ArticleId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string ArticleTitle { get; set; }
        public string? ArticleHeader { get; set; }
        public string? ArticleText { get; set; }
        public bool ArticlePublished { get; set; } = true;
        public DateTime ArticleDateTime { get; set; } = DateTime.Now;
        public string? ArticleAuthor { get; set; }
        public int? ArticleSortOrder { get; set; }

        [ForeignKey(nameof(ArticleGroup))]
        public int ArticleGroupId { get; set; }
        public virtual ArticleGroup? ArticleGroup { get; set; }

    }

    public class ArticleGroup
    {

        [Key]
        public int ArticleGroupId { get; set; }

        [Required(ErrorMessage = "Groupname is required")]
        public string ArticleGroupName { get; set; }
        public DateTime ArticleGroupCreateDate { get; set; } = DateTime.Now;
        public bool ArticleGroupActive { get; set; } = true;

        public ICollection<Article>? Articles { get; set; }
    }

}
