using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Youtube.Api.Core.Dto;
using Youtube.Api.Core.Dto.Entities;

namespace Youtube.Api.Core.Interfaces.Services
{
    public interface IJwtFactory
    {
        Token GenerateEncodedToken(UserDto user);
    }
}
