// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace MicroBlogger.Api.Client.Account.ConfirmEmail
{
    /// <summary>
    /// Builds and executes requests for operations under \account\confirmEmail
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class ConfirmEmailRequestBuilder : BaseRequestBuilder
    {
        /// <summary>
        /// Instantiates a new <see cref="global::MicroBlogger.Api.Client.Account.ConfirmEmail.ConfirmEmailRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public ConfirmEmailRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/account/confirmEmail?code={code}&userId={userId}{&changedEmail*}", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::MicroBlogger.Api.Client.Account.ConfirmEmail.ConfirmEmailRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public ConfirmEmailRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/account/confirmEmail?code={code}&userId={userId}{&changedEmail*}", rawUrl)
        {
        }
        /// <summary>
        /// Processes email confirmation or email change requests for a user. It validates the confirmation code, verifies the user ID, and updates the email if a new one is provided. Returns a success message upon successful confirmation or email update.
        /// </summary>
        /// <returns>A <see cref="Stream"/></returns>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<Stream?> GetAsync(Action<RequestConfiguration<global::MicroBlogger.Api.Client.Account.ConfirmEmail.ConfirmEmailRequestBuilder.ConfirmEmailRequestBuilderGetQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<Stream> GetAsync(Action<RequestConfiguration<global::MicroBlogger.Api.Client.Account.ConfirmEmail.ConfirmEmailRequestBuilder.ConfirmEmailRequestBuilderGetQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            return await RequestAdapter.SendPrimitiveAsync<Stream>(requestInfo, default, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Processes email confirmation or email change requests for a user. It validates the confirmation code, verifies the user ID, and updates the email if a new one is provided. Returns a success message upon successful confirmation or email update.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::MicroBlogger.Api.Client.Account.ConfirmEmail.ConfirmEmailRequestBuilder.ConfirmEmailRequestBuilderGetQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::MicroBlogger.Api.Client.Account.ConfirmEmail.ConfirmEmailRequestBuilder.ConfirmEmailRequestBuilderGetQueryParameters>> requestConfiguration = default)
        {
#endif
            var requestInfo = new RequestInformation(Method.GET, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            return requestInfo;
        }
        /// <summary>
        /// Returns a request builder with the provided arbitrary URL. Using this method means any other path or query parameters are ignored.
        /// </summary>
        /// <returns>A <see cref="global::MicroBlogger.Api.Client.Account.ConfirmEmail.ConfirmEmailRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public global::MicroBlogger.Api.Client.Account.ConfirmEmail.ConfirmEmailRequestBuilder WithUrl(string rawUrl)
        {
            return new global::MicroBlogger.Api.Client.Account.ConfirmEmail.ConfirmEmailRequestBuilder(rawUrl, RequestAdapter);
        }
        /// <summary>
        /// Processes email confirmation or email change requests for a user. It validates the confirmation code, verifies the user ID, and updates the email if a new one is provided. Returns a success message upon successful confirmation or email update.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class ConfirmEmailRequestBuilderGetQueryParameters 
        {
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("changedEmail")]
            public string? ChangedEmail { get; set; }
#nullable restore
#else
            [QueryParameter("changedEmail")]
            public string ChangedEmail { get; set; }
#endif
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("code")]
            public string? Code { get; set; }
#nullable restore
#else
            [QueryParameter("code")]
            public string Code { get; set; }
#endif
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("userId")]
            public string? UserId { get; set; }
#nullable restore
#else
            [QueryParameter("userId")]
            public string UserId { get; set; }
#endif
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        [Obsolete("This class is deprecated. Please use the generic RequestConfiguration class generated by the generator.")]
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class ConfirmEmailRequestBuilderGetRequestConfiguration : RequestConfiguration<global::MicroBlogger.Api.Client.Account.ConfirmEmail.ConfirmEmailRequestBuilder.ConfirmEmailRequestBuilderGetQueryParameters>
        {
        }
    }
}
#pragma warning restore CS0618