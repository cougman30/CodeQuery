using System.Collections.Generic;
using CodeQuery.Models;

namespace CodeQuery.Services
{
    public interface IQuestionService
    {
        void DeletePost(int id);
        Post GetPost(int id);
        List<PostListViewModel> GetPostList();
        void SavePost(Post data);
        void VoteUp(int id);
        void VoteDown(int id);
        void AddComment(CommentViewModel data);
    }
}