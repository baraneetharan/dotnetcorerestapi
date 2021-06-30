using System;
using System.ComponentModel.DataAnnotations;

namespace restapidemo
{
    public class Visit
    {
        [Key]
        public int visit_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string visited_at { get; set; }
        public string phone { get; set; }

    }
}