namespace MyApp.Controllers
{

    export class HomeController
    {
        public posts;
        public recents;
        public hots;
        public htmlPopover;

        constructor(private questionService: MyApp.Services.QuestionService)
        {
            this.posts = this.questionService.GetQuestionList();
            //htmlPopover = trustAsHtml('<b style="color: red">I can</b> have <div class="label label-success">HTML</div> content');
        }

    }

    export class AboutController
    {
        public message = 'Hello from the about page!';
    }

}
