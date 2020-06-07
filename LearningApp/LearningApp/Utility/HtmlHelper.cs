using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using LearningApp.Models;
using Newtonsoft.Json;

namespace LearningApp.Utility
{
    public class HtmlHelperClass : IHtmlHelpers
    {
        public async Task<string> CreateArticleAsync(ArticleDetails article)
        {
            using (var client = await GetClientAsync())
            {
                var serializeContent = JsonConvert.SerializeObject(article);
                var content = new StringContent(serializeContent);

                var response = await client.PostAsJsonAsync("createarticle", article);

                if (response.IsSuccessStatusCode)
                {
                    return "success";
                }
                else
                {
                    return "not success";
                }
            }
        }

        public async Task<List<ArticleDetails>> GetArticleList()
        {
            List<ArticleDetails> articles = new List<ArticleDetails>();

            try
            {
                using(var client = await GetClientAsync())
                {
                    var response = await client.GetAsync("getarticlelist");

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        articles = JsonConvert.DeserializeObject<List<ArticleDetails>>(content);
                    }
                }
                return articles; 
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<string>> GetArticleNames()
        {
            try
            {
                using (var client = await GetClientAsync())
                {
                    var response = await client.GetAsync("getarticlenames");

                    var content = await response.Content.ReadAsStringAsync();

                    List<string> articleNames = JsonConvert.DeserializeObject<List<string>>(content);

                    return articleNames;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<HttpClient> GetClientAsync()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            client.BaseAddress = new Uri("http://localhost:51509/api/");
            return client;
        }
    }
}