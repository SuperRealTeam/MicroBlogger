// <auto-generated/>
#pragma warning disable CS0618
using MicroBlogger.Api.Client.Account.Google.LoginUrl;
using MicroBlogger.Api.Client.Account.Google.SignIn;
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;
namespace MicroBlogger.Api.Client.Account.Google
{
    /// <summary>
    /// Builds and executes requests for operations under \account\google
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class GoogleRequestBuilder : BaseRequestBuilder
    {
        /// <summary>The loginUrl property</summary>
        public global::MicroBlogger.Api.Client.Account.Google.LoginUrl.LoginUrlRequestBuilder LoginUrl
        {
            get => new global::MicroBlogger.Api.Client.Account.Google.LoginUrl.LoginUrlRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The signIn property</summary>
        public global::MicroBlogger.Api.Client.Account.Google.SignIn.SignInRequestBuilder SignIn
        {
            get => new global::MicroBlogger.Api.Client.Account.Google.SignIn.SignInRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new <see cref="global::MicroBlogger.Api.Client.Account.Google.GoogleRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public GoogleRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/account/google", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::MicroBlogger.Api.Client.Account.Google.GoogleRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public GoogleRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/account/google", rawUrl)
        {
        }
    }
}
#pragma warning restore CS0618
