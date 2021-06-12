using System;

namespace SIS.MvcFramework
{
    public interface IServiceCollection
    {
        //.Add<IUsersService, UserService>
        void Add<TSourse, TDestination>();

        object CreateInstance(Type type);
    }
}
