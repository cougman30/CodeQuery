using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeQuery.Models
{
    public class Label
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public ICollection<PostLabel> PostLabels { get; set; }
        public ICollection<JobLabel> JobLabels { get; set; }
    }
}
