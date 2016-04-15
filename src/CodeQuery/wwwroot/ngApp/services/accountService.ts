namespace MyApp.Services
{

    export class AccountService
    {

        public loggedIn = false;
        private accountResource;

        // Store access token and claims in browser session storage
        private storeUserInfo(userInfo)
        {
            //console.log(userInfo);
            // store user name
            this.$window.sessionStorage.setItem('userName', userInfo.userName);
            this.$window.sessionStorage.setItem('firstName', userInfo.firstName);
            this.$window.sessionStorage.setItem('lastName', userInfo.lastname);
            this.$window.sessionStorage.setItem('displayName', userInfo.displayName);
            this.$window.sessionStorage.setItem('userID', userInfo.userID);

            // store claims
            this.$window.sessionStorage.setItem('claims', JSON.stringify(userInfo.claims));
        }

        public getUserInfo(id)
        {
            var userResource = this.$resource('/api/account/details');
            return userResource.get({ id: id });
        }

        public getUserName()
        {
            return this.$window.sessionStorage.getItem('userName');
        }

        public getFirstName()
        {
            return this.$window.sessionStorage.getItem('firstName');
        }

        public getUserID()
        {
            return this.$window.sessionStorage.getItem('userID');
        }

        public TestUserID()
        {
            console.log("test");
            console.log(this.getUserID());
        }


        public getClaim(type)
        {
            var allClaims = JSON.parse(this.$window.sessionStorage.getItem('claims'));
            return allClaims ? allClaims[type] : null;
        }


        public login(loginUser)
        {
            return this.$q((resolve, reject) =>
            {
                this.$http.post('/api/account/login', loginUser).then((result) =>
                {
                    this.loggedIn = true;
                    console.log("set loggedin to true");
                    this.storeUserInfo(result.data);
                    resolve();
                }).catch((result) =>
                {
                    var messages = this.flattenValidation(result.data);
                    reject(messages);
                });
            });
        }

        public register(userLogin)
        {
            return this.$q((resolve, reject) =>
            {
                this.$http.post('/api/account/register', userLogin)
                    .then((result) =>
                    {
                        this.storeUserInfo(result.data);
                        resolve(result);
                    })
                    .catch((result) =>
                    {
                        var messages = this.flattenValidation(result.data);
                        reject(messages);
                    });
            });
        }


        public logout()
        {
            // clear all of session storage (including claims)
            this.$window.sessionStorage.clear();

            this.loggedIn = false;

            // logout on the server
            return this.$http.post('/api/account/logout', null);
        }

        public isLoggedIn()
        {
            return this.$window.sessionStorage.getItem('userName');
        }

        // associate external login (e.g., Twitter) with local user account
        public registerExternal(email)
        {
            return this.$q((resolve, reject) =>
            {
                this.$http.post('/api/account/externalLoginConfirmation', { email: email })
                    .then((result) =>
                    {
                        this.storeUserInfo(result.data);
                        resolve(result);
                    })
                    .catch((result) =>
                    {
                        // flatten error messages
                        let messages = this.flattenValidation(result.data);
                        reject(messages);
                    });
            });
        }



        getExternalLogins(): ng.IPromise<{}>
        {
            return this.$q((resolve, reject) =>
            {
                let url = `api/Account/getExternalLogins?returnUrl=%2FexternalLogin&generateState=true`;
                this.$http.get(url).then((result: any) =>
                {
                    resolve(result.data);
                }).catch((result) =>
                {
                    reject(result);
                });
            });
        }


        // checks whether the current user is authenticated on the server and returns user info
        public checkAuthentication()
        {
            this.$http.get('/api/account/checkAuthentication')
                .then((result) =>
                {
                    if (result.data)
                    {
                        this.storeUserInfo(result.data);
                    }
                });
        }

        confirmEmail(userId, code): ng.IPromise<{}>
        {
            return this.$q((resolve, reject) =>
            {
                let data = {
                    userId: userId,
                    code: code
                };
                this.$http.post('/api/account/confirmEmail', data).then((result: any) =>
                {
                    resolve(result.data);
                }).catch((result) =>
                {
                    reject(result);
                });
            });
        }


        // extract access token from response
        parseOAuthResponse(token)
        {
            let results = {};
            token.split('&').forEach((item) =>
            {
                let pair = item.split('=');
                results[pair[0]] = pair[1];
            });
            return results;
        }


        private flattenValidation(modelState)
        {
            let messages = [];
            for (let prop in modelState)
            {
                messages = messages.concat(modelState[prop]);
            }
            return messages;
        }

        constructor
            (
            private $q: ng.IQService,
            private $http: ng.IHttpService,
            private $window: ng.IWindowService,
            private $resource: ng.resource.IResourceService
            )
        {
            // in case we are redirected from a social provider
            // we need to check if we are authenticated.
            this.checkAuthentication();
            this.accountResource = this.$resource('/api/account/');
        }

    }

    angular.module('MyApp').service('accountService', AccountService);
}
