using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mentor.Models
{
    public class PostData
    {
        public int pkID { get; set; }
        public string Title { get; set; }
        public string Dis { get; set; }
        public List<tbl_teachers> Writers { get; set; }
        public int Writer { get; set; }
        public string Content { get; set; }
        public string Keywords { get; set; }
        public HttpPostedFileBase Image  { get; set; }
        public string ImageTitle { get; set; }
        public string ImageAlt { get; set; }
        public string m { get; set; }
        public bool? status { get; set; }
        public string imageUrl { get; set; }

    }
}