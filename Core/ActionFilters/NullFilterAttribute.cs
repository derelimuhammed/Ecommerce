using Core.Entities;
using Core.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ActionFilters
{
    public class NullFilterAttribute : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments.Count > 0)
            {
                var param = context.ActionArguments.Select(p => p.Value is IDto);
                if (param == null)
                {
                    throw new ApiException(400, "İsteğinizin modeli boş, lütfen modeli veya özellik tiplerini kontrol edin.");
                }
            }
            else
            {
                var param = context.ActionArguments.SingleOrDefault(p => p.Value is IDto);
                if (param.Value == null)
                {
                    throw new ApiException(400, "İsteğinizin modeli boş, lütfen modeli veya özellik tiplerini kontrol edin.");
                }
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}
