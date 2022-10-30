using Autofac;
using InterviewApp.Core.Interfaces;
using InterviewApp.Core.Services;

namespace InterviewApp.Core
{
    public class DefaultCoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StudentService>()
                .As<IStudentService>().InstancePerLifetimeScope();

        }
    }
}
