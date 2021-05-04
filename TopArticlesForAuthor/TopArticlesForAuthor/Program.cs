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
        static string baseUrl = "https://jsonmock.hackerrank.com/api/";
        static RestClient client = new RestClient { BaseUrl = new Uri(baseUrl) };

        static void Main(string[] args)
        {
            string userName = "olalonde";
            int limit = 1;
            topArticles(GetSpecification(userName, limit));
            Console.ReadLine();
        }

        static List<string> topArticles(string specification)
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

            List<string> Articles = new List<string>();
            return Articles;
        }

        static string GetSpecification(string userName, int limit)
        {
            return $"?" +
                $"author={userName}&" +
                $"page={limit}";
        }
    }
}
