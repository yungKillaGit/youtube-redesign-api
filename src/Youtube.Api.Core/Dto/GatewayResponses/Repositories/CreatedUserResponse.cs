using System;
using System.Collections.Generic;
using System.Text;

namespace Youtube.Api.Core.Dto.GatewayResponses.Repositories
{
    public class CreatedUserResponse : BaseGatewayResponse
    {
        public int Id { get; }

        public CreatedUserResponse(int id, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Id = id;
        }
    }
}
