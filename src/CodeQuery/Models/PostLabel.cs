using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeQuery.Models
{
    public class PostLabel
    {
        public Post Post { get; set; }
        public int PostID { get; set; }
        public Label Label { get; set; }
        public int LabelID { get; set; }
    }
}
