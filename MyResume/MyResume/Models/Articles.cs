using System;
using System.Collections.Generic;

namespace MyResume.Models
{
    public partial class Articles
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PicAddress { get; set; }
        public string About { get; set; }
        public string Link { get; set; }
    }
}
