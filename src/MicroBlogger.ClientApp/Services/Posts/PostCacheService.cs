// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using MicroBlogger.Api.Client.Models;
using MicroBlogger.ClientApp.Services.JsInterop;

namespace MicroBlogger.ClientApp.Services.Posts;

public class PostCacheService
{
    private readonly IndexedDbCache _cache;
    public const string DATABASENAME = IndexedDbCache.DATABASENAME;
    private const string OFFLINE_CREATE_COMMAND_CACHE_KEY = "OfflineCreateCommand:product";
    private const string OFFLINE_UPDATE_COMMAND_CACHE_KEY = "OfflineUpdateCommand:product";
    private const string OFFLINE_DELETE_COMMAND_CACHE_KEY = "OfflineDeleteCommand:product";
    private const string OFFLINE_PAGINATION_CACHE_TAG = "OfflinePagination:";
    private const string PAGINATION_TAG = "products_pagination";
    private const string COMMANDS_TAG = "product_commands";
    private const string OBJECT_TAG = "product";

    public PostCacheService(IndexedDbCache cache)
    {
        _cache = cache;
    }
    public async Task SaveOrUpdatePostAsync(PostsDto post)
    {
        var productCacheKey = GenerateProductCacheKey(post.PostId);
        await _cache.SaveDataAsync(DATABASENAME, productCacheKey, post, new[] { OBJECT_TAG });
    }
    public async Task<PaginatedResultOfPostsDto?> GetPaginatedProductsAsync(PostsWithPaginationQuery query)
    {
        var cacheKey = GeneratePaginationCacheKey(query);
        return await _cache.GetDataAsync<PaginatedResultOfPostsDto>(DATABASENAME, cacheKey);
    }
    public async Task SaveOrUpdatePaginatedProductsAsync(PostsWithPaginationQuery query, PaginatedResultOfPostsDto data)
    {
        var cacheKey = GeneratePaginationCacheKey(query);
        await _cache.SaveDataAsync(DATABASENAME, cacheKey, data, new[] { PAGINATION_TAG });
    }
    public async Task SaveOrUpdatePaginatedPostsAsync(string cacheKey, PaginatedResultOfPostsDto data)
    {
        await _cache.SaveDataAsync(DATABASENAME, cacheKey, data, new[] { PAGINATION_TAG });
    }
    public async Task<Dictionary<string, PaginatedResultOfPostsDto>> GetAllCachedPaginatedResultsAsync()
    {
        var cachedData = await _cache.GetDataByTagsAsync<PaginatedResultOfPostsDto>(
                DATABASENAME, new[] { PAGINATION_TAG }
            );
        return cachedData ?? new Dictionary<string, PaginatedResultOfPostsDto>();
    }
    public async Task<Tuple<int, List<CreatePostCommand>>> GetAllPendingCommandsAsync()
    {
        var createCommands = await _cache.GetDataAsync<List<CreatePostCommand>>(
            IndexedDbCache.DATABASENAME, OFFLINE_CREATE_COMMAND_CACHE_KEY
        ) ?? new List<CreatePostCommand>();


        return new Tuple<int, List<CreatePostCommand>>(
            createCommands.Count,
            createCommands

        );
    }
    public async Task StoreOfflineCreateCommandAsync(CreatePostCommand command)
    {
        var cached = await _cache.GetDataAsync<List<CreatePostCommand>>(
            DATABASENAME, OFFLINE_CREATE_COMMAND_CACHE_KEY
        ) ?? new List<CreatePostCommand>();

        cached.Add(command);
        await _cache.SaveDataAsync(DATABASENAME, OFFLINE_CREATE_COMMAND_CACHE_KEY, cached, new[] { COMMANDS_TAG });
    }
    public async Task ClearCommands()
    {
        await _cache.DeleteDataAsync(DATABASENAME, OFFLINE_CREATE_COMMAND_CACHE_KEY);
       
    }
    private string GenerateProductCacheKey(string postId)
    {
        return $"{nameof(PostsDto)}:{postId}";
    }
    private string GeneratePaginationCacheKey(PostsWithPaginationQuery query)
    {
        return $"{nameof(PostsWithPaginationQuery)}:{query.PageNumber}_{query.PageSize}_{query.Keywords}_{query.OrderBy}_{query.SortDirection}";
    }
}
