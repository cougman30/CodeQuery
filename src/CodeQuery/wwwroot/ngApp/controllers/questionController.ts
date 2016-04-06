namespace MyApp.Controllers
{
    export class QuestionController
    {
        public posts;
        public post;

        constructor(private questionService: MyApp.Services.QuestionService, private $stateParams: angular.ui.IStateParamsService)
        {
            this.posts = this.questionService.GetQuestionList();
        }

        GetQuestion(id)
        {
            
        }

        addNew()
        {
            let obj = { id: 8, title: "What does inheritance mean", views: 11, replies: 2 };
            this.posts.push(obj);
        }
    }
}