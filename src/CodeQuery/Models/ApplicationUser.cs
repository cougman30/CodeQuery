using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CodeQuery.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string Location { get; set; }
        public string Position { get; set; }
        public string Company { get; set; }
        public DateTime Birthday { get; set; }
        public string AboutMe { get; set; }
        public string Website { get; set; }
        public string Twitter { get; set; }
        public string GitHub { get; set; }
        public string WhereDoYouCode { get; set; }
        public string SchoolDegree { get; set; }
        public string SchoolName { get; set; }
        public string HobbyCode { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Post> Posts { get; set; }

        public ApplicationUser()
        {
            this.Posts = new List<Post>();
        }
    }
}
