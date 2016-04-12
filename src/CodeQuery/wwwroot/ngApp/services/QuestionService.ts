namespace MyApp.Services
{
    export class QuestionService
    {
        private questionResource;

        constructor(private $resource: angular.resource.IResourceService)
        {
            this.questionResource = this.$resource('/api/question/:id');
        }

        public GetQuestionList()
        {
            return this.questionResource.query().$promise;
        }

        public GetShortQuestionList(num)
        {
            var shortResource = this.$resource('/api/question/get');
            return shortResource.query({ num: num });
        }

        public GetHotQuestions()
        {
            var hotResource = this.$resource('/api/question/hot');
            return hotResource.query();
        }

        public GetQuestion(id)
        {
            return this.questionResource.get({ id: id }).$promise;
        }

        public SearchQuestions(text)
        {
            var searchResource = this.$resource('/api/question/search');
            //console.log("SearchQuestions Service");
            //console.log(text);
            return searchResource.query({ text: text });
        }

        public SearchLabels(text)
        {
            let labelResource = this.$resource('/api/question/searchLabel');
            //console.log("SearchQuestions Service");
            //console.log(text);
            //text = "&#35";
            //text = "c#";
            return labelResource.query({ text: text }).$promise;
        }

        public SearchLabelsShort(text, num)
        {
            let labelResource = this.$resource('/api/question/searchLabelShort');
            //console.log("SearchQuestions Service");
            //console.log(text);
            //text = "&#35";
            //text = "c#";
            return labelResource.query({ text: text }, num);
        }

        public SaveQuestion(questionToSave)
        {
            //let newObj = {};
            //console.log(questionToSave);
            //console.log("Service - " + newObj);
            return this.questionResource.save(questionToSave).$promise;
        }

        public DeleteQuestion(id)
        {
            //console.log("Delete Question in QuestionService.ts");
            //console.log(id);
            return this.questionResource.delete({ id: id }).$promise;
        }

        public VoteUp(vote)
        {
            //console.log("VoteUp in Service");
            //console.log(vote);
            //console.log(typeof vote);
            var voteResource = this.$resource("/api/question/vote");
            return voteResource.save(vote).$promise;
        }

        public VoteDown(vote)
        {
            var voteResource = this.$resource("api/question/vote");
            return voteResource.save(vote).$promise;
        }

        public AddComment(comment)
        {
            var commentResource = this.$resource("api/question/comment");
            return commentResource.save(comment).$promise;
        }
    }

    angular.module("MyApp").service('questionService', QuestionService);
}