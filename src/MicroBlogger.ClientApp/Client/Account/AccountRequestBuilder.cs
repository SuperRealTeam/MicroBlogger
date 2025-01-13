// <auto-generated/>
#pragma warning disable CS0618
using MicroBlogger.Api.Client.Account.ConfirmEmail;
using MicroBlogger.Api.Client.Account.DeleteOwnerAccount;
using MicroBlogger.Api.Client.Account.Disable2fa;
using MicroBlogger.Api.Client.Account.Enable2fa;
using MicroBlogger.Api.Client.Account.ForgotPassword;
using MicroBlogger.Api.Client.Account.GenerateAuthenticator;
using MicroBlogger.Api.Client.Account.GenerateRecoveryCodes;
using MicroBlogger.Api.Client.Account.Google;
using MicroBlogger.Api.Client.Account.Login2fa;
using MicroBlogger.Api.Client.Account.Logout;
using MicroBlogger.Api.Client.Account.Profile;
using MicroBlogger.Api.Client.Account.Signup;
using MicroBlogger.Api.Client.Account.UpdateEmail;
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;
namespace MicroBlogger.Api.Client.Account
{
    /// <summary>
    /// Builds and executes requests for operations under \account
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class AccountRequestBuilder : BaseRequestBuilder
    {
        /// <summary>The confirmEmail property</summary>
        public global::MicroBlogger.Api.Client.Account.ConfirmEmail.ConfirmEmailRequestBuilder ConfirmEmail
        {
            get => new global::MicroBlogger.Api.Client.Account.ConfirmEmail.ConfirmEmailRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The deleteOwnerAccount property</summary>
        public global::MicroBlogger.Api.Client.Account.DeleteOwnerAccount.DeleteOwnerAccountRequestBuilder DeleteOwnerAccount
        {
            get => new global::MicroBlogger.Api.Client.Account.DeleteOwnerAccount.DeleteOwnerAccountRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The disable2fa property</summary>
        public global::MicroBlogger.Api.Client.Account.Disable2fa.Disable2faRequestBuilder Disable2fa
        {
            get => new global::MicroBlogger.Api.Client.Account.Disable2fa.Disable2faRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The enable2fa property</summary>
        public global::MicroBlogger.Api.Client.Account.Enable2fa.Enable2faRequestBuilder Enable2fa
        {
            get => new global::MicroBlogger.Api.Client.Account.Enable2fa.Enable2faRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The forgotPassword property</summary>
        public global::MicroBlogger.Api.Client.Account.ForgotPassword.ForgotPasswordRequestBuilder ForgotPassword
        {
            get => new global::MicroBlogger.Api.Client.Account.ForgotPassword.ForgotPasswordRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The generateAuthenticator property</summary>
        public global::MicroBlogger.Api.Client.Account.GenerateAuthenticator.GenerateAuthenticatorRequestBuilder GenerateAuthenticator
        {
            get => new global::MicroBlogger.Api.Client.Account.GenerateAuthenticator.GenerateAuthenticatorRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The generateRecoveryCodes property</summary>
        public global::MicroBlogger.Api.Client.Account.GenerateRecoveryCodes.GenerateRecoveryCodesRequestBuilder GenerateRecoveryCodes
        {
            get => new global::MicroBlogger.Api.Client.Account.GenerateRecoveryCodes.GenerateRecoveryCodesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The google property</summary>
        public global::MicroBlogger.Api.Client.Account.Google.GoogleRequestBuilder Google
        {
            get => new global::MicroBlogger.Api.Client.Account.Google.GoogleRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The login2fa property</summary>
        public global::MicroBlogger.Api.Client.Account.Login2fa.Login2faRequestBuilder Login2fa
        {
            get => new global::MicroBlogger.Api.Client.Account.Login2fa.Login2faRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The logout property</summary>
        public global::MicroBlogger.Api.Client.Account.Logout.LogoutRequestBuilder Logout
        {
            get => new global::MicroBlogger.Api.Client.Account.Logout.LogoutRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The profile property</summary>
        public global::MicroBlogger.Api.Client.Account.Profile.ProfileRequestBuilder Profile
        {
            get => new global::MicroBlogger.Api.Client.Account.Profile.ProfileRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The signup property</summary>
        public global::MicroBlogger.Api.Client.Account.Signup.SignupRequestBuilder Signup
        {
            get => new global::MicroBlogger.Api.Client.Account.Signup.SignupRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The updateEmail property</summary>
        public global::MicroBlogger.Api.Client.Account.UpdateEmail.UpdateEmailRequestBuilder UpdateEmail
        {
            get => new global::MicroBlogger.Api.Client.Account.UpdateEmail.UpdateEmailRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new <see cref="global::MicroBlogger.Api.Client.Account.AccountRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public AccountRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/account", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::MicroBlogger.Api.Client.Account.AccountRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public AccountRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/account", rawUrl)
        {
        }
    }
}
#pragma warning restore CS0618
