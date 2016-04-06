﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace CodeQuery.Models
{
    public class SampleData
    {
        public static void Initialize(IServiceProvider sp)
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
                            new Reply { Message = "This is a really good article" },
                            new Reply { Message = "I don't understand" },
                            new Reply { Message = "You just need to look at it from the left side" }
                        }   
                    },
                    new Post
                    {
                        Title = "How do I style a webpage",
                        Views = 98,
                        ReplyCount = 23,
                        Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque luctus, leo in volutpat eleifend, orci est pulvinar arcu, ac lacinia ex tellus vitae augue. Donec molestie nulla et elit vehicula finibus. Duis magna tellus, molestie sed rhoncus at, scelerisque vel enim. Nunc ornare, neque finibus efficitur congue, dolor ex semper dui, venenatis gravida nibh mi at mi. Morbi gravida sollicitudin ex, quis finibus ex tincidunt tincidunt. Donec tristique nisl vel libero ultrices finibus. Curabitur accumsan ex suscipit, venenatis tortor non, aliquam libero.",
                        Replies = new List<Reply> {
                            new Reply { Message = "What are you talking about?" },
                            new Reply { Message = "Help Me!" },
                        }
                    },
                    new Post
                    {
                        Title = "How do I loop through an array",
                        Views = 361,
                        ReplyCount = 54,
                        Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque luctus, leo in volutpat eleifend, orci est pulvinar arcu, ac lacinia ex tellus vitae augue. Donec molestie nulla et elit vehicula finibus. Duis magna tellus, molestie sed rhoncus at, scelerisque vel enim. Nunc ornare, neque finibus efficitur congue, dolor ex semper dui, venenatis gravida nibh mi at mi. Morbi gravida sollicitudin ex, quis finibus ex tincidunt tincidunt. Donec tristique nisl vel libero ultrices finibus. Curabitur accumsan ex suscipit, venenatis tortor non, aliquam libero.",
                        Replies = new List<Reply> {
                            new Reply { Message = "How did you get that answer?" },
                            new Reply { Message = "Go slower" },
                            new Reply { Message = "By reading the lessons" }
                        }
                    },
                    new Post
                    {
                        Title = "Can I add two classes to same html element",
                        Views = 56,
                        ReplyCount = 8,
                        Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque luctus, leo in volutpat eleifend, orci est pulvinar arcu, ac lacinia ex tellus vitae augue. Donec molestie nulla et elit vehicula finibus. Duis magna tellus, molestie sed rhoncus at, scelerisque vel enim. Nunc ornare, neque finibus efficitur congue, dolor ex semper dui, venenatis gravida nibh mi at mi. Morbi gravida sollicitudin ex, quis finibus ex tincidunt tincidunt. Donec tristique nisl vel libero ultrices finibus. Curabitur accumsan ex suscipit, venenatis tortor non, aliquam libero.",
                        Replies = new List<Reply> {
                            new Reply { Message = "You can do it!" },
                            new Reply { Message = "I wanted the classes on the same element" },
                        }
                    },
                    new Post
                    {
                        Title = "How to declare a variable in Javascript",
                        Views = 43,
                        ReplyCount = 11,
                        Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque luctus, leo in volutpat eleifend, orci est pulvinar arcu, ac lacinia ex tellus vitae augue. Donec molestie nulla et elit vehicula finibus. Duis magna tellus, molestie sed rhoncus at, scelerisque vel enim. Nunc ornare, neque finibus efficitur congue, dolor ex semper dui, venenatis gravida nibh mi at mi. Morbi gravida sollicitudin ex, quis finibus ex tincidunt tincidunt. Donec tristique nisl vel libero ultrices finibus. Curabitur accumsan ex suscipit, venenatis tortor non, aliquam libero.",
                        Replies = new List<Reply> {
                            new Reply { Message = "This is a really bad article" },
                        }
                    },
                    new Post
                    {
                        Title = "How to create a new project in Visual Studio 2015",
                        Views = 25,
                        ReplyCount = 5,
                        Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque luctus, leo in volutpat eleifend, orci est pulvinar arcu, ac lacinia ex tellus vitae augue. Donec molestie nulla et elit vehicula finibus. Duis magna tellus, molestie sed rhoncus at, scelerisque vel enim. Nunc ornare, neque finibus efficitur congue, dolor ex semper dui, venenatis gravida nibh mi at mi. Morbi gravida sollicitudin ex, quis finibus ex tincidunt tincidunt. Donec tristique nisl vel libero ultrices finibus. Curabitur accumsan ex suscipit, venenatis tortor non, aliquam libero.",
                        Replies = new List<Reply> {
                            new Reply { Message = "Hello" },
                            new Reply { Message = "Hola" },
                            new Reply { Message = "Ciao" },
                            new Reply { Message = "Ahoj" },
                            new Reply { Message = "Hej" },
                            new Reply { Message = "Salut" }
                        }
                    },
                    new Post
                    {
                        Title = "What does inheritance mean",
                        Views = 11,
                        ReplyCount = 2,
                        Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque luctus, leo in volutpat eleifend, orci est pulvinar arcu, ac lacinia ex tellus vitae augue. Donec molestie nulla et elit vehicula finibus. Duis magna tellus, molestie sed rhoncus at, scelerisque vel enim. Nunc ornare, neque finibus efficitur congue, dolor ex semper dui, venenatis gravida nibh mi at mi. Morbi gravida sollicitudin ex, quis finibus ex tincidunt tincidunt. Donec tristique nisl vel libero ultrices finibus. Curabitur accumsan ex suscipit, venenatis tortor non, aliquam libero.",
                        Replies = new List<Reply> {
                            new Reply { Message = "I am lost" },
                            new Reply { Message = "Don't panic!" },
                        }
                    }
                    );
                db.SaveChanges();

                db.Labels.AddRange(
                    new Label { Title = "c#" },
                    new Label { Title = "html" },
                    new Label { Title = "inheritance" },
                    new Label { Title = "javascript" },
                    new Label { Title = "visual studio 2015" },
                    new Label { Title = "angular" },
                    new Label { Title = "ui-router" },
                    new Label { Title = "bootstrap" },
                    new Label { Title = "css" },
                    new Label { Title = "linq" },
                    new Label { Title = "database" },
                    new Label { Title = "web" },
                    new Label { Title = "typescript" },
                    new Label { Title = "array" },
                    new Label { Title = "loop" },
                    new Label { Title = "classes" }
                    );
                db.SaveChanges();

                db.PostLabels.AddRange(
                    new PostLabel
                    {
                        PostID = db.Posts.FirstOrDefault(m => m.Title == "How do I create webpages - I want to know").ID,
                        LabelID = db.Labels.FirstOrDefault(l => l.Title == "html").ID
                    },
                    new PostLabel
                    {
                        PostID = db.Posts.FirstOrDefault(m => m.Title == "How do I create webpages - I want to know").ID,
                        LabelID = db.Labels.FirstOrDefault(l => l.Title == "web").ID
                    },
                    new PostLabel
                    {
                        PostID = db.Posts.FirstOrDefault(m => m.Title == "How do I style a webpage").ID,
                        LabelID = db.Labels.FirstOrDefault(l => l.Title == "html").ID
                    }, new PostLabel
                    {
                        PostID = db.Posts.FirstOrDefault(m => m.Title == "How do I style a webpage").ID,
                        LabelID = db.Labels.FirstOrDefault(l => l.Title == "web").ID
                    },
                    new PostLabel
                    {
                        PostID = db.Posts.FirstOrDefault(m => m.Title == "How do I style a webpage").ID,
                        LabelID = db.Labels.FirstOrDefault(l => l.Title == "css").ID
                    },
                    new PostLabel
                    {
                        PostID = db.Posts.FirstOrDefault(m => m.Title == "How do I loop through an array").ID,
                        LabelID = db.Labels.FirstOrDefault(l => l.Title == "loop").ID
                    },
                    new PostLabel
                    {
                        PostID = db.Posts.FirstOrDefault(m => m.Title == "How do I loop through an array").ID,
                        LabelID = db.Labels.FirstOrDefault(l => l.Title == "array").ID
                    },
                    new PostLabel
                    {
                        PostID = db.Posts.FirstOrDefault(m => m.Title == "How do I loop through an array").ID,
                        LabelID = db.Labels.FirstOrDefault(l => l.Title == "javascript").ID
                    },
                    new PostLabel
                    {
                        PostID = db.Posts.FirstOrDefault(m => m.Title == "Can I add two classes to same html element").ID,
                        LabelID = db.Labels.FirstOrDefault(l => l.Title == "html").ID
                    },
                    new PostLabel
                    {
                        PostID = db.Posts.FirstOrDefault(m => m.Title == "Can I add two classes to same html element").ID,
                        LabelID = db.Labels.FirstOrDefault(l => l.Title == "classes").ID
                    },
                    new PostLabel
                    {
                        PostID = db.Posts.FirstOrDefault(m => m.Title == "How to declare a variable in Javascript").ID,
                        LabelID = db.Labels.FirstOrDefault(l => l.Title == "javascript").ID
                    },
                    new PostLabel
                    {
                        PostID = db.Posts.FirstOrDefault(m => m.Title == "How to create a new project in Visual Studio 2015").ID,
                        LabelID = db.Labels.FirstOrDefault(l => l.Title == "c#").ID
                    },
                    new PostLabel
                    {
                        PostID = db.Posts.FirstOrDefault(m => m.Title == "How to create a new project in Visual Studio 2015").ID,
                        LabelID = db.Labels.FirstOrDefault(l => l.Title == "visual studio 2015").ID
                    },
                    new PostLabel
                    {
                        PostID = db.Posts.FirstOrDefault(m => m.Title == "What does inheritance mean").ID,
                        LabelID = db.Labels.FirstOrDefault(l => l.Title == "inheritance").ID
                    },
                    new PostLabel
                    {
                        PostID = db.Posts.FirstOrDefault(m => m.Title == "What does inheritance mean").ID,
                        LabelID = db.Labels.FirstOrDefault(l => l.Title == "c#").ID
                    }
                    );
                db.SaveChanges();
            }
        }
    }
}
