// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System;
namespace MicroBlogger.Api.Client.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    #pragma warning disable CS1591
    public partial class AccessTokenResponse : IAdditionalDataHolder, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>The accessToken property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? AccessToken { get; set; }
#nullable restore
#else
        public string AccessToken { get; set; }
#endif
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The expiresIn property</summary>
        public long? ExpiresIn { get; set; }
        /// <summary>The refreshToken property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? RefreshToken { get; set; }
#nullable restore
#else
        public string RefreshToken { get; set; }
#endif
        /// <summary>The tokenType property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? TokenType { get; set; }
#nullable restore
#else
        public string TokenType { get; set; }
#endif
        /// <summary>
        /// Instantiates a new <see cref="global::MicroBlogger.Api.Client.Models.AccessTokenResponse"/> and sets the default values.
        /// </summary>
        public AccessTokenResponse()
        {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::MicroBlogger.Api.Client.Models.AccessTokenResponse"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::MicroBlogger.Api.Client.Models.AccessTokenResponse CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::MicroBlogger.Api.Client.Models.AccessTokenResponse();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "accessToken", n => { AccessToken = n.GetStringValue(); } },
                { "expiresIn", n => { ExpiresIn = n.GetLongValue(); } },
                { "refreshToken", n => { RefreshToken = n.GetStringValue(); } },
                { "tokenType", n => { TokenType = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("accessToken", AccessToken);
            writer.WriteLongValue("expiresIn", ExpiresIn);
            writer.WriteStringValue("refreshToken", RefreshToken);
            writer.WriteStringValue("tokenType", TokenType);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
#pragma warning restore CS0618