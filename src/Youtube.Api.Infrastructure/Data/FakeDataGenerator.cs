using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Infrastructure.Auth;
using Youtube.Api.Infrastructure.Data.Entities;
using Youtube.Api.Infrastructure.Helpers;

namespace Youtube.Api.Infrastructure.Data
{
    public static class FakeDataGenerator
    {
        public static User[] GetFakeUsers()
        {
            return new[]
            {
                new User()
                {
                    Name = "Артур",
                    Email = "test@domain.com",
                    BirthDay = DateTime.Parse("1999-08-17"),
                    PasswordHash = Cipher.Encrypt("test"),
                    ProfilePictureId = null,
                },
                new User()
                {
                    Name = "Смотрящий",
                    Email = "viewer@domain.com",
                    BirthDay = DateTime.Parse("1989-08-17"),
                    PasswordHash = Cipher.Encrypt("test"),
                    ProfilePictureId = null,
                },
            };
        }

        public static Section[] GetFakeSections()
        {
            return new[]
            {
                new Section()
                {
                    Name = Constants.Strings.Sections.Disliked
                },
                new Section()
                {
                    Name = Constants.Strings.Sections.History
                },
                new Section()
                {
                    Name = Constants.Strings.Sections.Liked
                },
                new Section()
                {
                    Name = Constants.Strings.Sections.PendingVideos
                },
            };
        }
    }
}
