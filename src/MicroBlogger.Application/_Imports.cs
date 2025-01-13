// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Threading.Tasks;
global using MicroBlogger.Domain;
global using Microsoft.EntityFrameworkCore;
global using MicroBlogger.Application.Common.Interfaces;
global using MicroBlogger.Application.Common.Interfaces.FusionCache;
global using MicroBlogger.Application.Common.Models;
global using MicroBlogger.Application.Common;
global using MicroBlogger.Domain.Entities;
global using FluentValidation;
global using Mediator;
global using Microsoft.Extensions.Logging;
global using ZiggyCreatures.Caching.Fusion;
