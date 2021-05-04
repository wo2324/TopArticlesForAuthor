using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TopArticlesForAuthor
{
    class Program
    {
        #region Initialize

        internal enum User
        {
            olalonde,
            patricktomas,
            panny
        }

        static string userName;
        static int limit;
        static string baseUrl = "https://jsonmock.hackerrank.com/api/";
        static RestClient client = new RestClient { BaseUrl = new Uri(baseUrl) };

        static void InitializeData(User user)
        {
            switch (user)
            {
                case User.olalonde:
                    userName = "olalonde";
                    limit = 1;
                    break;
                case User.patricktomas:
                    userName = "patricktomas";
                    limit = 2;
                    break;
                case User.panny:
                    userName = "panny";
                    limit = 4;
                    break;
                default:
                    break;
            }
        }

        #endregion

        static void Main(string[] args)
        {
            try
            {
                InitializeData(User.panny);
                List<string> TopArticles = GetTopArticles(userName, limit);
                foreach (var item in TopArticles)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            Console.ReadLine();
        }

        static List<string> GetTopArticles(string userName, int limit)
        {
            try
            {
                List<Article> Articles = GetArticles(GetSpecification(userName, limit));
                List<ArticleFinal> ArticlesFinal = Articles.Select(x => new ArticleFinal(x)).ToList();
                return ArticlesFinal.OrderByDescending(x => x.num_comments).ThenBy(x => x.name).Select(x => x.name).Take(limit).ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        static List<Article> GetArticles(string specification)
        {
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            request.Resource = $"articles{specification}";
            var response = client.Execute(request);
            if (!response.IsSuccessful || response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(response.Content);
            }
            ArticleResponse articleResponse = JsonConvert.DeserializeObject<ArticleResponse>(response.Content);
            return articleResponse.data;
        }

        static string GetSpecification(string userName, int limit)
        {
            return $"?" +
                $"author={userName}&" +
                $"page={limit}";
        }
    }
}
