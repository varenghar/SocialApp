﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SocialApp2.Data;
using SocialApp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialApp.Models
{
    public class SeedData
    {

        public static async System.Threading.Tasks.Task InitializeAsync(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

                if (context.Users.Any())
                {
                    return;   // DB has been seeded
                }

                User user1 = new User { UserName = "email1@email.com", Email = "email1@email.com" };
                User user2 = new User { UserName = "email2@email.com", Email = "email2@email.com" };
                User user3 = new User { UserName = "email3@email.com", Email = "email3@email.com" };
                User user4 = new User { UserName = "email4@email.com", Email = "email4@email.com" };

                await userManager.CreateAsync(user1, "!Abc123");
                await userManager.CreateAsync(user2, "!Abc123");
                await userManager.CreateAsync(user3, "!Abc123");
                await userManager.CreateAsync(user4, "!Abc123");

                // Look for any Posts.
                if (context.Posts.Any())
                {
                    return;   // DB has been seeded
                }

                Post post1 = new Post
                {
                    Author = user1.Email,
                    Title = "Wheneeee Harry Met Sally",
                    ReleaseDate = DateTime.Parse("2018-1-12"),
                    Content = "amazing post bla bla bla bla bla",
                    Likes = 0,
                    UserId = user1.Id
                };

                Post post2 = new Post
                {
                    Author = user2.Email,
                    Title = "Wheneee heheesasdadhehe",
                    ReleaseDate = DateTime.Parse("2018-2-11"),
                    Content = "amazing post 3",
                    Likes = 0,
                    UserId = user2.Id
                };

                Post post3 = new Post
                {
                    Author = user3.Email,
                    Title = "When heheehehe",
                    ReleaseDate = DateTime.Parse("2018-2-11"),
                    Content = "amazdding post 3",
                    Likes = 0,
                    UserId = user3.Id
                };

                Post post4 = new Post
                {
                    Author = user4.Email,
                    Title = "huahuahuahuah",
                    ReleaseDate = DateTime.Parse("2018-4-12"),
                    Content = "amaddazing post 4",
                    Likes = 0,
                    UserId = user4.Id
                };

                context.Posts.AddRange(
                    post1, post2, post3, post4
                );

                // Look for any Posts.
                if (context.Friends.Any())
                {
                    return;   // DB has been seeded
                }

                Friend friends = new Friend
                {
                    UserReceiverId = user1.Id,
                    UserSenderId = user2.Id
                };

                Friend friends2 = new Friend
                {
                    UserReceiverId = user1.Id,
                    UserSenderId = user3.Id
                };

                context.Friends.AddRange(friends, friends2);

                context.SaveChanges();
            }

        }

    }
}
