namespace MyApp.Controllers
{
    export class HomeHotController
    {
        public posts;

        constructor(private questionService: MyApp.Services.QuestionService)
        {
            this.posts = this.questionService.GetHotQuestions();
        }
    }
}