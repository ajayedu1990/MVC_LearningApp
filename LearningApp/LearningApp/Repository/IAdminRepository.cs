using LearningApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Repository
{
    public interface IAdminRepository
    {
        List<ArticleDetails> GetArticles();
        List<ArticleDetails> GetSearchArticles(string searchString);
        string EditArticle(int ArticleID);
        string DeleteArticle(int ArticleID);
        Task<string> CreateArticle(ArticleDetails article);
    }
}
