namespace MyApp.Controllers
{
    export class DeleteQuestionController
    {
        public postToDelete;

        constructor(private questionService: MyApp.Services.QuestionService,
                    private $stateParams: ng.ui.IStateParamsService,
                    private $state: ng.ui.IStateService)
        {
            //this.postToDelete = this.questionService.GetQuestion($stateParams['id']);
            this.GetPost();
            

        }
        GetPost()
        {
            let questionID = this.$stateParams['id'];
            this.questionService.GetQuestion(questionID).then((data) =>
            {
                this.postToDelete = data;
            });
            //console.log(this.postToDelete);
            //console.log(this.postToDelete.id);
        }

        DeletePost()
        {
            //console.log(this.postToDelete.id);
            this.questionService.DeleteQuestion(this.postToDelete.id).then(() =>
            {
                this.$state.go('home');
            });
        }
    }
}