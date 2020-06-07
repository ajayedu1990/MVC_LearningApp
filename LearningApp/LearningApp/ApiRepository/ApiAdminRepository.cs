using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using LearningApp.Models;

namespace LearningApp.ApiRepository
{
    public class ApiAdminRepository : IApiAdminRepository
    {
        ISQLHelper _sqlHelper;

        public ApiAdminRepository(ISQLHelper sqlHelper)
        {
            _sqlHelper = sqlHelper;
        }

        public string CreateArticle(ArticleDetails article)
        {
            try
            {
                var conn = _sqlHelper.GetSQLConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand("createarticle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@articleName", article.ArticleName);
                cmd.Parameters.AddWithValue("@articleType", article.ArticleType);
                cmd.Parameters.AddWithValue("@isSeries", article.IsSeries);
                if (article.IsSeries)
                {
                    if (article.RelatedArticles.Count > 1)
                    {
                        cmd.Parameters.AddWithValue("@firstRelatedArticle", article.RelatedArticles[0]);
                        cmd.Parameters.AddWithValue("@secondRelatedArticle",
                            article.RelatedArticles[1] != null ? article.RelatedArticles[1] : "");
                    }
                    else
                        cmd.Parameters.AddWithValue("@firstRelatedArticle", article.RelatedArticles[0]);
                }
                cmd.Parameters.AddWithValue("@articleContent", article.ArticleContent);

                int rowsaffected = cmd.ExecuteNonQuery();

                conn.Close();

                if (rowsaffected > 0)
                {
                    return "success";
                }
                else
                {
                    return "failure";
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public List<ArticleDetails> GetArticleList()
        {
            List<ArticleDetails> articles = new List<ArticleDetails>();
            
            var conn = _sqlHelper.GetSQLConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("GetArticlesList", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    string[] related = new string[2];
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ArticleDetails article = new ArticleDetails();
                            article.RelatedArticles = new List<string>();
                            for (int i = 0; i < 1; i++)
                            {
                                article.ArticleID = reader.GetInt32(i);
                                article.ArticleName = reader.GetString(i + 1);
                                article.ArticleType = reader.GetString(i + 2);
                                article.IsSeries = reader.GetBoolean(i + 3);
                                related = reader.IsDBNull(i + 4) ? null : reader.GetString(i + 4).Split(',');
                                if (related != null)
                                {
                                    foreach (string id in related)
                                    {
                                        article.RelatedArticles.Add(id);
                                    }
                                }
                                else
                                    article.RelatedArticles = null;
                            }
                            articles.Add(article);
                        }
                    }
                }
                return articles;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<string> GetArticleNames()
        {
            List<string> articleNames = new List<string>();
            var conn = _sqlHelper.GetSQLConnection();
            try
            {   
                conn.Open();
                SqlCommand cmd = new SqlCommand("GetArticleNames", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            for(int i = 0; i < reader.FieldCount ; i++)
                            {
                                articleNames.Add(reader.GetString(i));
                            }
                        }
                    }
                }
                conn.Close();
                return articleNames;
            }
            catch(Exception ex)
            {
                conn.Close();
                throw ex;
            }
        }
    }
}