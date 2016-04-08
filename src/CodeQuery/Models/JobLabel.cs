using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeQuery.Models
{
    public class JobLabel
    {
        public int JobID { get; set; }
        public Job Job { get; set; }
        public int LabelID { get; set; }
        public Label Label { get; set; }
    }
}
