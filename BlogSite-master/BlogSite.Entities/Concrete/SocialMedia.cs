using BlogSite.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Entities.Concrete
{
   public class SocialMedia:IEntity
    {
        public int SocialId { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string LinkedIn { get; set; }
        public string Pinterest { get; set; }
        public string WhatsApp { get; set; }
        public string StackOverFlow { get; set; }
        public string HackerNews { get; set; }

    }
}
