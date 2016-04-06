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
            console.log(answerToSave);
            return this.answerResource.save(answerToSave).$promise;
        }
    }

    angular.module("MyApp").service("answerService", AnswerService);
}