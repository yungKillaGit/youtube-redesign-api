using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Core.Interfaces.Gateways.Repositories;
using Youtube.Api.Core.Interfaces.Services;
using Youtube.Api.Infrastructure.Auth;
using Youtube.Api.Infrastructure.Data;
using Youtube.Api.Infrastructure.Data.EntityFramework.Repositories;

namespace Youtube.Api.Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {            
            builder.RegisterType<SectionRepository>().As<ISectionRepository>().InstancePerLifetimeScope();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<VideoRepository>().As<IVideoRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CommentRepository>().As<ICommentRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ChannelRepository>().As<IChannelRepository>().InstancePerLifetimeScope();
            builder.RegisterType<JwtFactory>().As<IJwtFactory>().SingleInstance();
        }
    }
}
