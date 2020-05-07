using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Youtube.Api.Core.Interfaces
{
    public interface IUseCaseRequestHandler<in TUseCaseRequest, out TUseCaseResponse> where TUseCaseRequest : IUseCaseRequest<TUseCaseResponse>
    {
        bool Handle(TUseCaseRequest request, IOutputPort<TUseCaseResponse> outputPort);
    }

    public interface IAsyncUseCaseRequestHandler<in TUseCaseRequest, out TUseCaseResponse> where TUseCaseRequest : IUseCaseRequest<TUseCaseResponse>
    {
        Task<bool> Handle(TUseCaseRequest request, IOutputPort<TUseCaseResponse> outputPort);
    }

    public interface IUseCaseRequestHandler<out TUseCaseResponse>
    {
        bool Handle(IOutputPort<TUseCaseResponse> outputPort);
    }
}
