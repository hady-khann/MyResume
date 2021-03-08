using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyResume.Models
{
    public class ReadAllViewModel
    {
        public ReadAllViewModel(List<Articles> articles, List<Skills> skills, List<Experiences> experiences, List<Educations> educations)
        {
            Articles = articles;
            Skills = skills;
            Experiences = experiences;
            Educations = educations;
        }

        public List<Articles> Articles { get; set; }
        public List<Skills> Skills { get; set; }
        public List<Experiences> Experiences { get; set; }
        public List<Educations> Educations { get; set; }
    }
}
