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
            return this.questionResource.query();
        }

        public GetQuestion(id)
        {
            return this.questionResource.get({ id: id }).$promise;
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