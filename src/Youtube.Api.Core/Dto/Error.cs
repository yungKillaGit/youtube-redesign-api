using System;
using System.Collections.Generic;
using System.Text;

namespace Youtube.Api.Core.Dto
{
    public class Error
    {
        public int Code { get; }
        public string Description { get; }

        public Error(int code, string description)
        {
            Code = code;
            Description = description;
        }
    }
}
