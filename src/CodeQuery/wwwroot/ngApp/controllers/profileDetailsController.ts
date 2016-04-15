namespace MyApp.Controllers
{
    export class ProfileDetailsController
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
            //console.log("ProfileDetailsController");
            //console.log(this.id);
            //var userID = this.accountService.getUserID();
            //console.log(userID);
            this.user = this.accountService.getUserInfo(this.id);
        }

        GetClaim(type)
        {
            return this.accountService.getClaim(type);
        }
    }
}