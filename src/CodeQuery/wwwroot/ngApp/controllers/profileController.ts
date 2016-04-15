namespace MyApp.Controllers
{

    export class ProfileController
    {
        public user;
        public id;

        constructor(private accountService: MyApp.Services.AccountService)
        {
            this.id = this.accountService.getUserID();
            this.GetUserInfo();
        }

        GetUserInfo()
        {
            console.log("ProfileController");
            console.log(this.id);
            //var userID = this.accountService.getUserID();
            //console.log(userID);
            this.user = this.accountService.getUserInfo(this.id);
        }

        ShowUser()
        {
            console.log("test");
            console.log(this.user);
        }
    }

}