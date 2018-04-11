using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSHelper.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTimeOffset PublicationDate { get; set; }
        public string Description { get; set; }
        public string URLNews { get; set; }
        public String NewsKey { get; set; }

        public virtual Source Source { get; set; }
    }
}
