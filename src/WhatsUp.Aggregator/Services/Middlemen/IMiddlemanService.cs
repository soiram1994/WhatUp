using FluentResults;

namespace WhatsUp.Aggregator.Services.Middlemen;

/// <summary>
///     Used by the delegation handlers to adjust the response from the external API.
/// </summary>
public interface IMiddlemanService
{
    /// <summary>
    ///     Adjusts the response from the external API.
    /// </summary>
    Result<HttpRequestMessage> AdjustRequest(HttpRequestMessage request);

    /// <summary>
    ///     Add logic to handle the response from the external API.
    /// </summary>
    Result<HttpResponseMessage> HandleResponse(HttpResponseMessage response);
}