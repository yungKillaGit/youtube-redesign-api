using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Youtube.Api.Core.Dto.Entities;
using Youtube.Api.Core.Interfaces.Gateways.Repositories;
using Youtube.Api.Infrastructure.Data.Entities;
using Youtube.Api.Infrastructure.Helpers;

namespace Youtube.Api.Infrastructure.Data.EntityFramework.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private readonly IMapper _mapper;
        private readonly YoutubeContext _database;

        public VideoRepository(IMapper mapper, YoutubeContext database)
        {
            _mapper = mapper;
            _database = database;
        }

        public int Create(VideoDto videoInfo)
        {
            var video = _mapper.Map<Video>(videoInfo);
            _database.Videos.Add(video);
            _database.SaveChanges();
            return video.Id;
        }

        public VideoDto FindById(int id)
        {
            return _mapper.Map<VideoDto>(_database.Videos.Find(id));
        }

        public IEnumerable<VideoDto> FindByName(string name)
        {
            var videos = _database.Videos.Where(x => Regex.Replace(x.Name, @"\s+", " ").ToLower() == name).ToList();
            return _mapper.Map<IEnumerable<VideoDto>>(videos);
        }

        public void HandleDislike(int videoId, int userId)
        {
            Section likedSection = _database.Sections.Where(x => x.Name == Constants.Strings.Sections.Liked).FirstOrDefault();
            Section dislikedSection = _database.Sections.Where(x => x.Name == Constants.Strings.Sections.Disliked).FirstOrDefault();
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
            Video video = _database.Videos.Find(videoId);

            if (userLikedVideo != null)
            {
                video.Likes--;
                _database.Videos.Update(video);

                _database.SectionedVideos.Remove(userLikedVideo);                
            }
            
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
            Section likedSection = _database.Sections.Where(x => x.Name == Constants.Strings.Sections.Liked).FirstOrDefault();
            Section dislikedSection = _database.Sections.Where(x => x.Name == Constants.Strings.Sections.Disliked).FirstOrDefault();
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
            Video video = _database.Videos.Find(videoId);

            if (userDislikedVideo != null)
            {
                video.Dislikes--;
                _database.Videos.Update(video);

                _database.SectionedVideos.Remove(userDislikedVideo);                
            }
            
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

        public void HandleView(int videoId, int? userId)
        {
            Video video = _database.Videos.Find(videoId);
            if (userId == null)
            {
                video.Views++;
                _database.Videos.Update(video);
                _database.SaveChanges();

                return;
            }

            Section historySection = _database.Sections.Where(x => x.Name == Constants.Strings.Sections.History).FirstOrDefault();
            if (historySection == null)
            {
                throw new NotImplementedException("history section doesnt exist or section name is wrong");
            }

            SectionedVideo userWatchedVideo = GetSectionedVideo(videoId, (int)userId, historySection.Id);
            if (userWatchedVideo == null)
            {
                userWatchedVideo = new SectionedVideo()
                {
                    VideoId = videoId,
                    UserId = (int)userId,
                    SectionId = historySection.Id,
                };
                _database.SectionedVideos.Add(userWatchedVideo);
            }
            
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
