var MyApp;
(function (MyApp) {
    angular.module('MyApp', ['ui.router', 'ngResource', 'ui.bootstrap', 'ngTagsInput']).config(function ($stateProvider, $urlRouterProvider, $locationProvider) {
        // Define routes
        $stateProvider
            .state('home', {
            url: '/',
            templateUrl: '/ngApp/views/home.html',
            controller: MyApp.Controllers.HomeController,
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
})(MyApp || (MyApp = {}));
/// <reference path="ngapp/app.ts" />
var MyApp;
(function (MyApp) {
    var Services;
    (function (Services) {
        var AnswerService = (function () {
            function AnswerService($resource) {
                this.$resource = $resource;
                this.answerResource = this.$resource('/api/answers/:id');
            }
            AnswerService.prototype.SaveAnswer = function (answerToSave) {
                console.log("SaveAnswer in Service");
                console.log(answerToSave);
                return this.answerResource.save(answerToSave).$promise;
            };
            AnswerService.prototype.VoteUp = function (vote) {
                var voteResource = this.$resource("api/answers/vote");
                return voteResource.save(vote).$promise;
            };
            AnswerService.prototype.VoteDown = function (vote) {
                var voteResource = this.$resource("api/answers/vote");
                return voteResource.save(vote).$promise;
            };
            return AnswerService;
        }());
        Services.AnswerService = AnswerService;
        angular.module("MyApp").service("answerService", AnswerService);
    })(Services = MyApp.Services || (MyApp.Services = {}));
})(MyApp || (MyApp = {}));
var MyApp;
(function (MyApp) {
    var Services;
    (function (Services) {
        var QuestionService = (function () {
            function QuestionService($resource) {
                this.$resource = $resource;
                this.questionResource = this.$resource('/api/question/:id');
            }
            QuestionService.prototype.GetQuestionList = function () {
                return this.questionResource.query();
            };
            QuestionService.prototype.GetQuestion = function (id) {
                return this.questionResource.get({ id: id }).$promise;
            };
            QuestionService.prototype.SaveQuestion = function (questionToSave) {
                //let newObj = {};
                //console.log(questionToSave);
                //console.log("Service - " + newObj);
                return this.questionResource.save(questionToSave).$promise;
            };
            QuestionService.prototype.DeleteQuestion = function (id) {
                //console.log("Delete Question in QuestionService.ts");
                //console.log(id);
                return this.questionResource.delete({ id: id }).$promise;
            };
            QuestionService.prototype.VoteUp = function (vote) {
                //console.log("VoteUp in Service");
                //console.log(vote);
                //console.log(typeof vote);
                var voteResource = this.$resource("/api/question/vote");
                return voteResource.save(vote).$promise;
            };
            QuestionService.prototype.VoteDown = function (vote) {
                var voteResource = this.$resource("api/question/vote");
                return voteResource.save(vote).$promise;
            };
            QuestionService.prototype.AddComment = function (comment) {
                var commentResource = this.$resource("api/question/comment");
                return commentResource.save(comment).$promise;
            };
            return QuestionService;
        }());
        Services.QuestionService = QuestionService;
        angular.module("MyApp").service('questionService', QuestionService);
    })(Services = MyApp.Services || (MyApp.Services = {}));
})(MyApp || (MyApp = {}));
var MyApp;
(function (MyApp) {
    var Services;
    (function (Services) {
        var MovieService = (function () {
            function MovieService($resource) {
                this.MovieResource = $resource('/api/movies');
            }
            MovieService.prototype.listMovies = function () {
                return this.MovieResource.query();
            };
            return MovieService;
        }());
        Services.MovieService = MovieService;
        angular.module('MyApp').service('movieService', MovieService);
    })(Services = MyApp.Services || (MyApp.Services = {}));
})(MyApp || (MyApp = {}));
var MyApp;
(function (MyApp) {
    var Filters;
    (function (Filters) {
        function HotTopic() {
            return function (input, length) {
                var result = [];
                angular.forEach(input, function (value, key) {
                    angular.forEach(value, function (value2, key2) {
                        if (value2 >= length) {
                            result.push(value2);
                        }
                    });
                });
                return result;
            };
        }
        function Recent() {
            return function (input, length) {
                var result = [];
                angular.forEach(input, function (value, key) {
                    angular.forEach(value, function (value2, key2) {
                        if (value2 >= length) {
                            result.push(value2);
                        }
                    });
                });
                return result;
            };
        }
    })(Filters = MyApp.Filters || (MyApp.Filters = {}));
})(MyApp || (MyApp = {}));
var MyApp;
(function (MyApp) {
    var Controllers;
    (function (Controllers) {
        var AskQuestionController = (function () {
            function AskQuestionController(questionService, $state) {
                this.questionService = questionService;
                this.$state = $state;
                this.questionToCreate = {};
                this.labels = [];
                this.index = 0;
                this.tags = [];
            }
            AskQuestionController.prototype.SaveQuestion = function () {
                var _this = this;
                //this.questionToCreate.creationDate = Date();
                //this.questionToCreate.modifiedDate = Date();
                console.log(this.questionToCreate);
                for (var i = 0; i < this.tags.length; i++) {
                    this.labels.push(this.tags[i]);
                }
                console.log(this.labels);
                this.questionToCreate.labels = this.labels;
                this.questionService.SaveQuestion(this.questionToCreate).then(function () {
                    _this.$state.go('home');
                });
            };
            return AskQuestionController;
        }());
        Controllers.AskQuestionController = AskQuestionController;
    })(Controllers = MyApp.Controllers || (MyApp.Controllers = {}));
})(MyApp || (MyApp = {}));
var MyApp;
(function (MyApp) {
    var Controllers;
    (function (Controllers) {
        var HomeController = (function () {
            function HomeController(questionService) {
                this.questionService = questionService;
                this.posts = this.questionService.GetQuestionList();
                //htmlPopover = trustAsHtml('<b style="color: red">I can</b> have <div class="label label-success">HTML</div> content');
            }
            return HomeController;
        }());
        Controllers.HomeController = HomeController;
        var AboutController = (function () {
            function AboutController() {
                this.message = 'Hello from the about page!';
            }
            return AboutController;
        }());
        Controllers.AboutController = AboutController;
    })(Controllers = MyApp.Controllers || (MyApp.Controllers = {}));
})(MyApp || (MyApp = {}));
var MyApp;
(function (MyApp) {
    var Controllers;
    (function (Controllers) {
        var CSSController = (function () {
            function CSSController() {
                this.message = "Hello from the CSS video tutorial page!";
            }
            return CSSController;
        }());
        Controllers.CSSController = CSSController;
    })(Controllers = MyApp.Controllers || (MyApp.Controllers = {}));
})(MyApp || (MyApp = {}));
var MyApp;
(function (MyApp) {
    var Controllers;
    (function (Controllers) {
        var DeleteQuestionController = (function () {
            function DeleteQuestionController(questionService, $stateParams, $state) {
                this.questionService = questionService;
                this.$stateParams = $stateParams;
                this.$state = $state;
                //this.postToDelete = this.questionService.GetQuestion($stateParams['id']);
                this.GetPost();
            }
            DeleteQuestionController.prototype.GetPost = function () {
                var _this = this;
                var questionID = this.$stateParams['id'];
                this.questionService.GetQuestion(questionID).then(function (data) {
                    _this.postToDelete = data;
                });
                //console.log(this.postToDelete);
                //console.log(this.postToDelete.id);
            };
            DeleteQuestionController.prototype.DeletePost = function () {
                var _this = this;
                //console.log(this.postToDelete.id);
                this.questionService.DeleteQuestion(this.postToDelete.id).then(function () {
                    _this.$state.go('home');
                });
            };
            return DeleteQuestionController;
        }());
        Controllers.DeleteQuestionController = DeleteQuestionController;
    })(Controllers = MyApp.Controllers || (MyApp.Controllers = {}));
})(MyApp || (MyApp = {}));
var MyApp;
(function (MyApp) {
    var Controllers;
    (function (Controllers) {
        var EditQuestionController = (function () {
            function EditQuestionController(questionService, $state, $stateParams) {
                this.questionService = questionService;
                this.$state = $state;
                this.$stateParams = $stateParams;
                this.GetPost();
                this.options = new Array;
                this.options[0] = "css";
                this.options[1] = "html";
                this.options[2] = "javascript";
                this.options[3] = "c#";
                this.options[4] = "bootstrap";
                this.options[5] = "angular";
            }
            EditQuestionController.prototype.GetPost = function () {
                var _this = this;
                var questionID = this.$stateParams['id'];
                this.questionService.GetQuestion(questionID).then(function (data) {
                    _this.postToEdit = data;
                });
            };
            EditQuestionController.prototype.SavePost = function () {
                var _this = this;
                this.questionService.SaveQuestion(this.postToEdit).then(function () {
                    _this.$state.go('message', { 'id': _this.postToEdit.id });
                });
            };
            return EditQuestionController;
        }());
        Controllers.EditQuestionController = EditQuestionController;
    })(Controllers = MyApp.Controllers || (MyApp.Controllers = {}));
})(MyApp || (MyApp = {}));
var MyApp;
(function (MyApp) {
    var Controllers;
    (function (Controllers) {
        var FindController = (function () {
            function FindController() {
                this.message = "Hello from the find page!";
            }
            return FindController;
        }());
        Controllers.FindController = FindController;
    })(Controllers = MyApp.Controllers || (MyApp.Controllers = {}));
})(MyApp || (MyApp = {}));
var MyApp;
(function (MyApp) {
    var Controllers;
    (function (Controllers) {
        var HTMLController = (function () {
            function HTMLController() {
                this.message = "Hello from the HTML video tutorial page!";
            }
            return HTMLController;
        }());
        Controllers.HTMLController = HTMLController;
    })(Controllers = MyApp.Controllers || (MyApp.Controllers = {}));
})(MyApp || (MyApp = {}));
var MyApp;
(function (MyApp) {
    var Controllers;
    (function (Controllers) {
        var JSController = (function () {
            function JSController() {
                this.message = "Hello from the Javascript video tutorial page!";
            }
            return JSController;
        }());
        Controllers.JSController = JSController;
    })(Controllers = MyApp.Controllers || (MyApp.Controllers = {}));
})(MyApp || (MyApp = {}));
var MyApp;
(function (MyApp) {
    var Controllers;
    (function (Controllers) {
        var LoginController = (function () {
            function LoginController() {
                this.message = "Hello from the login page!";
            }
            return LoginController;
        }());
        Controllers.LoginController = LoginController;
    })(Controllers = MyApp.Controllers || (MyApp.Controllers = {}));
})(MyApp || (MyApp = {}));
var MyApp;
(function (MyApp) {
    var Controllers;
    (function (Controllers) {
        var MessageController = (function () {
            function MessageController($stateParams, questionService, answerService) {
                this.$stateParams = $stateParams;
                this.questionService = questionService;
                this.answerService = answerService;
                this.GetPost();
                this.vote = {};
                this.addComment = false;
                this.comment = {};
                this.answer = {};
            }
            MessageController.prototype.GetPost = function () {
                var _this = this;
                var questionID = this.$stateParams['id'];
                this.questionService.GetQuestion(questionID).then(function (data) {
                    _this.post = data;
                    //this.time = data.modifiedDate;
                    _this.timeStamp = _this.CalculateModifiedTime(data.modifiedDate);
                });
            };
            MessageController.prototype.PostVoteUp = function () {
                var _this = this;
                var questionID = this.$stateParams['id'];
                this.vote.id = questionID;
                this.vote.text = "VoteUp";
                this.questionService.VoteUp(this.vote).then(function () {
                    _this.GetPost();
                });
            };
            MessageController.prototype.PostVoteDown = function () {
                var _this = this;
                var questionID = this.$stateParams['id'];
                this.vote.id = questionID;
                this.vote.text = "VoteDown";
                this.questionService.VoteUp(this.vote).then(function () {
                    _this.GetPost();
                });
            };
            MessageController.prototype.AnswerVoteUp = function (id) {
                var _this = this;
                this.vote.id = id;
                this.vote.text = "VoteUp";
                this.answerService.VoteUp(this.vote).then(function () {
                    _this.GetPost();
                });
            };
            MessageController.prototype.AnswerVoteDown = function (id) {
                var _this = this;
                this.vote.id = id;
                this.vote.text = "VoteDown";
                this.answerService.VoteDown(this.vote).then(function () {
                    _this.GetPost();
                });
            };
            MessageController.prototype.ToggleComment = function () {
                this.addComment = !this.addComment;
            };
            MessageController.prototype.AddComment = function () {
                var _this = this;
                var questionID = this.$stateParams['id'];
                this.comment.id = questionID;
                this.questionService.AddComment(this.comment).then(function () {
                    _this.GetPost();
                    _this.addComment = !_this.addComment;
                });
            };
            MessageController.prototype.AddAnswer = function () {
                var _this = this;
                console.log("Add answer");
                var questionID = this.$stateParams['id'];
                this.answer.postID = questionID;
                console.log(this.answer);
                this.answerService.SaveAnswer(this.answer).then(function () {
                    _this.GetPost();
                    _this.answer.body = "";
                });
            };
            MessageController.prototype.AnswerTime = function (id) {
                //console.log("AnswerTime");
                //console.log(id);
                for (var i = 0; i < this.answer.count; i++) {
                    if (id == this.answer[i].id) {
                        console.log("id = " + this.answer[i].id);
                    }
                }
                return (this.CalculateModifiedTime(this.answer.creationDate));
                //return (id + " mins ago");
            };
            MessageController.prototype.CalculateModifiedTime = function (time) {
                var time1 = new Date(time);
                //console.log(time1);
                var time1ms = time1.getTime();
                var time2 = new Date();
                var time2ms = time2.getTime();
                var diff = time2ms - time1ms - 25200000;
                var seconds = (diff / 1000) | 0;
                diff -= seconds * 1000;
                var minutes = (seconds / 60) | 0;
                seconds -= minutes * 60;
                var hours = (minutes / 60) | 0;
                minutes -= hours * 60;
                var days = (hours / 24) | 0;
                hours -= days * 24;
                var weeks = (days / 7) | 0;
                days -= weeks * 7;
                //console.log("Weeks = " + weeks);
                //console.log("Days = " + days);
                //console.log("Hours = " + hours);
                //console.log("Minutes = " + minutes);
                //console.log("Seconds = " + seconds);
                if (weeks > 0) {
                    if (weeks == 1) {
                        //this.timeStamp = weeks + " week ago";
                        return (weeks + " week ago");
                    }
                    else {
                        //this.timeStamp = weeks + " weeks ago";
                        return (weeks + " weeks ago");
                    }
                }
                else if (days > 0) {
                    if (days == 1) {
                        //this.timeStamp = days + " day ago";
                        return (days + " day ago");
                    }
                    else {
                        //this.timeStamp = days + " days ago";
                        return (days + " days ago");
                    }
                }
                else if (hours > 0) {
                    if (hours == 1) {
                        //this.timeStamp = hours + " hour ago";
                        return (hours + " hour ago");
                    }
                    else {
                        //this.timeStamp = hours + " hours ago";
                        return (hours + " hours ago");
                    }
                }
                else if (minutes > 0) {
                    if (minutes == 1) {
                        //this.timeStamp = minutes + " minute ago";
                        return (minutes + " minute ago");
                    }
                    else {
                        //this.timeStamp = minutes + " minutes ago";
                        return (minutes + " minutes ago");
                    }
                }
                else {
                    //this.timeStamp = seconds + " seconds ago";
                    return (seconds + " seconds ago");
                }
            };
            return MessageController;
        }());
        Controllers.MessageController = MessageController;
        angular.module('MyApp').controller('MessageController', MessageController);
    })(Controllers = MyApp.Controllers || (MyApp.Controllers = {}));
})(MyApp || (MyApp = {}));
var MyApp;
(function (MyApp) {
    var Controllers;
    (function (Controllers) {
        var ProfileController = (function () {
            function ProfileController() {
                this.message = "Hello from the login page!";
            }
            return ProfileController;
        }());
        Controllers.ProfileController = ProfileController;
    })(Controllers = MyApp.Controllers || (MyApp.Controllers = {}));
})(MyApp || (MyApp = {}));
var MyApp;
(function (MyApp) {
    var Controllers;
    (function (Controllers) {
        var ProfileDetailsController = (function () {
            function ProfileDetailsController() {
            }
            return ProfileDetailsController;
        }());
        Controllers.ProfileDetailsController = ProfileDetailsController;
    })(Controllers = MyApp.Controllers || (MyApp.Controllers = {}));
})(MyApp || (MyApp = {}));
var MyApp;
(function (MyApp) {
    var Controllers;
    (function (Controllers) {
        var ProfileEditController = (function () {
            function ProfileEditController() {
                this.radioModel = "Right";
                this.op = "work";
                this.dt = new Date();
                this.format = 'shortDate';
            }
            return ProfileEditController;
        }());
        Controllers.ProfileEditController = ProfileEditController;
    })(Controllers = MyApp.Controllers || (MyApp.Controllers = {}));
})(MyApp || (MyApp = {}));
var MyApp;
(function (MyApp) {
    var Controllers;
    (function (Controllers) {
        var QuestionController = (function () {
            function QuestionController(questionService, $stateParams) {
                this.questionService = questionService;
                this.$stateParams = $stateParams;
                this.posts = this.questionService.GetQuestionList();
            }
            QuestionController.prototype.GetQuestion = function (id) {
            };
            QuestionController.prototype.addNew = function () {
                var obj = { id: 8, title: "What does inheritance mean", views: 11, replies: 2 };
                this.posts.push(obj);
            };
            return QuestionController;
        }());
        Controllers.QuestionController = QuestionController;
    })(Controllers = MyApp.Controllers || (MyApp.Controllers = {}));
})(MyApp || (MyApp = {}));
var MyApp;
(function (MyApp) {
    var Controllers;
    (function (Controllers) {
        var SignupController = (function () {
            function SignupController() {
            }
            return SignupController;
        }());
        Controllers.SignupController = SignupController;
    })(Controllers = MyApp.Controllers || (MyApp.Controllers = {}));
})(MyApp || (MyApp = {}));
var MyApp;
(function (MyApp) {
    var Controllers;
    (function (Controllers) {
        var TagsController = (function () {
            function TagsController() {
            }
            return TagsController;
        }());
        Controllers.TagsController = TagsController;
    })(Controllers = MyApp.Controllers || (MyApp.Controllers = {}));
})(MyApp || (MyApp = {}));
//# sourceMappingURL=all.js.map