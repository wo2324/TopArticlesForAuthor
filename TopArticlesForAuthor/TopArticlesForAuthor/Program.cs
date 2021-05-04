using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
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
            topArticles(userName, limit);
            Console.ReadLine();
        }

        static List<string> topArticles(string userName, int limit)
        {
            List<string> Articles = new List<string>();
            return Articles;
        }
    }
}
