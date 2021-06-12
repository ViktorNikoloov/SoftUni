using System;
using System.Collections.Generic;
using System.Linq;

namespace SIS.MvcFramework
{
    public class ServiceCollection : IServiceCollection
    {
        private Dictionary<Type, Type> dependecyContainer = new Dictionary<Type, Type>();

        public void Add<TSourse, TDestination>()
        {
            dependecyContainer[typeof(TSourse)] = typeof(TDestination);
        }

        public object CreateInstance(Type type)
        {
            if (dependecyContainer.ContainsKey(type))
            {
                type = dependecyContainer[type];
            }

            var constructor = type.GetConstructors()
                .OrderBy(x => x.GetParameters().Count())
                .FirstOrDefault();

            var parameters = constructor.GetParameters();
            var parameterValues = new List<object>();
            foreach (var parameter in parameters)
            {
                var parameterValue = CreateInstance(parameter.ParameterType);
                parameterValues.Add(parameterValue);
            }

            var obj = constructor.Invoke(parameterValues.ToArray());

            return obj;
        }
    }
}
