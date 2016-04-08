namespace MyApp.Controllers
{
    export class MessageController
    {
        public post;
        public time;
        public timeStamp;
        public vote;
        public addComment;
        public comment;
        public answer;

        constructor(private $stateParams: ng.ui.IStateParamsService,
                    private questionService: MyApp.Services.QuestionService,
                    private answerService: MyApp.Services.AnswerService)
        {
            this.GetPost();
            this.vote = {};
            this.addComment = false;
            this.comment = {};
            this.answer = {}
        }

        GetPost()
        {
            let questionID = this.$stateParams['id'];
            this.questionService.GetQuestion(questionID).then((data) =>
            {
                this.post = data;
                //this.time = data.modifiedDate;
                
                this.timeStamp = this.CalculateModifiedTime(data.modifiedDate);
            });
        }

        PostVoteUp()
        {
            let questionID = this.$stateParams['id'];
            this.vote.id = questionID;
            this.vote.text = "VoteUp";
            this.questionService.VoteUp(this.vote).then(() =>
            {
                this.GetPost();
            });
        }

        PostVoteDown()
        {
            let questionID = this.$stateParams['id'];
            this.vote.id = questionID;
            this.vote.text = "VoteDown";
            this.questionService.VoteUp(this.vote).then(() =>
            {
                this.GetPost();
            });
        }

        AnswerVoteUp(id)
        {
            this.vote.id = id;
            this.vote.text = "VoteUp";
            this.answerService.VoteUp(this.vote).then(() =>
            {
                this.GetPost();
            });
        }

        AnswerVoteDown(id)
        {
            this.vote.id = id;
            this.vote.text = "VoteDown";
            this.answerService.VoteDown(this.vote).then(() =>
            {
                this.GetPost();
            });
        }

        ToggleComment()
        {
            this.addComment = !this.addComment;
        }

        AddComment()
        {
            let questionID = this.$stateParams['id'];
            this.comment.id = questionID;
            this.questionService.AddComment(this.comment).then(() =>
            {
                this.GetPost();
                this.addComment = !this.addComment;
            });
        }

        AddAnswer()
        {
            console.log("Add answer");
            let questionID = this.$stateParams['id'];
            this.answer.postID = questionID;
            console.log(this.answer);
            this.answerService.SaveAnswer(this.answer).then(() =>
            {
                this.GetPost();
                this.answer.body = "";
            });
        }

        AnswerTime(id)
        {
            //console.log("AnswerTime");
            //console.log(id);

            for (var i = 0; i < this.answer.count; i++)
            {
                if (id == this.answer[i].id)
                {
                    console.log("id = " + this.answer[i].id);
                }
            }

            return (this.CalculateModifiedTime(this.answer.creationDate));

            //return (id + " mins ago");
        }

        CalculateModifiedTime(time)
        {
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

            if (weeks > 0)
            {
                if (weeks == 1)
                {
                    //this.timeStamp = weeks + " week ago";
                    return (weeks + " week ago");
                }
                else
                {
                    //this.timeStamp = weeks + " weeks ago";
                    return (weeks + " weeks ago");
                }
            }
            else if (days > 0)
            {
                if (days == 1)
                {
                    //this.timeStamp = days + " day ago";
                    return (days + " day ago");

                }
                else
                {
                    //this.timeStamp = days + " days ago";
                    return (days + " days ago");

                }
            }
            else if (hours > 0)
            {
                if (hours == 1)
                {   
                    //this.timeStamp = hours + " hour ago";
                    return (hours + " hour ago");

                }
                else
                {
                    //this.timeStamp = hours + " hours ago";
                    return (hours + " hours ago");

                }
            }
            else if (minutes > 0)
            {
                if (minutes == 1)
                {
                    //this.timeStamp = minutes + " minute ago";
                    return (minutes + " minute ago");

                }
                else
                {
                    //this.timeStamp = minutes + " minutes ago";
                    return (minutes + " minutes ago");

                }
            }
            else
            {
                //this.timeStamp = seconds + " seconds ago";
                return (seconds + " seconds ago");
            }
        }
    }

    angular.module('MyApp').controller('MessageController', MessageController);
}