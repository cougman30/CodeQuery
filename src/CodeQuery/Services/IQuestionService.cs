using System.Collections.Generic;
using CodeQuery.Models;
using CodeQuery.Models.ViewModels;

namespace CodeQuery.Services
{
    public interface IQuestionService
    {
        void DeletePost(int id);
        PostReturnViewModel GetPost(int id);
        List<PostListViewModel> GetPostList();
        List<PostListViewModel> GetHotPostList();
        void SavePost(NewPostViewModel data);
        void VoteUp(int id);
        void VoteDown(int id);
        void AddComment(CommentViewModel data);
        void ArchivePost(int id);
        List<PostListViewModel> GetSearchResults(string text);
        List<PostListViewModel> GetLabelSearchResults(string text);
        List<PostListViewModel> GetShortLabelSearchResults(string text, int num);
        List<PostListViewModel> GetShortList(int num);
    }
}