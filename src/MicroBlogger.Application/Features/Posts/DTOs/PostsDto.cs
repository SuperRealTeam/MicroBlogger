﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBlogger.Application.Features.Posts.DTOs;
public class PostsDto
{
    public string PostId { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;

    public string TempImageUrl { get; set; } = string.Empty;

    public string ImageUrl { get; set; } = string.Empty;


    public double Longtuide { get; set; }

    public double Latitude { get; set; }

    public string CreatedBy { get; set; } = string.Empty;

    public string Created { get; set; } = string.Empty;
}