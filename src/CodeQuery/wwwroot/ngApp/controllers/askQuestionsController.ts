namespace MyApp.Controllers
{
    export class AskQuestionController
    {
        public questionToCreate;

        constructor(private questionService: MyApp.Services.QuestionService, private $state: angular.ui.IStateService)
        {
            this.questionToCreate = {};
        }

        SaveQuestion()
        {
            //this.questionToCreate.creationDate = Date();
            //this.questionToCreate.modifiedDate = Date();
            console.log(this.questionToCreate);
            this.questionService.SaveQuestion(this.questionToCreate).then(() =>
            {
                this.$state.go('home');
            });
        }
    }
}