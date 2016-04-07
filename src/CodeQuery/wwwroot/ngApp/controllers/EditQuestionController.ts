namespace MyApp.Controllers
{
    export class EditQuestionController
    {
        public postToEdit;
        public options;

        constructor(private questionService: MyApp.Services.QuestionService,
                    private $state: ng.ui.IStateService,
                    private $stateParams: ng.ui.IStateParamsService)
        {
            this.GetPost();
            this.options = new Array;
            this.options[0] = "css";
            this.options[1] = "html";
            this.options[2] = "javascript";
            this.options[3] = "c#";
            this.options[4] = "bootstrap";
            this.options[5] = "angular";
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