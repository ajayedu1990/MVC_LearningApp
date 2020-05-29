using LearningApp.ApiRepository;
using LearningApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace LearningApp.Controllers.WebApiController
{
    [RoutePrefix("api")]
    public class ApiAdminController : ApiController
    {
        IApiAdminRepository _apiAdminRepository;

        public ApiAdminController(IApiAdminRepository apiAdminRepository)
        {
            _apiAdminRepository = apiAdminRepository;
        }

        [Route("createarticle")]
        public IHttpActionResult CreateArticle(ArticleDetails articleDetails)
        {
            string response = _apiAdminRepository.CreateArticle(articleDetails);
            if (response == "success")
                return Ok();
            else
                return BadRequest();
        }
    }
}
