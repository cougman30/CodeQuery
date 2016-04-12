namespace MyApp.Controllers
{
    export class AskQuestionController
    {
        public questionToCreate;
        public labels;
        public labelName;
        public index;
        public tags;

        constructor(private questionService: MyApp.Services.QuestionService, private $state: angular.ui.IStateService)
        {
            this.questionToCreate = {};
            this.labels = [];
            this.index = 0;
            this.tags = [];
        }

        SaveQuestion()
        {
            //this.questionToCreate.creationDate = Date();
            //this.questionToCreate.modifiedDate = Date();
            //console.log(this.questionToCreate);

            for (var i = 0; i < this.tags.length; i++)
            {
                this.labels.push(this.tags[i]);
            }
            //console.log(this.labels);

            this.questionToCreate.labels = this.labels;

            this.questionService.SaveQuestion(this.questionToCreate).then(() =>
            {
                this.$state.go('home');
            });
        }

        //AddLabel()
        //{
        //    this.labels.push(this.labelName);
            
        //    console.log(this.labels);

        //    var container = document.createElement("div");
        //    var labelContainer = document.createElement("div");
        //    var removeContainer = document.createElement("div");


        //    var newLabel = document.createElement("label");
        //    newLabel.setAttribute("id", this.index);
        //    newLabel.setAttribute("class", "label label-default created-labels");
        //    newLabel.innerHTML = this.labelName;
        //    $('#labels').append(newLabel);

        //    this.index++;
        //    this.labelName = "";
        //}
    }
}