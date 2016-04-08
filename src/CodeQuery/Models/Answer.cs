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
        public string TimeAgo { get; set; }
        public ICollection<Reply> Replies { get; set; }

        public Answer()
        {
            this.Replies = new List<Reply>();
        }
    }
}
