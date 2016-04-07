using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeQuery.Models.ViewModels
{
    public class NewPostViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public ICollection<Label> Labels { get; set; }
    }
}
