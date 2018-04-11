using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ServiceModel.Syndication;
using System.Xml;
using RSSHelper.Models;

namespace RSSHelper
{
    public class Helper : IRSSHelper
    {
        public IEnumerable<News> GetRssDataFromSource(string url)
        {
            Console.WriteLine("Reading news from RSS-channel");
            var list = new List<News>();
            var reader = XmlReader.Create(url);
            var feed = SyndicationFeed.Load(reader);
            foreach (var i in feed.Items)
            {
                list.Add(new News()
                {
                    Title = i.Title.Text,
                    Description = i.Summary.Text,
                    PublicationDate = i.PublishDate,
                    URLNews = i.Links[0].Uri.OriginalString,
                    NewsKey = String.Concat(i.Title.Text, i.PublishDate),
                    Source = new Source()
                    {
                        Name = url,
                        URL = url
                    }

                });
            }
            return list;
        }
        public int SaveRssDataToDB(List<News> list)
        {
            Console.WriteLine("Save to database...");
            var count = 0;
            using (SampleContext db = new SampleContext())
            {
                foreach (var i in list)
                {
                    if (!db.Sources.Any(x => x.URL == i.Source.URL))
                    {
                        db.Sources.Add(new Source
                        {
                            Name = i.Source.Name,
                            URL = i.Source.URL
                        });
                    }
                    db.SaveChanges();
                }
                
                foreach (var i in list)
                {
                    if (!db.News.Any(x => x.NewsKey == i.NewsKey))
                    {
                        db.News.Add(new News
                        {
                            Title = i.Title,
                            PublicationDate = i.PublicationDate,
                            Description = i.Description,
                            URLNews = i.URLNews,
                            NewsKey = i.NewsKey,
                            Source = db.Sources.FirstOrDefault(x => x.URL == i.Source.URL)
                        });
                        count++;
                    }
                    db.SaveChanges();
                }
            }
            return count;
        }
    }
}