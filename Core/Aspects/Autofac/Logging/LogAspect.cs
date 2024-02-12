using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logging.SeriLog;
using Core.CrossCuttingConcerns.Logging;
using Core.Ultilities.Interceptors;
using Core.Ultilities.IoC;
using Newtonsoft.Json;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Core.Aspects.Autofac.Logging
{
	public class LogAspect : MethodInterception
	{
		private readonly LoggerServiceBase _loggerServiceBase;
		private readonly IHttpContextAccessor _httpContextAccessor;
		public LogAspect(Type loggerService)
		{
			if (loggerService.BaseType != typeof(LoggerServiceBase))
			{
				throw new ArgumentException("Wrongloggertype");
			}
			_loggerServiceBase = (LoggerServiceBase)ServiceTool.ServiceProvider.GetService(loggerService);
			_httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
		}
		protected override void OnSuccess(IInvocation invocation)
		{
			_loggerServiceBase?.Info(GetLogDetail(invocation));	
		}

        private string GetLogDetail(IInvocation invocation)
        {
			var logDetail = new LogDetail
			{
				Data = invocation.Arguments,
				MethodName = invocation.Method.Name,
				ManagerName = invocation.MethodInvocationTarget.ReflectedType.Name,
				UserId = (_httpContextAccessor?.HttpContext == null || _httpContextAccessor?.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value == null) ? "?" : _httpContextAccessor?.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value,
				Username = (_httpContextAccessor?.HttpContext == null || _httpContextAccessor?.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value == null) ? "?" : _httpContextAccessor?.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value,
			};
			return JsonConvert.SerializeObject(logDetail);
		}
	}
}
