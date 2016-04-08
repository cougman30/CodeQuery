using CodeQuery.Models;
using CodeQuery.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeQuery.Services
{
    public class AnswerService : IAnswerService
    {
        IGenericRepository repo;

        public AnswerService(IGenericRepository _repo)
        {
            this.repo = _repo;
        }

        public void SaveAnswer(AnswerViewModel answer)
        {
            var postID = answer.PostID;
            var answerToCreate = new Answer
            {
                Body = answer.Body,
                CreationDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
            var post = repo.Query<Post>().Where(p => p.ID == postID).FirstOrDefault();

            if (post != null)
            {
                post.Answers.Add(answerToCreate);
                repo.SaveChanges();
            }

            return;
        }

        public void VoteUp(int id)
        {
            var vote = repo.Query<Answer>().Where(a => a.ID == id).FirstOrDefault();

            if (vote != null)
            {
                vote.Votes += 1;
                repo.SaveChanges();
            }

            return;
        }

        public void VoteDown(int id)
        {
            var vote = repo.Query<Answer>().Where(a => a.ID == id).FirstOrDefault();

            if (vote != null)
            {
                vote.Votes -= 1;
                repo.SaveChanges();
            }

            return;
        }
    }
}
