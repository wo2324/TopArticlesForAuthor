using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopArticlesForAuthor
{
    class ArticleFinal : Article
    {
        readonly internal string name;

        public ArticleFinal(Article article)
        {
            if (!String.IsNullOrEmpty(article.title) || !String.IsNullOrEmpty(article.story_title))
            {
                name = !String.IsNullOrEmpty(article.title) ? article.title : article.story_title;
            }
            this.title = article.title;
            this.url = article.url;
            this.author = article.author;
            this.num_comments = article.num_comments;
            this.story_id = article.story_id;
            this.story_title = article.story_title;
            this.story_url = article.story_url;
            this.parent_id = article.parent_id;
            this.created_at = article.created_at;
        }
    }
}
