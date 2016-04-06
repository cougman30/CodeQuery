namespace MyApp.Controllers
{
    export class EditQuestionController
    {
        public postToEdit;

        constructor(private questionService: MyApp.Services.QuestionService,
                    private $state: ng.ui.IStateService,
                    private $stateParams: ng.ui.IStateParamsService)
        {
            this.GetPost();
        }

        GetPost()
        {
            let questionID = this.$stateParams['id'];
            this.questionService.GetQuestion(questionID).then((data) =>
            {
                this.postToEdit = data;
            });
        }

        SavePost()
        {
            this.questionService.SaveQuestion(this.postToEdit).then(() =>
            {
                this.$state.go('message', { 'id': this.postToEdit.id });
            });
        }
    }
}