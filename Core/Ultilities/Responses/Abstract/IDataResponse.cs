﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Ultilities.Responses.Abstract
{
     public interface IDataResponse<T> : IResponse
    {
        T Data { get; }
        string Message { get; }
    }
}
