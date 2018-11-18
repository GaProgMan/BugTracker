using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using OwaspHeaders.Core;
using OwaspHeaders.Core.Enums;
using OwaspHeaders.Core.Extensions;
using OwaspHeaders.Core.Models;

namespace bugTracker.Core.WebUI.Extensions
{
    public static class HttpPipelineExtensions
    {
        /// <summary>
        /// Used to include the <see cref="SecureHeadersMiddleware"/> middleware and set up the
        /// <see cref="SecureHeadersMiddlewareConfiguration"/> for it.
        /// </summary>
        /// <param name="applicationBuilder">
        /// The <see cref="IApplicationBuilder"/> which is used in the Http Pipeline
        /// </param>
        /// <param name="blockAndUpgradeInsecure">
        /// OPTIONAL: Used to enable/disable blocking and upgrading odf all requests
        /// when not in developement
        /// </param>
        public static void UseSecureHeaders(this IApplicationBuilder applicationBuilder,
            string apiUrl,
            bool blockAndUpgradeInsecure = true)
        {
            var config = SecureHeadersMiddlewareBuilder
                .CreateBuilder()
                .UseHsts()
                .UseXFrameOptions()
                .UseXSSProtection()
                .UseContentTypeOptions()
                .UseContentSecurityPolicy(blockAllMixedContent:blockAndUpgradeInsecure, upgradeInsecureRequests: blockAndUpgradeInsecure)
                .UsePermittedCrossDomainPolicies()
                .UseReferrerPolicy()
                .Build();

            config.ContentSecurityPolicyConfiguration.ScriptSrc = new List<ContenSecurityPolicyElement>()
            {
                new ContenSecurityPolicyElement
                {
                    CommandType = CspCommandType.Directive,
                    DirectiveOrUri = "self"
                },
                new ContenSecurityPolicyElement
                {
                    CommandType = CspCommandType.Uri,
                    DirectiveOrUri = "https://cdnjs.cloudflare.com"
                },
                new ContenSecurityPolicyElement
                {
                    CommandType = CspCommandType.Uri,
                    DirectiveOrUri = apiUrl
                },
                new ContenSecurityPolicyElement
                {
                    CommandType = CspCommandType.Directive,
                    DirectiveOrUri = "sha256-e3w2Kj2e9dyg5Y6D+IcCncnl56F1dHbDjE0kjQw6zbg="
                }
            };
            
            applicationBuilder.UseSecureHeadersMiddleware(config);
        }
    }
}