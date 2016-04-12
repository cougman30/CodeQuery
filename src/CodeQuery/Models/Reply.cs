using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeQuery.Models
{
    public class Reply
    {
        public int ID { get; set; }
        public string Message { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Reply()
        {
            this.Message = "";
        }
    }
}
