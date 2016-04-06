namespace MyApp.Controllers
{
    export class ProfileEditController
    {
        public op;
        public radioModel;
        public dt;
        public format;

        constructor()
        {
            this.radioModel = "Right";
            this.op = "work";
            this.dt = new Date();
            this.format = 'shortDate';
        }

        

        
    }
}