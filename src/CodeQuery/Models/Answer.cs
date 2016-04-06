using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeQuery.Models
{
    public class Answer
    {
        public int ID { get; set; }
        public string Body { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int Votes { get; set; }
        public ICollection<Label> Labels { get; set; }
        public ICollection<Reply> Replies { get; set; }
        public ICollection<PostLabel> PostLabels { get; set; }

        public Answer()
        {
            this.Replies = new List<Reply>();
        }
    }
}
