using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Ultilities.Interceptors;
using Core.Ultilities.IoC;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Core.CrossCuttingConcerns.Caching.Redis;


namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect(int duration = 60) : MethodInterception
    {
        private readonly IMemoryCacheManager? _cacheManager = ServiceTool.ServiceProvider.GetService<IMemoryCacheManager>();

        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            if (_cacheManager is null)
            {
                return;
            }
            if (_cacheManager.IsAdd(key))
            {
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }
            invocation.Proceed();
            _cacheManager.Add(key, invocation.ReturnValue, duration);
        }
    }
}
