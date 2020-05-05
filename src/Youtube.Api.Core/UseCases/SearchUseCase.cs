using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Core.Dto.Entities;
using Youtube.Api.Core.Dto.UseCaseRequests;
using Youtube.Api.Core.Dto.UseCaseResponses;
using Youtube.Api.Core.Interfaces;
using Youtube.Api.Core.Interfaces.Gateways.Repositories;
using Youtube.Api.Core.Interfaces.UseCases;

namespace Youtube.Api.Core.UseCases
{
    public class SearchUseCase : ISearchUseCase
    {
        private readonly IVideoRepository _videoRepository;
        private readonly IChannelRepository _channelRepository;

        public SearchUseCase(IVideoRepository videoRepository, IChannelRepository channelRepository)
        {
            _videoRepository = videoRepository;
            _channelRepository = channelRepository;
        }

        public bool Handle(SearchRequest useCaseRequest, IOutputPort<SearchResponse> outputPort)
        {
            IEnumerable<VideoDto> videos = _videoRepository.FindByName(useCaseRequest.SearchQuery);
            ChannelDto channel = _channelRepository.FindByName(useCaseRequest.SearchQuery);
            outputPort.Handle(new SearchResponse(videos, channel));

            return true;
        }
    }
}
