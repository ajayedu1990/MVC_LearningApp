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
    }
}