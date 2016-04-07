using CodeQuery.Models;
using CodeQuery.Models.ViewModels;
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
            var data = repo.Query<Post>().Select(p => new PostListViewModel
            {
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

        public PostReturnViewModel GetPost(int id)
        {
            var data = repo.Query<Post>().Where(p => p.ID == id).Include(p => p.Replies).Include(p => p.Answers).FirstOrDefault(); 
            var post = new PostReturnViewModel
            {
                ID = data.ID,
                Title = data.Title,
                Answers = data.Answers,
                Body = data.Body,
                CreationDate = data.CreationDate,
                ModifiedDate = data.ModifiedDate,
                Views = data.Views,
                Votes = data.Votes,
                Replies = data.Replies,
                Labels = repo.Query<PostLabel>().Where(pl => pl.PostID == id).Select(pl => pl.Label).ToList()
            };

            return post;
        }

        public void SavePost(NewPostViewModel data)
        {
            if (data.ID == 0)
            {
                var postToAdd = new Post
                {
                    Title = data.Title,
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Body = data.Body,
                    IsActive = true,
                };
                repo.Add(postToAdd);

                foreach (var name in data.Labels)
                {
                    var check = repo.Query<Label>().Where(l => l.Text == name.Text).FirstOrDefault();

                    if (check == null)
                    {
                        repo.Add<Label>(name);
                        repo.SaveChanges();
                    }

                    check = repo.Query<Label>().Where(l => l.Text == name.Text).FirstOrDefault();

                    repo.Add<PostLabel>(new PostLabel
                    {
                        PostID = postToAdd.ID,
                        LabelID = check.ID
                    });
                    repo.SaveChanges();
                }


                var newPost = repo.Query<Post>().Where(p => p.ID == postToAdd.ID).FirstOrDefault();
                newPost.CreationDate = DateTime.Now;
                newPost.ModifiedDate = DateTime.Now;
                repo.SaveChanges();
            }
            else
            {
                foreach (var name in data.Labels)
                {
                    var check = repo.Query<Label>().Where(l => l.Text == name.Text).FirstOrDefault();

                    if (check == null)
                    {
                        repo.Add<Label>(name);
                        repo.SaveChanges();
                    }

                    check = repo.Query<Label>().Where(l => l.Text == name.Text).FirstOrDefault();

                    bool exists = repo.Query<PostLabel>().Where(pl => pl.LabelID == check.ID && pl.PostID == data.ID).Any();

                    if (!exists)
                    {

                        repo.Add<PostLabel>(new PostLabel
                        {
                            PostID = data.ID,
                            LabelID = check.ID
                        });
                    }
                    repo.SaveChanges();
                }

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

            //var post = new Post() { ID = id };
            //context.Categories.Attach(post);

            //context.Categories.Remove(post);
            //context.SaveChanges();

            //postToDelete.Labels.Clear();
            postToDelete.Replies.Clear();
            postToDelete.Answers.Clear();

            repo.Delete<Post>(postToDelete);
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
