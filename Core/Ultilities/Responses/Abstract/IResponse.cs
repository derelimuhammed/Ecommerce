using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Ultilities.Responses.Abstract
{
    public interface IResponse
    {
         bool Success { get; }
         int StatusCode { get; }
    }
}
