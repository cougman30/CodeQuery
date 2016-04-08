using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using CodeQuery.Models;
using Microsoft.Data.Entity;
using CodeQuery.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeQuery.API
{
    [Route("api/[controller]")]
    public class AnswersController : Controller
    {
        IAnswerService db;

        public AnswersController(IAnswerService _db)
        {
            this.db = _db;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]AnswerViewModel value)
        {
            //var postID = value.PostID;
            //var answerToCreate = new Post
            //{
            //    Body = value.Body,
            //    CreationDate = DateTime.Now,
            //    ModifiedDate = DateTime.Now
            //};
            //var post = db.Posts.Where(p => p.ID == postID).Include(p => p.Answers).FirstOrDefault();
            //post.Answers.Add(answerToCreate);
            //db.SaveChanges();

            db.SaveAnswer(value);

            return Ok();
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

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
