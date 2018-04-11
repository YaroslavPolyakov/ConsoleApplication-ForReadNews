using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.ServiceModel.Syndication;
using System.Runtime.InteropServices;
using RSSHelper;
namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> sources = new List<string>
            {
                "http://www.interfax.by/authority/feed",
                //"https://www.interfax.by/news/feed"
                "http://habrahabr.ru/rss"
            };

            var helper = new RSSHelper.Helper();
            var list = new List<RSSHelper.Models.News>();

            foreach(var i in sources)
            {
                list.AddRange(helper.GetRssDataFromSource(i));
            }
            
            foreach (var i in list)
            {
                //Console.WriteLine(i.Id + "\n" + i.Title + "\n" + i.PublicationDate + "\n" + i.Description + "\n" + i.URLNews + "\n" + i.Source.Name + "\n" + i.Source.URL);
            }
            Console.WriteLine("All news was read : " + list.Count);
            var saveCount = helper.SaveRssDataToDB(list);
            Console.WriteLine("Count of news was saved: " + saveCount);
        }
    }
}
