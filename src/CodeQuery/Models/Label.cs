using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeQuery.Models
{
    public class Label
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public ICollection<PostLabel> PostLabels { get; set; }
    }
}
