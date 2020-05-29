using LearningApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.ApiRepository
{
    public interface IApiAdminRepository
    {
        string CreateArticle(ArticleDetails article);
    }
}
