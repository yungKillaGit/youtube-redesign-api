using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Core.Interfaces.UseCases;
using Youtube.Api.Core.UseCases;

namespace Youtube.Api.Core
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SectionListUseCase>().As<ISectionListUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<NewSectionUseCase>().As<INewSectionUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<LoginUseCase>().As<ILoginUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<RegisterUserUseCase>().As<IRegisterUserUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<NewCommentUseCase>().As<INewCommentUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<NewChannelUseCase>().As<INewChannelUseCase>().InstancePerLifetimeScope();
        }
    }
}
