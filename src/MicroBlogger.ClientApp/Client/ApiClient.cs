// <auto-generated/>
#pragma warning disable CS0618
using MicroBlogger.Api.Client.Account;
using MicroBlogger.Api.Client.ConfirmEmail;
using MicroBlogger.Api.Client.FileManagement;
using MicroBlogger.Api.Client.ForgotPassword;
using MicroBlogger.Api.Client.Login;
using MicroBlogger.Api.Client.Manage;
using MicroBlogger.Api.Client.Posts;
using MicroBlogger.Api.Client.Products;
using MicroBlogger.Api.Client.Refresh;
using MicroBlogger.Api.Client.Register;
using MicroBlogger.Api.Client.ResendConfirmationEmail;
using MicroBlogger.Api.Client.ResetPassword;
using MicroBlogger.Api.Client.Tenants;
using MicroBlogger.Api.Client.Webpushr;
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Serialization.Form;
using Microsoft.Kiota.Serialization.Json;
using Microsoft.Kiota.Serialization.Multipart;
using Microsoft.Kiota.Serialization.Text;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;
namespace MicroBlogger.Api.Client
{
    /// <summary>
    /// The main entry point of the SDK, exposes the configuration and the fluent API.
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class ApiClient : BaseRequestBuilder
    {
        /// <summary>The account property</summary>
        public global::MicroBlogger.Api.Client.Account.AccountRequestBuilder Account
        {
            get => new global::MicroBlogger.Api.Client.Account.AccountRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The confirmEmail property</summary>
        public global::MicroBlogger.Api.Client.ConfirmEmail.ConfirmEmailRequestBuilder ConfirmEmail
        {
            get => new global::MicroBlogger.Api.Client.ConfirmEmail.ConfirmEmailRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The fileManagement property</summary>
        public global::MicroBlogger.Api.Client.FileManagement.FileManagementRequestBuilder FileManagement
        {
            get => new global::MicroBlogger.Api.Client.FileManagement.FileManagementRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The forgotPassword property</summary>
        public global::MicroBlogger.Api.Client.ForgotPassword.ForgotPasswordRequestBuilder ForgotPassword
        {
            get => new global::MicroBlogger.Api.Client.ForgotPassword.ForgotPasswordRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The login property</summary>
        public global::MicroBlogger.Api.Client.Login.LoginRequestBuilder Login
        {
            get => new global::MicroBlogger.Api.Client.Login.LoginRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The manage property</summary>
        public global::MicroBlogger.Api.Client.Manage.ManageRequestBuilder Manage
        {
            get => new global::MicroBlogger.Api.Client.Manage.ManageRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The posts property</summary>
        public global::MicroBlogger.Api.Client.Posts.PostsRequestBuilder Posts
        {
            get => new global::MicroBlogger.Api.Client.Posts.PostsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The products property</summary>
        public global::MicroBlogger.Api.Client.Products.ProductsRequestBuilder Products
        {
            get => new global::MicroBlogger.Api.Client.Products.ProductsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The refresh property</summary>
        public global::MicroBlogger.Api.Client.Refresh.RefreshRequestBuilder Refresh
        {
            get => new global::MicroBlogger.Api.Client.Refresh.RefreshRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The register property</summary>
        public global::MicroBlogger.Api.Client.Register.RegisterRequestBuilder Register
        {
            get => new global::MicroBlogger.Api.Client.Register.RegisterRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The resendConfirmationEmail property</summary>
        public global::MicroBlogger.Api.Client.ResendConfirmationEmail.ResendConfirmationEmailRequestBuilder ResendConfirmationEmail
        {
            get => new global::MicroBlogger.Api.Client.ResendConfirmationEmail.ResendConfirmationEmailRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The resetPassword property</summary>
        public global::MicroBlogger.Api.Client.ResetPassword.ResetPasswordRequestBuilder ResetPassword
        {
            get => new global::MicroBlogger.Api.Client.ResetPassword.ResetPasswordRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The tenants property</summary>
        public global::MicroBlogger.Api.Client.Tenants.TenantsRequestBuilder Tenants
        {
            get => new global::MicroBlogger.Api.Client.Tenants.TenantsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The webpushr property</summary>
        public global::MicroBlogger.Api.Client.Webpushr.WebpushrRequestBuilder Webpushr
        {
            get => new global::MicroBlogger.Api.Client.Webpushr.WebpushrRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new <see cref="global::MicroBlogger.Api.Client.ApiClient"/> and sets the default values.
        /// </summary>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public ApiClient(IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}", new Dictionary<string, object>())
        {
            ApiClientBuilder.RegisterDefaultSerializer<JsonSerializationWriterFactory>();
            ApiClientBuilder.RegisterDefaultSerializer<TextSerializationWriterFactory>();
            ApiClientBuilder.RegisterDefaultSerializer<FormSerializationWriterFactory>();
            ApiClientBuilder.RegisterDefaultSerializer<MultipartSerializationWriterFactory>();
            ApiClientBuilder.RegisterDefaultDeserializer<JsonParseNodeFactory>();
            ApiClientBuilder.RegisterDefaultDeserializer<TextParseNodeFactory>();
            ApiClientBuilder.RegisterDefaultDeserializer<FormParseNodeFactory>();
        }
    }
}
#pragma warning restore CS0618
