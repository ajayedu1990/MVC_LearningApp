using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearningApp.Models
{
    public class ArticleDetails
    {
        [HiddenInput(DisplayValue=false)]
        public int ArticleID { get; set; }

        [Required(AllowEmptyStrings =false,ErrorMessage = "please enter the article Name")]
        public string ArticleName
        {
            get;
            set;
        }

        [Required(ErrorMessage = "please choose Article Type")]
        public string ArticleType
        {
            get;
            set;
        }

        [Required(ErrorMessage = "please choose IsSeries")]
        public bool IsSeries
        {
            get;
            set;
        }

        public List<string> RelatedArticles
        {
            get;
            set;
        }

        [Required(AllowEmptyStrings =false,ErrorMessage = "please enter the article content")]
        public string ArticleContent
        {
            get;
            set;
        }
    }

    public class ArticleType
    {
        public string Type
        {
            get;
            set;
        }
    }
}