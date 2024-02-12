using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching.Redis;
using Core.Ultilities.Interceptors;
using Core.Ultilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Caching
{
      public class CacheRemoveAspect : MethodInterception
    {
        private readonly string _pattern;
        private readonly IMemoryCacheManager _cacheManager;
        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<IMemoryCacheManager>();
        }
        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
