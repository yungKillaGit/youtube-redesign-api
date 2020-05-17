using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Youtube.Api.Core.Dto.Entities;
using Youtube.Api.Core.Dto.GatewayResponses.Repositories;
using Youtube.Api.Core.Interfaces.Gateways.Repositories;
using Youtube.Api.Infrastructure.Auth;
using Youtube.Api.Infrastructure.Data.Entities;

namespace Youtube.Api.Infrastructure.Data.EntityFramework.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMapper _mapper;
        private readonly YoutubeContext _database;

        public UserRepository(IMapper mapper, YoutubeContext database)
        {
            _mapper = mapper;
            _database = database;
        }

        public UserDto Create(UserDto userInfo)
        {
            var user = _mapper.Map<User>(userInfo);
            _database.Users.Add(user);
            _database.SaveChanges();

            return _mapper.Map<UserDto>(user);
        }

        public UserDto FindByEmail(string email)
        {
            User desiredUser = _database
                .Users
                .Include(user => user.Image)
                .Include(user => user.Channel)                
                .Include(user => user.Videos)
                  .ThenInclude(video => video.PreviewImage)
                .Where(x => x.Email == email)
                .FirstOrDefault();

            return _mapper.Map<UserDto>(desiredUser);
        }

        public UserDto FindById(int id)
        {
            return _mapper.Map<UserDto>(_database.Users.Find(id));
        }

        public UserDto SetUserProfilePicture(int pictureId, int userId)
        {
            User user = _database.Users.Find(userId);            
            user.ImageId = pictureId;
            _database.Users.Update(user);
            _database.SaveChanges();
            return _mapper.Map<UserDto>(user);
        }

        public UserDto UpdateUser(UserDto userInfo)
        {
            var user = _mapper.Map<User>(userInfo);
            _database.Users.Update(user);
            _database.SaveChanges();
            return _mapper.Map<UserDto>(user);
        }
    }
}
