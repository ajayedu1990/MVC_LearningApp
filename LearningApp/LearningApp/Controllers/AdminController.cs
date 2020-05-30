using LearningApp.Models;
using LearningApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LearningApp.Controllers
{
    public class AdminController : Controller
    {
        IAdminRepository _adminRepository;

        public AdminController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> AddArticle()
        {
            ArticleDetails article = new ArticleDetails();
            article.RelatedArticles = await _adminRepository.GetArticleNames();
            return View(article);
        }

        [HttpPost]
        public async Task<ActionResult> CreateArticle(ArticleDetails article)
        {
            string articleName = await _adminRepository.CreateArticle(article);
            ViewBag.ArticleName = articleName;
            return View();

        }

        public ActionResult TestAction(ArticleDetails article)
        {
            return View(article);
        }
    }
}