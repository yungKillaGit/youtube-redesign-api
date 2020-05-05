using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Youtube.Api.Core.Dto.Entities;
using Youtube.Api.Core.Interfaces.Gateways.Repositories;
using Youtube.Api.Infrastructure.Data.Entities;

namespace Youtube.Api.Infrastructure.Data.EntityFramework.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private readonly IMapper _mapper;
        private readonly YoutubeContext _database;
        private readonly string _likedSection;
        private readonly string _dislikedSection;
        private readonly string _historySection;

        public VideoRepository(IMapper mapper, YoutubeContext database)
        {
            _mapper = mapper;
            _database = database;
            _likedSection = "Liked";
            _dislikedSection = "Disliked";
            _historySection = "History";
        }

        public int Create(VideoDto videoInfo)
        {
            throw new NotImplementedException();
        }

        public VideoDto FindById(int id)
        {
            return _mapper.Map<VideoDto>(_database.Videos.Find(id));
        }

        public IEnumerable<VideoDto> FindByName(string name)
        {
            return _mapper.Map<IEnumerable<VideoDto>>(_database.Videos.Where(x => x.Name.ToLower() == name).ToList());
        }

        public void HandleDislike(int videoId, int userId)
        {
            Section likedSection = _database.Sections.Where(x => x.Name == _likedSection).FirstOrDefault();
            Section dislikedSection = _database.Sections.Where(x => x.Name == _dislikedSection).FirstOrDefault();
            if (likedSection == null)
            {
                throw new NotImplementedException("liked section doesnt exist or section name is wrong");
            }
            if (dislikedSection == null)
            {
                throw new NotImplementedException("disliked section doesnt exist or section name is wrong");
            }
            SectionedVideo userLikedVideo = GetSectionedVideo(videoId, userId, likedSection.Id);
            SectionedVideo userDislikedVideo = GetSectionedVideo(videoId, userId, dislikedSection.Id);
            if (userLikedVideo != null)
            {
                _database.SectionedVideos.Remove(userLikedVideo);
                _database.SaveChanges();
            }

            Video video = _database.Videos.Find(videoId);
            if (userDislikedVideo == null)
            {                
                video.Dislikes++;
                _database.Videos.Update(video);

                userDislikedVideo = new SectionedVideo()
                {
                    VideoId = videoId,
                    UserId = userId,
                    SectionId = dislikedSection.Id,
                };
                _database.SectionedVideos.Add(userDislikedVideo);                
            }
            else
            {
                video.Dislikes--;
                _database.Videos.Update(video);

                _database.SectionedVideos.Remove(userDislikedVideo);
            }
            _database.SaveChanges();
        }

        public void HandleLike(int videoId, int userId)
        {
            Section likedSection = _database.Sections.Where(x => x.Name == _likedSection).FirstOrDefault();
            Section dislikedSection = _database.Sections.Where(x => x.Name == _dislikedSection).FirstOrDefault();
            if (likedSection == null)
            {
                throw new NotImplementedException("liked section doesnt exist or section name is wrong");
            }
            if (dislikedSection == null)
            {
                throw new NotImplementedException("disliked section doesnt exist or section name is wrong");
            }

            SectionedVideo userLikedVideo = GetSectionedVideo(videoId, userId, likedSection.Id);
            SectionedVideo userDislikedVideo = GetSectionedVideo(videoId, userId, dislikedSection.Id);

            if (userDislikedVideo != null)
            {
                _database.SectionedVideos.Remove(userDislikedVideo);
                _database.SaveChanges();
            }

            Video video = _database.Videos.Find(videoId);
            if (userLikedVideo == null)
            {                
                video.Likes++;
                _database.Videos.Update(video);
                
                userLikedVideo = new SectionedVideo()
                {
                    VideoId = videoId,
                    UserId = userId,
                    SectionId = likedSection.Id,
                };
                _database.SectionedVideos.Add(userLikedVideo);                
            }
            else
            {
                video.Likes--;
                _database.Videos.Update(video);

                _database.SectionedVideos.Remove(userLikedVideo);
            }
            _database.SaveChanges();
        }

        public void HandleView(int videoId, int userId)
        {
            Section historySection = _database.Sections.Where(x => x.Name == _historySection).FirstOrDefault();
            if (historySection == null)
            {
                throw new NotImplementedException("history section doesnt exist or section name is wrong");
            }

            SectionedVideo userWatchedVideo = GetSectionedVideo(videoId, userId, historySection.Id);
            if (userWatchedVideo == null)
            {
                userWatchedVideo = new SectionedVideo()
                {
                    VideoId = videoId,
                    UserId = userId,
                    SectionId = historySection.Id,
                };
                _database.SectionedVideos.Add(userWatchedVideo);
            }

            Video video = _database.Videos.Find(videoId);
            video.Views++;
            _database.Videos.Update(video);

            _database.SaveChanges();
        }

        private SectionedVideo GetSectionedVideo(int videoId, int userId, int sectionId)
        {
            SectionedVideo sectionedVideo = _database
                .SectionedVideos
                .Where(x => x.VideoId == videoId && x.UserId == userId && x.SectionId == sectionId)
                .FirstOrDefault();

            return sectionedVideo;
        }
    }
}
