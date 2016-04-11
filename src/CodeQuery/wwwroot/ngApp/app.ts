namespace MyApp {

    angular.module('MyApp', ['ui.router', 'ngResource', 'ui.bootstrap', 'ngTagsInput']).config((
        $stateProvider: ng.ui.IStateProvider,
        $urlRouterProvider: ng.ui.IUrlRouterProvider,
        $locationProvider: ng.ILocationProvider
    ) => {
        // Define routes
        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: '/ngApp/views/home.html',
                controller: MyApp.Controllers.HomeController,
                controllerAs: 'controller'
            })
            .state('hot', {
                url: '/hot',
                templateUrl: '/ngApp/views/homeHot.html',
                controller: MyApp.Controllers.HomeHotController,
                controllerAs: 'controller'
            })
            .state('about', {
                url: '/about',
                templateUrl: '/ngApp/views/about.html',
                controller: MyApp.Controllers.AboutController,
                controllerAs: 'controller'
            })
            .state('question', {
                url: '/question',
                templateUrl: '/ngApp/views/question.html',
                controller: MyApp.Controllers.QuestionController,
                controllerAs: 'controller'
            })
            .state('editQuestion', {
                url: '/editMesage/:id',
                templateUrl: '/ngApp/views/editQuestion.html',
                controller: MyApp.Controllers.EditQuestionController,
                controllerAs: 'controller'
            })
            .state('search', {
                url: '/search/:text',
                templateUrl: '/ngApp/views/search.html',
                controller: MyApp.Controllers.SearchController,
                controllerAs: 'controller'
            })
            .state('labelSearch', {
                url: '/labels/:text',
                templateUrl: '/ngApp/views/searchLabels.html',
                controller: MyApp.Controllers.SearchLabelsController,
                controllerAs: 'controller'
            })
            .state('deleteQuestion', {
                url: '/deleteMessage/:id',
                templateUrl: '/ngApp/views/deleteQuestion.html',
                controller: MyApp.Controllers.DeleteQuestionController,
                controllerAs: 'controller'
            })
            .state('find', {
                url: '/find',
                templateUrl: '/ngApp/views/find.html',
                controller: MyApp.Controllers.FindController,
                controllerAs: 'controller'
            })
            .state('login', {
                url: '/login',
                templateUrl: '/ngApp/views/login.html',
                controller: MyApp.Controllers.LoginController,
                controllerAs: 'controller'
            })
            .state('signup', {
                url: '/signup',
                templateUrl: '/ngApp/views/signup.html',
                controller: MyApp.Controllers.SignupController,
                controllerAs: 'controller'
            })
            .state('html', {
                url: '/html',
                templateUrl: '/ngApp/views/htmlVideo.html',
                controller: MyApp.Controllers.HTMLController,
                controllerAs: 'controller'
            })
            .state('css', {
                url: '/css',
                templateUrl: '/ngApp/views/cssVideo.html',
                controller: MyApp.Controllers.CSSController,
                controllerAs: 'controller'
            })
            .state('js', {
                url: '/js',
                templateUrl: '/ngApp/views/js.html',
                controller: MyApp.Controllers.JSController,
                controllerAs: 'controller'
            })
            .state('message', {
                url: '/message/:id',
                templateUrl: '/ngApp/views/message.html',
                controller: MyApp.Controllers.MessageController,
                controllerAs: 'controller'
            })
            .state('askQuestion', {
                url: '/askQuestion',
                templateUrl: '/ngApp/views/askQuestion.html',
                controller: MyApp.Controllers.AskQuestionController,
                controllerAs: 'controller'
            })
            .state('profile', {
                url: '/profile',
                templateUrl: 'ngApp/views/profile.html',
                controller: MyApp.Controllers.ProfileController,
                controllerAs: 'controller'
            })
            .state('profile.details', {
                url: '/details',
                templateUrl: 'ngApp/views/profileDetails.html',
                controller: MyApp.Controllers.ProfileDetailsController,
                controllerAs: 'controller'
            })
            .state('profile.edit', {
                url: '/edit',
                templateUrl: 'ngApp/views/profileEdit.html',
                controller: MyApp.Controllers.ProfileEditController,
                controllerAs: 'controller'
            })
            .state('tags', {
                url: '/tags',
                templateUrl: 'ngApp/views/tags.html',
                controller: MyApp.Controllers.TagsController,
                controllerAs: 'controller'
            })
            .state('notFound', {
                url: '/notFound',
                templateUrl: '/ngApp/views/notFound.html'
            });

        // Handle request for non-existent route
        $urlRouterProvider.otherwise('/notFound');

        // Enable HTML5 navigation
        $locationProvider.html5Mode(true);
    });

}