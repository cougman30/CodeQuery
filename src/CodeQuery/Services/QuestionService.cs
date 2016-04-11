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

        public List<PostListViewModel> GetSearchResults(string text)
        {
            var list = repo.Query<Post>().Where(p => p.Title.Contains(text) && p.IsActive == true).Select(p => new PostListViewModel
            {
                ID = p.ID,
                Title = p.Title,
                CreationDate = p.CreationDate,
                ModifiedDate = p.ModifiedDate,
                Views = p.Views,
                ReplyCount = p.Answers.Count,
                Votes = p.Votes,
                Labels = p.PostLabels.Select(pl => pl.Label).ToList(),
                TimeAgo = PostTimeAgo(p.CreationDate)
            }).ToList();
            return list;

        }

        public List<PostListViewModel> GetLabelSearchResults(string text)
        {
            var list = repo.Query<PostLabel>().Where(pl => pl.Label.Text == text).Select(pl => pl.Post).ToList();
            var results = list.Where(p => p.IsActive == true).Select(p => new PostListViewModel {
                ID = p.ID,
                Title = p.Title,
                CreationDate = p.CreationDate,
                ModifiedDate = p.ModifiedDate,
                Views = p.Views,
                ReplyCount = p.Answers.Count,
                Votes = p.Votes,
                //Labels = p.PostLabels.Select(pl => pl.Label).ToList(),
                Labels = repo.Query<PostLabel>().Where(l => l.PostID == p.ID).Select(l => l.Label).ToList(),
                TimeAgo = PostTimeAgo(p.CreationDate)
            }).ToList();
            return results;
        }

        public List<PostListViewModel> GetPostList()
        {
            var data = repo.Query<Post>().Where(p => p.IsActive == true).Select(p => new PostListViewModel
            {
                ID = p.ID,
                Title = p.Title,
                CreationDate = p.CreationDate,
                ModifiedDate = p.ModifiedDate,
                Views = p.Views,
                ReplyCount = p.Answers.Count,
                Votes = p.Votes,
                Labels = p.PostLabels.Select(pl => pl.Label).ToList(),
                TimeAgo = PostTimeAgo(p.CreationDate)
            }).OrderByDescending(p => p.ID).ToList();

            return data;
        }

        public List<PostListViewModel> GetShortList(int num)
        {
            var data = repo.Query<Post>().Where(p => p.IsActive == true).Select(p => new PostListViewModel
            {
                ID = p.ID,
                Title = p.Title,
                CreationDate = p.CreationDate,
                ModifiedDate = p.ModifiedDate,
                Views = p.Views,
                ReplyCount = p.Answers.Count,
                Votes = p.Votes,
                Labels = p.PostLabels.Select(pl => pl.Label).ToList(),
                TimeAgo = PostTimeAgo(p.CreationDate)
            }).OrderByDescending(p => p.ID).ToList();

            data = data.Skip(10 * (num - 1)).Take(10).ToList();

            return data;
        }

        public List<PostListViewModel> GetHotPostList()
        {
            var data = repo.Query<Post>().Where(p => p.IsActive == true).Select(p => new PostListViewModel
            {
                ID = p.ID,
                Title = p.Title,
                CreationDate = p.CreationDate,
                ModifiedDate = p.ModifiedDate,
                Views = p.Views,
                ReplyCount = p.Answers.Count,
                Votes = p.Votes,
                Labels = p.PostLabels.Select(pl => pl.Label).ToList(),
                TimeAgo = PostTimeAgo(p.CreationDate)
            }).OrderByDescending(p => p.ReplyCount).ThenBy(p => p.Views).ToList();

            return data;
        }

        public PostReturnViewModel GetPost(int id)
        {
            var data = repo.Query<Post>().Where(p => p.ID == id).Include(p => p.Replies).Include(p => p.Answers).FirstOrDefault();
            data.Views += 1;
            repo.SaveChanges();

            var ans = data.Answers.ToList();
            ans = AnswerTimeAgo(ans);

            var post = new PostReturnViewModel
            {
                ID = data.ID,
                Title = data.Title,
                Answers = ans,
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
                var test = repo.Query<Post>().Where(p => p.ID == data.ID).Include(pl => pl.PostLabels).FirstOrDefault();
                test.PostLabels.Clear();
                repo.SaveChanges();

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

        public void ArchivePost(int id)
        {
            var post = repo.Query<Post>().Where(p => p.ID == id).FirstOrDefault();
            post.IsActive = false;
            repo.SaveChanges();

            return;
        }

        public string PostTimeAgo(DateTime date)
        {
            var now = DateTime.Now;
            var time = now - date;
            if (time.Minutes < 1)
            {
                return (time.Seconds + " seconds ago");
            }
            else if (time.Hours < 1)
            {
                if (time.Minutes == 1)
                {
                    return (time.Minutes + " minute ago");
                }
                else
                {
                    return (time.Minutes + " minutes ago");
                }
            }
            else if (time.Days < 1)
            {
                if (time.Hours == 1)
                {
                    return (time.Hours + " hour ago");
                }
                else
                {
                    return (time.Hours + " hours ago");
                }
            }
            else if (time.Days < 7)
            {
                if (time.Days == 1)
                {
                    return (time.Days + " day ago");
                }
                else
                {
                    return (time.Days + " days ago");
                }
            }
            else if (time.Days < 30)
            {
                if ((time.Days / 7) == 1)
                {
                    return ((time.Days / 7) + " week ago");
                }
                else
                {
                    return ((time.Days / 7) + " weeks ago");
                }
            }
            else if (time.Days < 365)
            {
                if ((time.Days / 30) == 1)
                {
                    return ((time.Days / 30) + " month ago");
                }
                else
                {
                    return ((time.Days / 30) + " months ago");
                }
            }
            else
            {
                if ((time.Days / 365) == 1)
                {
                    return ((time.Days / 365) + " year ago");
                }
                else
                {
                    return ((time.Days / 365) + " years ago");
                }
            }

        }

        public List<Answer> AnswerTimeAgo(List<Answer> answers)
        {
            foreach (var answer in answers)
            {
                answer.TimeAgo = PostTimeAgo(answer.CreationDate);
                //var now = DateTime.Now;
                //var time = now - answer.CreationDate;
                //if (time.Minutes < 1)
                //{
                //    answer.TimeAgo = time.Seconds + " seconds ago";
                //}
                //else if (time.Hours < 1)
                //{
                //    if (time.Minutes == 1)
                //    {
                //        answer.TimeAgo = time.Minutes + " minute ago";
                //    }
                //    else
                //    {
                //        answer.TimeAgo = time.Minutes + " minutes ago";
                //    }
                //}
                //else if (time.Days < 1)
                //{
                //    if (time.Hours == 1)
                //    {
                //        answer.TimeAgo = time.Hours + " hour ago";
                //    }
                //    else
                //    {
                //        answer.TimeAgo = time.Hours + " hours ago";
                //    }
                //}
                //else if (time.Days < 7)
                //{
                //    if (time.Days == 1)
                //    {
                //        answer.TimeAgo = time.Days + " days ago";
                //    }
                //    else
                //    {
                //        answer.TimeAgo = time.Days + " days ago";
                //    }
                //}
                //else if (time.Days < 30)
                //{
                //    if ((time.Days / 7) == 1)
                //    {
                //        answer.TimeAgo = (time.Days / 7) + " week ago";
                //    }
                //    else
                //    {
                //        answer.TimeAgo = (time.Days / 7) + " weeks ago";
                //    }
                //}
                //else if (time.Days < 365)
                //{
                //    if ((time.Days / 30) == 1)
                //    {
                //        answer.TimeAgo = (time.Days / 30) + " month ago";
                //    }
                //    else
                //    {
                //        answer.TimeAgo = (time.Days / 30) + " months ago";
                //    }
                //}
                //else
                //{
                //    if ((time.Days / 365) == 1)
                //    {
                //        answer.TimeAgo = (time.Days / 365) + " year ago";
                //    }
                //    else
                //    {
                //        answer.TimeAgo = (time.Days / 365) + " years ago";
                //    }
                //}

            }
            return answers;
        }

    }
}
