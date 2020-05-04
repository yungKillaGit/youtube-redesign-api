using System;
using System.Collections.Generic;
using System.Text;

namespace Youtube.Api.Core.Interfaces
{
    public interface IOutputPort<in TUseCaseResponse>
    {
        void Handle(TUseCaseResponse response); 
    }
}
