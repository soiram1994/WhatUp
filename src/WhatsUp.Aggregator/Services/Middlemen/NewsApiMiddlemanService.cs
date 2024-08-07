using FluentResults;
using WhatsUp.Aggregator.Helpers;

namespace WhatsUp.Aggregator.Services.Middlemen;

public class NewsApiMiddlemanService : IMiddlemanService
{
    public Result<HttpRequestMessage> AdjustRequest(HttpRequestMessage request)
    {
        if (request.RequestUri == null) return Result.Fail("Request URI is null.");

        var key = Environment.GetEnvironmentVariable("NEWS_API_KEY");
        if (string.IsNullOrEmpty(key)) return Result.Fail("News API key is missing.");

        var uriResult = request.RequestUri.AddKeyToUri("apiKey", key);
        request.Headers.Add("User-Agent", "WhatsUp Gateway");
        if (uriResult.IsFailed) return Result.Fail(uriResult.Errors);

        request.RequestUri = uriResult.Value;
        return Result.Ok(request);
    }

    public Result<HttpResponseMessage> HandleResponse(HttpResponseMessage response)
    {
        return !response.IsSuccessStatusCode
            ? Result.Fail("News API request failed.")
            : Result.Ok(response);
    }
}