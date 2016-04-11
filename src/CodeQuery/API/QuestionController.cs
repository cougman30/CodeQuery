using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using CodeQuery.Models;
using Microsoft.Data.Entity;
using CodeQuery.Services;
using CodeQuery.Models.ViewModels;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeQuery.API
{
    [Route("api/[controller]")]
    public class QuestionController : Controller
    {
        #region - Fake database on server
        //static List<Post> _postList = new List<Post>
        //{
        //    new Post {
        //        ID = 1,
        //        Title = "How do I create webpages - I want to know",
        //        Views = 115,
        //        ReplyCount = 17,
        //        Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque luctus, leo in volutpat eleifend, orci est pulvinar arcu, ac lacinia ex tellus vitae augue. Donec molestie nulla et elit vehicula finibus. Duis magna tellus, molestie sed rhoncus at, scelerisque vel enim. Nunc ornare, neque finibus efficitur congue, dolor ex semper dui, venenatis gravida nibh mi at mi. Morbi gravida sollicitudin ex, quis finibus ex tincidunt tincidunt. Donec tristique nisl vel libero ultrices finibus. Curabitur accumsan ex suscipit, venenatis tortor non, aliquam libero. Aliquam non malesuada eros.Vestibulum eget libero velit.Duis aliquet interdum elit, at eleifend tortor pellentesque nec. Maecenas id rhoncus sapien. Pellentesque orci neque, vehicula id tincidunt id, commodo ut nunc. Morbi vel pharetra magna, non malesuada tellus. Nunc id eleifend enim, sed sodales ante. Phasellus quis porttitor est. Suspendisse faucibus purus eu efficitur congue. Pellentesque mi ipsum, iaculis placerat pretium sed, convallis vitae elit. Aliquam venenatis ut sem non laoreet. Vestibulum at metus et tellus tincidunt aliquet.Duis bibendum urna diam, ut congue ex dignissim sed. Praesent lacinia enim velit, eu imperdiet diam feugiat eu. Proin sit amet dapibus orci, eget eleifend sem.In quis semper orci.Pellentesque faucibus libero in nunc egestas, sit amet consectetur nibh congue. Aenean vel turpis massa. In hac habitasse platea dictumst.Curabitur efficitur ut quam sit amet commodo.Sed vitae metus ut mauris dignissim luctus feugiat id purus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi eu enim lectus. Maecenas venenatis, diam ornare bibendum rhoncus, nulla orci finibus urna, vel bibendum lacus libero semper turpis.Sed eget sapien diam.Proin eget molestie mauris. Maecenas rutrum feugiat ligula non interdum. Nulla placerat, velit et fringilla gravida, metus nisl sodales sapien, nec mollis tellus erat a lacus.Nulla vitae tempor leo. Nulla at tortor lorem. Maecenas venenatis accumsan diam, vitae imperdiet sapien auctor vitae. Curabitur finibus dolor vel ante viverra, sit amet congue mauris egestas.",
        //        Labels = "Web HTML",
        //        Replies = new List<Reply> {
        //            new Reply { ID = 1, Message = "This is a really good article" },
        //            new Reply { ID = 2, Message = "I don't understand" },
        //            new Reply { ID = 3, Message = "You just need to look at it from the left side" }
        //        }
        //    },
        //    new Post {
        //        ID = 2,
        //        Title = "How do I style a webpage",
        //        Views = 98,
        //        ReplyCount = 23,
        //        Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque luctus, leo in volutpat eleifend, orci est pulvinar arcu, ac lacinia ex tellus vitae augue. Donec molestie nulla et elit vehicula finibus. Duis magna tellus, molestie sed rhoncus at, scelerisque vel enim. Nunc ornare, neque finibus efficitur congue, dolor ex semper dui, venenatis gravida nibh mi at mi. Morbi gravida sollicitudin ex, quis finibus ex tincidunt tincidunt. Donec tristique nisl vel libero ultrices finibus. Curabitur accumsan ex suscipit, venenatis tortor non, aliquam libero.",
        //        Labels = "Web CSS HTML",
        //        Replies = new List<Reply> {
        //            new Reply { ID = 1, Message = "What are you talking about?" },
        //            new Reply { ID = 2, Message = "Help Me!" },
        //        }
        //    },
        //    new Post {
        //        ID = 3,
        //        Title = "How do I loop through an array",
        //        Views = 361,
        //        ReplyCount = 54,
        //        Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque luctus, leo in volutpat eleifend, orci est pulvinar arcu, ac lacinia ex tellus vitae augue. Donec molestie nulla et elit vehicula finibus. Duis magna tellus, molestie sed rhoncus at, scelerisque vel enim. Nunc ornare, neque finibus efficitur congue, dolor ex semper dui, venenatis gravida nibh mi at mi. Morbi gravida sollicitudin ex, quis finibus ex tincidunt tincidunt. Donec tristique nisl vel libero ultrices finibus. Curabitur accumsan ex suscipit, venenatis tortor non, aliquam libero.",
        //        Labels = "Array Loop Javascript",
        //        Replies = new List<Reply> {
        //            new Reply { ID = 1, Message = "How did you get that answer?" },
        //            new Reply { ID = 2, Message = "Go slower" },
        //            new Reply { ID = 3, Message = "By reading the lessons" }
        //        }
        //    },
        //    new Post {
        //        ID = 4,
        //        Title = "Can I add two classes to same html element",
        //        Views = 56,
        //        ReplyCount = 8,
        //        Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque luctus, leo in volutpat eleifend, orci est pulvinar arcu, ac lacinia ex tellus vitae augue. Donec molestie nulla et elit vehicula finibus. Duis magna tellus, molestie sed rhoncus at, scelerisque vel enim. Nunc ornare, neque finibus efficitur congue, dolor ex semper dui, venenatis gravida nibh mi at mi. Morbi gravida sollicitudin ex, quis finibus ex tincidunt tincidunt. Donec tristique nisl vel libero ultrices finibus. Curabitur accumsan ex suscipit, venenatis tortor non, aliquam libero.",
        //        Labels = "Classes HTML",
        //        Replies = new List<Reply> {
        //            new Reply { ID = 1, Message = "You can do it!" },
        //            new Reply { ID = 2, Message = "I wanted the classes on the same element" },
        //        }
        //    },
        //    new Post {
        //        ID = 5,
        //        Title = "How to declare a variable in Javascript",
        //        Views = 43,
        //        ReplyCount = 11,
        //        Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque luctus, leo in volutpat eleifend, orci est pulvinar arcu, ac lacinia ex tellus vitae augue. Donec molestie nulla et elit vehicula finibus. Duis magna tellus, molestie sed rhoncus at, scelerisque vel enim. Nunc ornare, neque finibus efficitur congue, dolor ex semper dui, venenatis gravida nibh mi at mi. Morbi gravida sollicitudin ex, quis finibus ex tincidunt tincidunt. Donec tristique nisl vel libero ultrices finibus. Curabitur accumsan ex suscipit, venenatis tortor non, aliquam libero.",
        //        Labels = "Javascript",
        //        Replies = new List<Reply> {
        //            new Reply { ID = 1, Message = "This is a really bad article" },
        //        }
        //    },
        //    new Post {
        //        ID = 6,
        //        Title = "How to create a new project in Visual Studio 2015",
        //        Views = 25,
        //        ReplyCount = 5,
        //        Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque luctus, leo in volutpat eleifend, orci est pulvinar arcu, ac lacinia ex tellus vitae augue. Donec molestie nulla et elit vehicula finibus. Duis magna tellus, molestie sed rhoncus at, scelerisque vel enim. Nunc ornare, neque finibus efficitur congue, dolor ex semper dui, venenatis gravida nibh mi at mi. Morbi gravida sollicitudin ex, quis finibus ex tincidunt tincidunt. Donec tristique nisl vel libero ultrices finibus. Curabitur accumsan ex suscipit, venenatis tortor non, aliquam libero.",
        //        Labels = "C# Visual Studio 2015",
        //        Replies = new List<Reply> {
        //            new Reply { ID = 1, Message = "Hello" },
        //            new Reply { ID = 2, Message = "Hola" },
        //            new Reply { ID = 3, Message = "Ciao" },
        //            new Reply { ID = 4, Message = "Ahoj" },
        //            new Reply { ID = 5, Message = "Hej" },
        //            new Reply { ID = 6, Message = "Salut" }
        //        }
        //    },
        //    new Post {
        //        ID = 7,
        //        Title = "What does inheritance mean",
        //        Views = 11,
        //        ReplyCount = 2,
        //        Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque luctus, leo in volutpat eleifend, orci est pulvinar arcu, ac lacinia ex tellus vitae augue. Donec molestie nulla et elit vehicula finibus. Duis magna tellus, molestie sed rhoncus at, scelerisque vel enim. Nunc ornare, neque finibus efficitur congue, dolor ex semper dui, venenatis gravida nibh mi at mi. Morbi gravida sollicitudin ex, quis finibus ex tincidunt tincidunt. Donec tristique nisl vel libero ultrices finibus. Curabitur accumsan ex suscipit, venenatis tortor non, aliquam libero.",
        //        Labels = "Inheritance C#",
        //        Replies = new List<Reply> {
        //            new Reply { ID = 1, Message = "I am lost" },
        //            new Reply { ID = 2, Message = "Don't panic!" },
        //        }
        //    }
        //};
        #endregion

        IQuestionService db;

        public QuestionController(IQuestionService _db)
        {
            this.db = _db;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var list = db.GetPostList();

            return Ok(list);
        }

        [HttpGet("{num}")]
        [Route("get")]
        public IActionResult GetShortList(int num)
        {
            var list = db.GetShortList(num);
            return Ok(list);
        }

        [HttpGet]
        [Route("hot")]
        public IActionResult GetHotLists()
        {
            var hot = db.GetHotPostList();

            return Ok(hot);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var singlePost = db.GetPost(id);

            return Ok(singlePost);
        }

        [HttpPost]
        [Route("vote")]
        public IActionResult Vote([FromBody]VoteViewModel data)
        {
                if (data.Text == "VoteUp")
                {
                    db.VoteUp(data.ID);
                }
                else if (data.Text == "VoteDown")
                {
                    db.VoteDown(data.ID);
                }
                else
                {
                    return HttpBadRequest();
                }

            return Ok();
        }

        [HttpGet("{text}")]
        [Route("search")]
        public IActionResult SearchQuestions(string text)
        {
            var searchList = db.GetSearchResults(text);
            return Ok(searchList);
        }

        [HttpGet("{text}")]
        [Route("searchLabel")]
        public IActionResult LabelQuestions(string text)
        {
            var searchList = db.GetLabelSearchResults(text);
            return Ok(searchList);
        }

        [HttpPost]
        [Route("comment")]
        public IActionResult Comment([FromBody]CommentViewModel data)
        {
            db.AddComment(data);

            return Ok();
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]NewPostViewModel data)
        {
            db.SavePost(data);

            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //db.DeletePost(id);
            db.ArchivePost(id);

            return Ok();
        }
    }
}
