using LearningApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Utility
{
    public interface IHtmlHelpers
    {
        Task<HttpClient> GetClientAsync();

        Task<string> CreateArticleAsync(ArticleDetails article);

        Task<List<string>> GetArticleNames();
    }
}
