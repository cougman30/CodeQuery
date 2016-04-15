namespace MyApp.Controllers
{
    export class ProfileEditController
    {
        public op;
        public radioModel;
        public dt;
        public format;

        public user;
        public id;

        constructor(private accountService: MyApp.Services.AccountService)
        {
            this.radioModel = "Right";
            this.op = "work";
            this.dt = new Date();
            this.format = 'shortDate';

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

        getClaim(type)
        {
            return this.accountService.getClaim(type);
        }

        DetermineOp()
        {
            
        }
        
    }
}