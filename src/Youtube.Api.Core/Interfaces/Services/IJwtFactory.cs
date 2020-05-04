using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Youtube.Api.Core.Dto;

namespace Youtube.Api.Core.Interfaces.Services
{
    public interface IJwtFactory
    {
        Token GenerateEncodedToken(int id, string email);
    }
}
