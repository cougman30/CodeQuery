using CodeQuery.Models;

namespace CodeQuery.Services
{
    public interface IAnswerService
    {
        void SaveAnswer(AnswerViewModel answer);
        void VoteUp(int id);
        void VoteDown(int id);
    }
}