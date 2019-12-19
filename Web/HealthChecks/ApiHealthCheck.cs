﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace WeAppEip.Web.HealthChecks
{
    public class ApiHealthCheck : IHealthCheck
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly LinkGenerator _linkGenerator;

        public ApiHealthCheck(IHttpContextAccessor httpContextAccessor, LinkGenerator linkGenerator)
        {
            _httpContextAccessor = httpContextAccessor;
            _linkGenerator = linkGenerator;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = _httpContextAccessor.HttpContext.Request;

            string apiLink = _linkGenerator.GetPathByAction("Ping", "HealthCheck");
            string myUrl = request.Scheme + "://" + request.Host.ToString() + apiLink;
            var client = new HttpClient();
            var response = await client.GetAsync(myUrl);
            var pageContents = await response.Content.ReadAsStringAsync();
            if (pageContents.Contains(".NET Bot Black Sweatshirt"))
            {
                return HealthCheckResult.Healthy("The check indicates a healthy result.");
            }

            return HealthCheckResult.Unhealthy("The check indicates an unhealthy result.");
        }
    }
}
