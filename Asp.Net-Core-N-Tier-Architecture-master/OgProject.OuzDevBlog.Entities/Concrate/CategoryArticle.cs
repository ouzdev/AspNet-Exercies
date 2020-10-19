using OgProject.OuzDevBlog.Entities.Abstract;

namespace OgProject.OuzDevBlog.Entities.Concrate
{
    public class CategoryArticle:ITable
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }
       
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
