using CodeQuery.Models;
using CodeQuery.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeQuery.Services
{
    public class QuestionService : IQuestionService
    {
        IGenericRepository repo;

        public QuestionService(IGenericRepository _repo)
        {
            this.repo = _repo;
        }

        public List<PostListViewModel> GetPostList()
        {
            var data = repo.Query<Post>().Select(p => new PostListViewModel {
                ID = p.ID,
                Title = p.Title,
                CreationDate = p.CreationDate,
                ModifiedDate = p.ModifiedDate,
                Views = p.Views,
                ReplyCount = p.ReplyCount,
                Votes = p.Votes,
                Labels = p.PostLabels.Select(pl => pl.Label).ToList()
            }).ToList();

            return data;
        }

        public Post GetPost(int id)
        {
            var data = repo.Query<Post>().Where(p => p.ID == id).Include(p => p.Replies).Include(p => p.Answers).FirstOrDefault();
            data.Labels = repo.Query<PostLabel>().Where(pl => pl.PostID == id).Select(pl => pl.Label).ToList();

            return data;
        }

        public void SavePost(Post data)
        {
            if (data.ID == 0)
            {
                repo.Add(data);

                var newPost = repo.Query<Post>().Where(p => p.ID == data.ID).FirstOrDefault();
                newPost.CreationDate = DateTime.Now;
                newPost.ModifiedDate = DateTime.Now;
                repo.SaveChanges();
            }
            else
            {
                //var postToEdit = db.Posts.Where(p => p.ID == data.ID).FirstOrDefault();
                //postToEdit.Body = data.Body;
                ////postToEdit.Labels = data.Labels;
                //postToEdit.Title = data.Title;
                //postToEdit.ModifiedDate = DateTime.Now;

                var postToEdit = repo.Query<Post>().Where(p => p.ID == data.ID).FirstOrDefault();
                postToEdit.Body = data.Body;
                postToEdit.Title = data.Title;
                postToEdit.ModifiedDate = DateTime.Now;
                repo.SaveChanges();
            }
            return;
        }

        public void DeletePost(int id)
        {
            var postToDelete = repo.Query<Post>().Where(p => p.ID == id).FirstOrDefault();
            repo.Delete(postToDelete);
            return;
        }

        public void VoteUp(int id)
        {
            var vote = repo.Query<Post>().Where(p => p.ID == id).FirstOrDefault();

            if (vote != null)
            {
                vote.Votes += 1;
                repo.SaveChanges();
            }

            return;
        }

        public void VoteDown(int id)
        {
            var vote = repo.Query<Post>().Where(p => p.ID == id).FirstOrDefault();

            if (vote != null)
            {
                vote.Votes -= 1;
                repo.SaveChanges();
            }

            return;
        }

        public void AddComment(CommentViewModel data)
        {
            var commentToAdd = new Reply
            {
                CreationDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                Message = data.Body
            };

            var post = repo.Query<Post>().Where(p => p.ID == data.ID).FirstOrDefault();
            post.Replies.Add(commentToAdd);
            repo.SaveChanges();

            return;
        }
    }
}
