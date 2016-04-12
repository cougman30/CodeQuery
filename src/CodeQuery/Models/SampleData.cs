using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNet.Identity;
using Microsoft.Data.Entity;
using System.Security.Claims;

namespace CodeQuery.Models
{
    public class SampleData
    {
        public async static void Initialize(IServiceProvider sp)
        {
            var db = sp.GetService<ApplicationDbContext>();

            if (!db.Posts.Any())
            {
                db.Posts.AddRange(
                    new Post
                    {
                        Title = "How do I create webpages - I want to know",
                        Views = 115,
                        ReplyCount = 17,
                        Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque luctus, leo in volutpat eleifend, orci est pulvinar arcu, ac lacinia ex tellus vitae augue. Donec molestie nulla et elit vehicula finibus. Duis magna tellus, molestie sed rhoncus at, scelerisque vel enim. Nunc ornare, neque finibus efficitur congue, dolor ex semper dui, venenatis gravida nibh mi at mi. Morbi gravida sollicitudin ex, quis finibus ex tincidunt tincidunt. Donec tristique nisl vel libero ultrices finibus. Curabitur accumsan ex suscipit, venenatis tortor non, aliquam libero. Aliquam non malesuada eros.Vestibulum eget libero velit.Duis aliquet interdum elit, at eleifend tortor pellentesque nec. Maecenas id rhoncus sapien. Pellentesque orci neque, vehicula id tincidunt id, commodo ut nunc. Morbi vel pharetra magna, non malesuada tellus. Nunc id eleifend enim, sed sodales ante. Phasellus quis porttitor est. Suspendisse faucibus purus eu efficitur congue. Pellentesque mi ipsum, iaculis placerat pretium sed, convallis vitae elit. Aliquam venenatis ut sem non laoreet. Vestibulum at metus et tellus tincidunt aliquet.Duis bibendum urna diam, ut congue ex dignissim sed. Praesent lacinia enim velit, eu imperdiet diam feugiat eu. Proin sit amet dapibus orci, eget eleifend sem.In quis semper orci.Pellentesque faucibus libero in nunc egestas, sit amet consectetur nibh congue. Aenean vel turpis massa. In hac habitasse platea dictumst.Curabitur efficitur ut quam sit amet commodo.Sed vitae metus ut mauris dignissim luctus feugiat id purus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi eu enim lectus. Maecenas venenatis, diam ornare bibendum rhoncus, nulla orci finibus urna, vel bibendum lacus libero semper turpis.Sed eget sapien diam.Proin eget molestie mauris. Maecenas rutrum feugiat ligula non interdum. Nulla placerat, velit et fringilla gravida, metus nisl sodales sapien, nec mollis tellus erat a lacus.Nulla vitae tempor leo. Nulla at tortor lorem. Maecenas venenatis accumsan diam, vitae imperdiet sapien auctor vitae. Curabitur finibus dolor vel ante viverra, sit amet congue mauris egestas.",
                        Replies = new List<Reply> {
                            new Reply { Message = "This is a really good article", CreationDate = DateTime.Now, ModifiedDate = DateTime.Now },
                            new Reply { Message = "I don't understand", CreationDate = DateTime.Now, ModifiedDate = DateTime.Now },
                            new Reply { Message = "You just need to look at it from the left side", CreationDate = DateTime.Now, ModifiedDate = DateTime.Now }
                        },
                        CreationDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Votes = 6 
                    },
                    new Post
                    {
                        Title = "How do I style a webpage",
                        Views = 98,
                        ReplyCount = 23,
                        Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque luctus, leo in volutpat eleifend, orci est pulvinar arcu, ac lacinia ex tellus vitae augue. Donec molestie nulla et elit vehicula finibus. Duis magna tellus, molestie sed rhoncus at, scelerisque vel enim. Nunc ornare, neque finibus efficitur congue, dolor ex semper dui, venenatis gravida nibh mi at mi. Morbi gravida sollicitudin ex, quis finibus ex tincidunt tincidunt. Donec tristique nisl vel libero ultrices finibus. Curabitur accumsan ex suscipit, venenatis tortor non, aliquam libero.",
                        Replies = new List<Reply> {
                            new Reply { Message = "What are you talking about?", CreationDate = DateTime.Now, ModifiedDate = DateTime.Now },
                            new Reply { Message = "Help Me!", CreationDate = DateTime.Now, ModifiedDate = DateTime.Now },
                        },
                        CreationDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Votes = 1
                    },
                    new Post
                    {
                        Title = "How do I loop through an array",
                        Views = 361,
                        ReplyCount = 54,
                        Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque luctus, leo in volutpat eleifend, orci est pulvinar arcu, ac lacinia ex tellus vitae augue. Donec molestie nulla et elit vehicula finibus. Duis magna tellus, molestie sed rhoncus at, scelerisque vel enim. Nunc ornare, neque finibus efficitur congue, dolor ex semper dui, venenatis gravida nibh mi at mi. Morbi gravida sollicitudin ex, quis finibus ex tincidunt tincidunt. Donec tristique nisl vel libero ultrices finibus. Curabitur accumsan ex suscipit, venenatis tortor non, aliquam libero.",
                        Replies = new List<Reply> {
                            new Reply { Message = "How did you get that answer?", CreationDate = DateTime.Now, ModifiedDate = DateTime.Now },
                            new Reply { Message = "Go slower", CreationDate = DateTime.Now, ModifiedDate = DateTime.Now },
                            new Reply { Message = "By reading the lessons", CreationDate = DateTime.Now, ModifiedDate = DateTime.Now }
                        },
                        CreationDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Votes = 2
                    },
                    new Post
                    {
                        Title = "Can I add two classes to same html element",
                        Views = 56,
                        ReplyCount = 8,
                        Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque luctus, leo in volutpat eleifend, orci est pulvinar arcu, ac lacinia ex tellus vitae augue. Donec molestie nulla et elit vehicula finibus. Duis magna tellus, molestie sed rhoncus at, scelerisque vel enim. Nunc ornare, neque finibus efficitur congue, dolor ex semper dui, venenatis gravida nibh mi at mi. Morbi gravida sollicitudin ex, quis finibus ex tincidunt tincidunt. Donec tristique nisl vel libero ultrices finibus. Curabitur accumsan ex suscipit, venenatis tortor non, aliquam libero.",
                        Replies = new List<Reply> {
                            new Reply { Message = "You can do it!", CreationDate = DateTime.Now, ModifiedDate = DateTime.Now },
                            new Reply { Message = "I wanted the classes on the same element", CreationDate = DateTime.Now, ModifiedDate = DateTime.Now },
                        },
                        CreationDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Votes = 0
                    },
                    new Post
                    {
                        Title = "How to declare a variable in Javascript",
                        Views = 43,
                        ReplyCount = 11,
                        Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque luctus, leo in volutpat eleifend, orci est pulvinar arcu, ac lacinia ex tellus vitae augue. Donec molestie nulla et elit vehicula finibus. Duis magna tellus, molestie sed rhoncus at, scelerisque vel enim. Nunc ornare, neque finibus efficitur congue, dolor ex semper dui, venenatis gravida nibh mi at mi. Morbi gravida sollicitudin ex, quis finibus ex tincidunt tincidunt. Donec tristique nisl vel libero ultrices finibus. Curabitur accumsan ex suscipit, venenatis tortor non, aliquam libero.",
                        Replies = new List<Reply> {
                            new Reply { Message = "This is a really bad article", CreationDate = DateTime.Now, ModifiedDate = DateTime.Now },
                        },
                        CreationDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Votes = 9
                    },
                    new Post
                    {
                        Title = "How to create a new project in Visual Studio 2015",
                        Views = 25,
                        ReplyCount = 5,
                        Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque luctus, leo in volutpat eleifend, orci est pulvinar arcu, ac lacinia ex tellus vitae augue. Donec molestie nulla et elit vehicula finibus. Duis magna tellus, molestie sed rhoncus at, scelerisque vel enim. Nunc ornare, neque finibus efficitur congue, dolor ex semper dui, venenatis gravida nibh mi at mi. Morbi gravida sollicitudin ex, quis finibus ex tincidunt tincidunt. Donec tristique nisl vel libero ultrices finibus. Curabitur accumsan ex suscipit, venenatis tortor non, aliquam libero.",
                        Replies = new List<Reply> {
                            new Reply { Message = "Hello", CreationDate = DateTime.Now, ModifiedDate = DateTime.Now },
                            new Reply { Message = "Hola", CreationDate = DateTime.Now, ModifiedDate = DateTime.Now },
                            new Reply { Message = "Ciao", CreationDate = DateTime.Now, ModifiedDate = DateTime.Now },
                            new Reply { Message = "Ahoj", CreationDate = DateTime.Now, ModifiedDate = DateTime.Now },
                            new Reply { Message = "Hej", CreationDate = DateTime.Now, ModifiedDate = DateTime.Now },
                            new Reply { Message = "Salut", CreationDate = DateTime.Now, ModifiedDate = DateTime.Now }
                        },
                        CreationDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Votes = 13
                    },
                    new Post
                    {
                        Title = "What does inheritance mean",
                        Views = 11,
                        ReplyCount = 2,
                        Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque luctus, leo in volutpat eleifend, orci est pulvinar arcu, ac lacinia ex tellus vitae augue. Donec molestie nulla et elit vehicula finibus. Duis magna tellus, molestie sed rhoncus at, scelerisque vel enim. Nunc ornare, neque finibus efficitur congue, dolor ex semper dui, venenatis gravida nibh mi at mi. Morbi gravida sollicitudin ex, quis finibus ex tincidunt tincidunt. Donec tristique nisl vel libero ultrices finibus. Curabitur accumsan ex suscipit, venenatis tortor non, aliquam libero.",
                        Replies = new List<Reply> {
                            new Reply { Message = "I am lost", CreationDate = DateTime.Now, ModifiedDate = DateTime.Now },
                            new Reply { Message = "Don't panic!", CreationDate = DateTime.Now, ModifiedDate = DateTime.Now },
                        },
                        CreationDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Votes = 2
                    }
                    );
                db.SaveChanges();

                db.Labels.AddRange(
                    new Label { Text = "c#" },
                    new Label { Text = "html" },
                    new Label { Text = "inheritance" },
                    new Label { Text = "javascript" },
                    new Label { Text = "visual studio 2015" },
                    new Label { Text = "angular" },
                    new Label { Text = "ui-router" },
                    new Label { Text = "bootstrap" },
                    new Label { Text = "css" },
                    new Label { Text = "linq" },
                    new Label { Text = "database" },
                    new Label { Text = "web" },
                    new Label { Text = "typescript" },
                    new Label { Text = "array" },
                    new Label { Text = "loop" },
                    new Label { Text = "classes" }
                    );
                db.SaveChanges();

                db.PostLabels.AddRange(
                    new PostLabel
                    {
                        PostID = db.Posts.FirstOrDefault(m => m.Title == "How do I create webpages - I want to know").ID,
                        LabelID = db.Labels.FirstOrDefault(l => l.Text == "html").ID
                    },
                    new PostLabel
                    {
                        PostID = db.Posts.FirstOrDefault(m => m.Title == "How do I create webpages - I want to know").ID,
                        LabelID = db.Labels.FirstOrDefault(l => l.Text == "web").ID
                    },
                    new PostLabel
                    {
                        PostID = db.Posts.FirstOrDefault(m => m.Title == "How do I style a webpage").ID,
                        LabelID = db.Labels.FirstOrDefault(l => l.Text == "html").ID
                    }, new PostLabel
                    {
                        PostID = db.Posts.FirstOrDefault(m => m.Title == "How do I style a webpage").ID,
                        LabelID = db.Labels.FirstOrDefault(l => l.Text == "web").ID
                    },
                    new PostLabel
                    {
                        PostID = db.Posts.FirstOrDefault(m => m.Title == "How do I style a webpage").ID,
                        LabelID = db.Labels.FirstOrDefault(l => l.Text == "css").ID
                    },
                    new PostLabel
                    {
                        PostID = db.Posts.FirstOrDefault(m => m.Title == "How do I loop through an array").ID,
                        LabelID = db.Labels.FirstOrDefault(l => l.Text == "loop").ID
                    },
                    new PostLabel
                    {
                        PostID = db.Posts.FirstOrDefault(m => m.Title == "How do I loop through an array").ID,
                        LabelID = db.Labels.FirstOrDefault(l => l.Text == "array").ID
                    },
                    new PostLabel
                    {
                        PostID = db.Posts.FirstOrDefault(m => m.Title == "How do I loop through an array").ID,
                        LabelID = db.Labels.FirstOrDefault(l => l.Text == "javascript").ID
                    },
                    new PostLabel
                    {
                        PostID = db.Posts.FirstOrDefault(m => m.Title == "Can I add two classes to same html element").ID,
                        LabelID = db.Labels.FirstOrDefault(l => l.Text == "html").ID
                    },
                    new PostLabel
                    {
                        PostID = db.Posts.FirstOrDefault(m => m.Title == "Can I add two classes to same html element").ID,
                        LabelID = db.Labels.FirstOrDefault(l => l.Text == "classes").ID
                    },
                    new PostLabel
                    {
                        PostID = db.Posts.FirstOrDefault(m => m.Title == "How to declare a variable in Javascript").ID,
                        LabelID = db.Labels.FirstOrDefault(l => l.Text == "javascript").ID
                    },
                    new PostLabel
                    {
                        PostID = db.Posts.FirstOrDefault(m => m.Title == "How to create a new project in Visual Studio 2015").ID,
                        LabelID = db.Labels.FirstOrDefault(l => l.Text == "c#").ID
                    },
                    new PostLabel
                    {
                        PostID = db.Posts.FirstOrDefault(m => m.Title == "How to create a new project in Visual Studio 2015").ID,
                        LabelID = db.Labels.FirstOrDefault(l => l.Text == "visual studio 2015").ID
                    },
                    new PostLabel
                    {
                        PostID = db.Posts.FirstOrDefault(m => m.Title == "What does inheritance mean").ID,
                        LabelID = db.Labels.FirstOrDefault(l => l.Text == "inheritance").ID
                    },
                    new PostLabel
                    {
                        PostID = db.Posts.FirstOrDefault(m => m.Title == "What does inheritance mean").ID,
                        LabelID = db.Labels.FirstOrDefault(l => l.Text == "c#").ID
                    }
                    );
                db.SaveChanges();
            }

            var userManager = sp.GetService<UserManager<ApplicationUser>>();
            db.Database.Migrate();

            var mike = await userManager.FindByNameAsync("mike@mike.com");
            if (mike == null)
            {
                mike = new ApplicationUser
                {
                    UserName = "mike@mike.com",
                    Email = "mike@mike.com",
                    Birthday = new DateTime(1980, 11, 9),
                    AboutMe = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque luctus, leo in volutpat eleifend, orci est pulvinar arcu, ac lacinia ex tellus vitae augue. Donec molestie nulla et elit vehicula finibus. Duis magna tellus, molestie sed rhoncus at, scelerisque vel enim. Nunc ornare, neque finibus efficitur congue, dolor ex semper dui, venenatis gravida nibh mi at mi. Morbi gravida sollicitudin ex, quis finibus ex tincidunt tincidunt. Donec tristique nisl vel libero ultrices finibus. Curabitur accumsan ex suscipit, venenatis tortor non, aliquam libero.",
                    DisplayName = "Mike",
                    FirstName = "Mike",
                    LastName = "Smith",
                    IsActive = true,
                    Location = "Kirkland",
                    Company = "Microsoft",
                    Position = "Software Engineer",
                    GitHub = "http://github.com/mikesmith",
                    Twitter = "@mikesmith",
                    Website = "www.mikesmith.com"
                };
                await userManager.CreateAsync(mike, "tester");

                await userManager.AddClaimAsync(mike, new Claim("IsAdmin", "true"));
            }

            var steve = await userManager.FindByNameAsync("steve@steve.com");
            if (steve == null)
            {
                steve = new ApplicationUser
                {
                    UserName = "steve@steve.com",
                    Email = "steve@steve.com",
                    Birthday = new DateTime(1980, 11, 9),
                    AboutMe = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque luctus, leo in volutpat eleifend, orci est pulvinar arcu, ac lacinia ex tellus vitae augue. Donec molestie nulla et elit vehicula finibus. Duis magna tellus, molestie sed rhoncus at, scelerisque vel enim. Nunc ornare, neque finibus efficitur congue, dolor ex semper dui, venenatis gravida nibh mi at mi. Morbi gravida sollicitudin ex, quis finibus ex tincidunt tincidunt. Donec tristique nisl vel libero ultrices finibus. Curabitur accumsan ex suscipit, venenatis tortor non, aliquam libero.",
                    DisplayName = "steve",
                    FirstName = "Steve",
                    LastName = "Sims",
                    IsActive = true,
                    Location = "Redmond",
                    GitHub = "http://github.com/stevesims",
                    Twitter = "@stevesims",
                    Website = "www.stevesims.com",
                    SchoolDegree = "Computer Science",
                    SchoolName = "University of Washington"
                };
                await userManager.CreateAsync(steve, "tester");

                await userManager.AddClaimAsync(steve, new Claim("IsAdmin", "true"));
            }

            var adam = await userManager.FindByNameAsync("adam@adam.com");
            if (adam == null)
            {
                adam = new ApplicationUser
                {
                    UserName = "adam@adam.com",
                    Email = "adam@adam.com",
                    Birthday = new DateTime(1980, 11, 9),
                    AboutMe = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque luctus, leo in volutpat eleifend, orci est pulvinar arcu, ac lacinia ex tellus vitae augue. Donec molestie nulla et elit vehicula finibus. Duis magna tellus, molestie sed rhoncus at, scelerisque vel enim. Nunc ornare, neque finibus efficitur congue, dolor ex semper dui, venenatis gravida nibh mi at mi. Morbi gravida sollicitudin ex, quis finibus ex tincidunt tincidunt. Donec tristique nisl vel libero ultrices finibus. Curabitur accumsan ex suscipit, venenatis tortor non, aliquam libero.",
                    DisplayName = "adam",
                    FirstName = "Adam",
                    LastName = "Rhodes",
                    IsActive = true,
                    Location = "Bellevue",
                    Company = "The Seattle Times",
                    Position = "Front End Engineer",
                    GitHub = "http://github.com/adamrhodes",
                    Twitter = "@adamrhodes",
                    Website = "www.adamrhodes.com"
                };
                await userManager.CreateAsync(adam, "tester");
            }

            var greg = await userManager.FindByNameAsync("greg@greg.com");
            if (greg == null)
            {
                greg = new ApplicationUser
                {
                    UserName = "greg@greg.com",
                    Email = "greg@greg.com",
                    Birthday = new DateTime(1980, 11, 9),
                    AboutMe = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque luctus, leo in volutpat eleifend, orci est pulvinar arcu, ac lacinia ex tellus vitae augue. Donec molestie nulla et elit vehicula finibus. Duis magna tellus, molestie sed rhoncus at, scelerisque vel enim. Nunc ornare, neque finibus efficitur congue, dolor ex semper dui, venenatis gravida nibh mi at mi. Morbi gravida sollicitudin ex, quis finibus ex tincidunt tincidunt. Donec tristique nisl vel libero ultrices finibus. Curabitur accumsan ex suscipit, venenatis tortor non, aliquam libero.",
                    DisplayName = "greg",
                    FirstName = "Greg",
                    LastName = "Jackson",
                    IsActive = true,
                    Location = "Bellevue",
                    GitHub = "http://github.com/gregjackson",
                    Twitter = "@gregjackson",
                    Website = "www.gregjackson.com",
                    HobbyCode = "www.gregjackson.com/projects"
                };
                await userManager.CreateAsync(greg, "tester");
            }

            var shelly = await userManager.FindByNameAsync("shelly@shelly.com");
            if (shelly == null)
            {
                shelly = new ApplicationUser
                {
                    UserName = "shelly@shelly.com",
                    Email = "shelly@shelly.com",
                    Birthday = new DateTime(1980, 11, 9),
                    AboutMe = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque luctus, leo in volutpat eleifend, orci est pulvinar arcu, ac lacinia ex tellus vitae augue. Donec molestie nulla et elit vehicula finibus. Duis magna tellus, molestie sed rhoncus at, scelerisque vel enim. Nunc ornare, neque finibus efficitur congue, dolor ex semper dui, venenatis gravida nibh mi at mi. Morbi gravida sollicitudin ex, quis finibus ex tincidunt tincidunt. Donec tristique nisl vel libero ultrices finibus. Curabitur accumsan ex suscipit, venenatis tortor non, aliquam libero.",
                    DisplayName = "shelly",
                    FirstName = "Shelly",
                    LastName = "Little",
                    IsActive = true,
                    Location = "Bellevue",
                    GitHub = "http://github.com/shellylittle",
                    Twitter = "@shellylittle",
                    Website = "www.shellylittle.com",
                    HobbyCode = "www.shellylittle.com/projects"
                };
                await userManager.CreateAsync(shelly, "tester");
            }

            var mary = await userManager.FindByNameAsync("mary@mary.com");
            if (mary == null)
            {
                mary = new ApplicationUser
                {
                    UserName = "mary@mary.com",
                    Email = "mary@mary.com",
                    Birthday = new DateTime(1980, 11, 9),
                    AboutMe = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque luctus, leo in volutpat eleifend, orci est pulvinar arcu, ac lacinia ex tellus vitae augue. Donec molestie nulla et elit vehicula finibus. Duis magna tellus, molestie sed rhoncus at, scelerisque vel enim. Nunc ornare, neque finibus efficitur congue, dolor ex semper dui, venenatis gravida nibh mi at mi. Morbi gravida sollicitudin ex, quis finibus ex tincidunt tincidunt. Donec tristique nisl vel libero ultrices finibus. Curabitur accumsan ex suscipit, venenatis tortor non, aliquam libero.",
                    DisplayName = "mary",
                    FirstName = "Mary",
                    LastName = "Price",
                    IsActive = true,
                    Location = "Yakima",
                    GitHub = "http://github.com/maryprice",
                    Twitter = "@maryprice",
                    Website = "www.maryprice.com",
                    SchoolDegree = "Computer Science",
                    SchoolName = "Brigham Young University"
                };
                await userManager.CreateAsync(mary, "tester");

                await userManager.AddClaimAsync(mary, new Claim("IsAdmin", "true"));
            }
        }
    }
}
