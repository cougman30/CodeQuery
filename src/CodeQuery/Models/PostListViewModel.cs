using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeQuery.Models
{
    public class PostListViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Views { get; set; }
        public int ReplyCount { get; set; }
        public int Votes { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public List<Label> Labels { get; set; }
        public int AnswerCount { get; set; }
    }
}
