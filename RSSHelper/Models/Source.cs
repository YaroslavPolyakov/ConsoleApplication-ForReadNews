using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSHelper.Models
{
    public class Source
    {
        public int Id { get; set; }
        public string URL { get; set; }
        public string Name { get; set; }

        public virtual ICollection<News> News { get; set; }
    }
}
