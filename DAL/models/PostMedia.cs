using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnNetCoreWepAPI.DAL.models
{
    public class PostMedia
    {
        public int PostId { get; set; }
        public Post Post { get; set; }
        public int MediaId{ get; set; }
        public Media Media { get; set; }

    }
}
