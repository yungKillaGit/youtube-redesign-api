using AutoMapper;
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

        public CreatedUserResponse Create(UserDto userInfo)
        {
            var user = _mapper.Map<User>(userInfo);
            _database.Users.Add(user);
            _database.SaveChanges();

            return new CreatedUserResponse(user.Id, true);
        }

        public UserDto FindByEmail(string email)
        {
            User desiredUser = _database.Users.Where(x => x.Email == email).FirstOrDefault();

            return _mapper.Map<UserDto>(desiredUser);
        }

        private User FindById(int id)
        {
            return _database.Users.Find(id);
        }
    }
}
