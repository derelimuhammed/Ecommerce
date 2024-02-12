﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Ultilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection serviceCollection, IConfiguration configuration);
    }
}
