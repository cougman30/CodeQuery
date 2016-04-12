namespace MyApp.Services
{
    export class AnswerService
    {
        private answerResource;

        constructor(private $resource: ng.resource.IResourceService)
        {
            this.answerResource = this.$resource('/api/answers/:id');
        }

        SaveAnswer(answerToSave)
        {
            console.log("SaveAnswer in Service");
            console.log(answerToSave);
            return this.answerResource.save(answerToSave).$promise;
        }

        VoteUp(vote)
        {
            var voteResource = this.$resource("api/answers/vote");
            return voteResource.save(vote).$promise;
        }

        VoteDown(vote)
        {
            var voteResource = this.$resource("api/answers/vote");
            return voteResource.save(vote).$promise;
        }
    }

    angular.module("MyApp").service("answerService", AnswerService);
}