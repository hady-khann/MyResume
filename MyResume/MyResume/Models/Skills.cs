using System;
using System.Collections.Generic;

namespace MyResume.Models
{
    public partial class Skills
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public int Percentage { get; set; }
    }
}
