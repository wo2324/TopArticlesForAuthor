using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopArticlesForAuthor
{
    class ArticleResult : Article
    {
        readonly internal string name;

        public ArticleResult(Article article)
        {
            if (!String.IsNullOrEmpty(article.title) || !String.IsNullOrEmpty(article.story_title))
            {
                name = !String.IsNullOrEmpty(article.title) ? article.title : article.story_title;
            }
        }
    }
}
