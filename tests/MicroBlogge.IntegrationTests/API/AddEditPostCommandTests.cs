// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using MicroBlogger.Application.Features.Posts.Commands;
using MicroBlogger.Domain.Entities;
using NUnit.Framework;

namespace MicroBlogger.IntegrationTests;
using static Testing;
internal class AddEditPostCommandTests : TestBase
{
   
    [Test]
    public async Task InsertItem()
    {
        var addCommand = new CreatePostCommand("Test", "", "", 0, 0);
       
        var result = await SendAsync(addCommand);
        var find = await FindAsync<Post>(result);
        find.Should().NotBeNull();
        find.Message.Should().Be("Test");
        find.TempImageUrl.Should().Be("");
        find.TempImageUrl.Should().Be("");
        
    }

   
}
