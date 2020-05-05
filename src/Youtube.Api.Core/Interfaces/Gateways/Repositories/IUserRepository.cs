using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Core.Dto.Entities;
using Youtube.Api.Core.Dto.GatewayResponses.Repositories;

namespace Youtube.Api.Core.Interfaces.Gateways.Repositories
{
    public interface IUserRepository
    {
        CreatedUserResponse Create(UserDto userInfo);
        UserDto FindByEmail(string email);
        UserDto FindById(int id);
    }
}
