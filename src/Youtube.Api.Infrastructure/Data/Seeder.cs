using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Infrastructure.Auth;
using Youtube.Api.Infrastructure.Data.Entities;

namespace Youtube.Api.Infrastructure.Data
{
    public class Seeder
    {
        private readonly YoutubeContext _database;

        public Seeder(YoutubeContext database)
        {
            _database = database;
        }

        public void Seed()
        {
            ClearDatabase();

            _database.Users.AddRange(FakeDataGenerator.GetFakeUsers());
            _database.Sections.AddRange(FakeDataGenerator.GetFakeSections());
            _database.SaveChanges();
        }

        private void ClearDatabase()
        {
            _database.ChannelSubscribers.RemoveRange(_database.ChannelSubscribers);
            _database.Channels.RemoveRange(_database.Channels);
            _database.Comments.RemoveRange(_database.Comments);
            _database.ProfilePictures.RemoveRange(_database.ProfilePictures);
            _database.SectionedVideos.RemoveRange(_database.SectionedVideos);
            _database.Videos.RemoveRange(_database.Videos);
            _database.UploadedFiles.RemoveRange(_database.UploadedFiles);
            _database.Sections.RemoveRange(_database.Sections);
            _database.Users.RemoveRange(_database.Users);
            _database.SaveChanges();
        }        
    }
}
