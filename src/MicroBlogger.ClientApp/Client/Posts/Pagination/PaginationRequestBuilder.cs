// <auto-generated/>
#pragma warning disable CS0618
using MicroBlogger.Api.Client.Models;
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace MicroBlogger.Api.Client.Posts.Pagination
{
    /// <summary>
    /// Builds and executes requests for operations under \posts\pagination
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class PaginationRequestBuilder : BaseRequestBuilder
    {
        /// <summary>
        /// Instantiates a new <see cref="global::MicroBlogger.Api.Client.Posts.Pagination.PaginationRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public PaginationRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/posts/pagination", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::MicroBlogger.Api.Client.Posts.Pagination.PaginationRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public PaginationRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/posts/pagination", rawUrl)
        {
        }
        /// <summary>
        /// Returns a paginated list of posts based on search keywords, page size, and sorting options.
        /// </summary>
        /// <returns>A <see cref="global::MicroBlogger.Api.Client.Models.PaginatedResultOfPostsDto"/></returns>
        /// <param name="body">The request body</param>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="global::MicroBlogger.Api.Client.Models.ProblemDetails">When receiving a 400 status code</exception>
        /// <exception cref="global::MicroBlogger.Api.Client.Models.ProblemDetails">When receiving a 500 status code</exception>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<global::MicroBlogger.Api.Client.Models.PaginatedResultOfPostsDto?> PostAsync(global::MicroBlogger.Api.Client.Models.PostsWithPaginationQuery body, Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<global::MicroBlogger.Api.Client.Models.PaginatedResultOfPostsDto> PostAsync(global::MicroBlogger.Api.Client.Models.PostsWithPaginationQuery body, Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = ToPostRequestInformation(body, requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                { "400", global::MicroBlogger.Api.Client.Models.ProblemDetails.CreateFromDiscriminatorValue },
                { "500", global::MicroBlogger.Api.Client.Models.ProblemDetails.CreateFromDiscriminatorValue },
            };
            return await RequestAdapter.SendAsync<global::MicroBlogger.Api.Client.Models.PaginatedResultOfPostsDto>(requestInfo, global::MicroBlogger.Api.Client.Models.PaginatedResultOfPostsDto.CreateFromDiscriminatorValue, errorMapping, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Returns a paginated list of posts based on search keywords, page size, and sorting options.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="body">The request body</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToPostRequestInformation(global::MicroBlogger.Api.Client.Models.PostsWithPaginationQuery body, Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToPostRequestInformation(global::MicroBlogger.Api.Client.Models.PostsWithPaginationQuery body, Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default)
        {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation(Method.POST, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/json");
            requestInfo.SetContentFromParsable(RequestAdapter, "application/json", body);
            return requestInfo;
        }
        /// <summary>
        /// Returns a request builder with the provided arbitrary URL. Using this method means any other path or query parameters are ignored.
        /// </summary>
        /// <returns>A <see cref="global::MicroBlogger.Api.Client.Posts.Pagination.PaginationRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public global::MicroBlogger.Api.Client.Posts.Pagination.PaginationRequestBuilder WithUrl(string rawUrl)
        {
            return new global::MicroBlogger.Api.Client.Posts.Pagination.PaginationRequestBuilder(rawUrl, RequestAdapter);
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        [Obsolete("This class is deprecated. Please use the generic RequestConfiguration class generated by the generator.")]
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class PaginationRequestBuilderPostRequestConfiguration : RequestConfiguration<DefaultQueryParameters>
        {
        }
    }
}
#pragma warning restore CS0618
