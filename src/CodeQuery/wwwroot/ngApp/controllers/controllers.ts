namespace MyApp.Controllers
{

    export class HomeController
    {
        public posts;
        public recents;
        public hots;
        public htmlPopover;
        public numOfPosts = 0;
        public currentPage = 1;
        public maxSize = 3;
        

        constructor(private questionService: MyApp.Services.QuestionService)
        {
            var list = this.questionService.GetQuestionList().then((data) =>
            {
                this.numOfPosts = data.length;
            });;
            this.posts = this.questionService.GetShortQuestionList(this.currentPage);//.then((data) =>
            //{
            //    this.posts = data;
            //    this.numOfPosts = data.length;
            //    //console.log(this.posts);
            //    console.log(this.numOfPosts);

            //});
            //htmlPopover = trustAsHtml('<b style="color: red">I can</b> have <div class="label label-success">HTML</div> content');
        }

        setPage(pageNo)
        {
            this.currentPage = pageNo;
        }

        GetSearchResults()
        {
            console.log(this.currentPage);
            this.posts = this.questionService.GetShortQuestionList(this.currentPage);
        }

        testPage()
        {
            console.log(this.currentPage);
        }

    }

    export class AboutController
    {
        public message = 'Hello from the about page!';

        constructor(private $uibModal: ng.ui.bootstrap.IModalService)
        {

        }

        public showSignUpModal()
        {
            this.$uibModal.open({
                templateUrl: '/ngApp/views/signup.html',
                controller: MyApp.Controllers.SignUpDialogController,
                controllerAs: 'modal',
                //size: "sm"
                //resolve: {
                //    //size: 'sm'
                //}
            });
        }
    }

    export class SignUpDialogController
    {
        constructor(private $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance)
        {
            //console.log("inside the SignUpDialogController");
        }

        public OK()
        {
            this.$uibModalInstance.close();
        }
    }

    angular.module('MyApp').controller("SignUpDialogController", SignUpDialogController);
}
