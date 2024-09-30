﻿using CodeMonkeys.CMS.Public.Shared.Data;
using CodeMonkeys.CMS.Public.Shared.Repository;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace CodeMonkeys.CMS.Public.Shared.Middleware
{
    public class VisitCounterMiddleware : IMiddleware
    {
        private readonly IPageStatsRepository _repository;
        private readonly ILogger _logger;

        public VisitCounterMiddleware(IPageStatsRepository repository, ILogger<VisitCounterMiddleware> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the request.");
            }
            finally
            {
                try
                {
                    var header = context.Response.Headers["Content-Type"].ToString();
                    if (string.IsNullOrEmpty(header) || header.Contains("text/html"))
                    {
                        var pageUrl = context.Request.Path.Value;
                        if (pageUrl != null)
                        {
                            // Extract Site ID and page ID from the URL if it exists
                            var siteId = 0;
                            var pageId = 0;
                            bool siteIdFound = false;
                            var urlParts = pageUrl.Split('/');
                            foreach (var urlPart in urlParts)
                            {
                                if (int.TryParse(urlPart, out int id))
                                {
                                    if (!siteIdFound)
                                    {
                                        siteIdFound = true;
                                        siteId = id;
                                    }
                                    else
                                    {
                                        pageId = id;
                                        break;
                                    }
                                }
                            }

                            await _repository.UpdatePageCountAsync(siteId, pageId, pageUrl);
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}