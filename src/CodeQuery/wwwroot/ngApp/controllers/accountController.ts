namespace MyApp.Controllers
{

    export class AccountController
    {
        public text = "";
        public externalLogins;
        public loggedIn;
        public search = "";
        

        public getUserName()
        {
            return this.accountService.getUserName();
        }

        public getFirstName()
        {
            return this.accountService.getFirstName();
        }

        public getClaim(type)
        {
            return this.accountService.getClaim(type);
        }

        public getUserID()
        {
            return this.accountService.getUserID();
        }

        public TestUserID()
        {
            console.log(this.getUserID());
        }

        public isLoggedIn()
        {
            return this.accountService.isLoggedIn();
        }

        public logout()
        {
            this.accountService.logout();
            this.$location.path('/');
            this.loggedIn = false;
        }

        public getExternalLogins()
        {
            return this.accountService.getExternalLogins();
        }

        constructor(private accountService: MyApp.Services.AccountService, private $location: ng.ILocationService, private $uibModal: ng.ui.bootstrap.IModalService,
                    private questionService: MyApp.Services.QuestionService, private $stateParams: ng.ui.IStateParamsService)
        {
            this.getExternalLogins().then((results) =>
            {
                this.externalLogins = results;
            });

            //console.log("Search");
            //console.log(this.text);

            this.loggedIn = this.accountService.loggedIn;
            //console.log(this.isLoggedIn());

        }

        public showSignUpModal()
        {
            this.$uibModal.open({
                templateUrl: '/ngApp/views/signup.html',
                controller: MyApp.Controllers.RegisterController,
                controllerAs: 'controller',
                //size: "sm"
                //resolve: {
                //    //size: 'sm'
                //}
            });
        }

        public showLoginModal()
        {
            this.$uibModal.open({
                templateUrl: '/ngApp/views/login.html',
                controller: MyApp.Controllers.LoginController,
                controllerAs: 'controller',
                //size: "sm"
                //resolve: {
                //    //size: 'sm'
                //}
            });
        }

        public Search()
        {
            //console.log("Search");
            //console.log(this.search);
            console.log(this.accountService.loggedIn);
            //this.posts = this.questionService.SearchQuestions(this.search);

        }
    }

    angular.module('MyApp').controller('AccountController', AccountController);


    export class LoginController
    {
        public loginUser;
        public validationMessages;

        public login()
        {
            console.log("login method in login controller");
            this.accountService.login(this.loginUser).then(() =>
            {
                this.$location.path('/');
            }).catch((results) =>
            {
                this.validationMessages = results;
            });

            this.OK();
        }

        public OK()
        {
            this.$uibModalInstance.close();
        }

        constructor(private accountService: MyApp.Services.AccountService, private $location: ng.ILocationService, private $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance) { }
    }

    angular.module('MyApp').controller('LoginController', LoginController);


    export class RegisterController
    {
        public registerUser;
        public validationMessages;

        public register()
        {
            console.log("registering new user");
            console.log(this.registerUser);
            this.accountService.register(this.registerUser).then(() =>
            {
                this.$location.path('/');
            }).catch((results) =>
            {
                this.validationMessages = results;
            });

            this.OK();
        }

        public OK()
        {
            this.$uibModalInstance.close();
        }

        constructor(private accountService: MyApp.Services.AccountService, private $location: ng.ILocationService, private $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance) { }
    }

    angular.module('MyApp').controller('RegisterController', RegisterController);



    export class ExternalRegisterController
    {
        public registerUser;
        public validationMessages;

        public register()
        {
            this.accountService.registerExternal(this.registerUser.email)
                .then((result) =>
                {
                    this.$location.path('/');
                }).catch((result) =>
                {
                    this.validationMessages = result;
                });
        }

        constructor(private accountService: MyApp.Services.AccountService, private $location: ng.ILocationService) { }

    }

    export class ConfirmEmailController
    {
        public validationMessages;

        constructor(
            private accountService: MyApp.Services.AccountService,
            private $http: ng.IHttpService,
            private $stateParams: ng.ui.IStateParamsService,
            private $location: ng.ILocationService
        )
        {
            let userId = $stateParams['userId'];
            let code = $stateParams['code'];
            accountService.confirmEmail(userId, code)
                .then((result) =>
                {
                    this.$location.path('/');
                }).catch((result) =>
                {
                    this.validationMessages = result;
                });
        }
    }

}
