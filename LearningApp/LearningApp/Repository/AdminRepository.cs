using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using LearningApp.Models;
using LearningApp.Utility;

namespace LearningApp.Repository
{
    public class AdminRepository : IAdminRepository
    {
        IHtmlHelpers _helper;
        public AdminRepository(IHtmlHelpers helper)
        {
            _helper = helper;
        }

        public async Task<string> CreateArticle(ArticleDetails article)
        {
            string name = await _helper.CreateArticleAsync(article);
            return name;
        }

        public async Task<List<string>> GetArticleNames()
        {
            List<string> articleNames = await _helper.GetArticleNames();
            return articleNames;
        }

        public string DeleteArticle(int ArticleID)
        {
            throw new NotImplementedException();
        }

        public string EditArticle(int ArticleID)
        {
            throw new NotImplementedException();
        }

        public List<ArticleDetails> GetArticles()
        {
            throw new NotImplementedException();
        }

        public List<ArticleDetails> GetSearchArticles(string searchString)
        {
            throw new NotImplementedException();
        }
    }
}