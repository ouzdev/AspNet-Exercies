using BlogSite.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Entities.Concrete
{
   public class SiteSetting:IEntity
    {
        public int SiteSettingId { get; set; }
        public string Title { get; set; }
        public string Keywords { get; set; }
        public string FaviconUrl { get; set; }
        public string Author { get; set; }
        public string  GoogleAnalytic { get; set; }
        public string FacebookUrl { get; set; }
        public string LinkedInUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string Description { get; set; }
        public string FooterDescription { get; set; }

    }
}
