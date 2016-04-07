using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeQuery.Models.ViewModels
{
    public class PostReturnViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int Views { get; set; }
        public int ReplyCount { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int Votes { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Label> Labels { get; set; }
        public ICollection<Reply> Replies { get; set; }
        public ICollection<Post> Answers { get; set; }
        public ICollection<PostLabel> PostLabels { get; set; }

        public PostReturnViewModel()
        {
            this.Replies = new List<Reply>();
            this.Answers = new List<Post>();
            this.Labels = new List<Label>();
        }
    }
}
