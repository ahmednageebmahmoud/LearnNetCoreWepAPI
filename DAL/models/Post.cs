using LearnNetCoreWepAPI.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnNetCoreWepAPI.DAL.models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        //public Employee Employee { get; set; }
        public List<PostMedia> PostMedias { get; set; }
        public ICollection<Media> Medias { get; set; }


    }
}
