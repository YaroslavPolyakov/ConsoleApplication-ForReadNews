using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSSHelper.Models;

namespace RSSHelper
{
    public interface IRSSHelper
    {
        IEnumerable<News> GetRssDataFromSource(string url);
        int SaveRssDataToDB(List<News> list);
    }
}
