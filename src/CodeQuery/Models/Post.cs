﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeQuery.Models
{
    public class Post
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
        public ICollection<Reply> Replies { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public ICollection<PostLabel> PostLabels { get; set; }

        public Post()
        {
            this.Replies = new List<Reply>();
            this.Answers = new List<Answer>();
        }
    }
}
