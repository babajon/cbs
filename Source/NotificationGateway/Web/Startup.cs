/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Linq;
using System.Reflection;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Infrastructure.AspNet;

namespace Web
{
    public class Startup  : Infrastructure.AspNet.Startup
    {
        public Startup(
          ILoggerFactory loggerFactory,
          IHostingEnvironment env,
          IConfiguration configuration) : base(loggerFactory, env, configuration)
        {
        }
    }
}