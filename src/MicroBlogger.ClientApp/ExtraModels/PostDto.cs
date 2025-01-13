// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using MicroBlogger.Api.Client.Models;
using Microsoft.AspNetCore.Components.Forms;

namespace MicroBlogger.ClientApp.ExtraModels;

public class PostDto : CreatePostCommand
{
    public IBrowserFile File { get; set; }
}
