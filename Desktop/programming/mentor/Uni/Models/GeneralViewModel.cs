using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mentor.Models
{
    public class GeneralViewModel
    {
        public tbl_pages page { get; set; }
        public List<View_courses> courses { get; set; }
        public List<View_teachers> teachers { get; set; }
        public List<tbl_Posts> posts { get; set; }
        public tbl_Posts post { get; set; }
    }
}