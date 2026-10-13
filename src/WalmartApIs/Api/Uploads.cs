using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core;
using WalmartApIs.Core.Exceptions;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Request;
using WalmartApIs.Core.Response;
using WalmartApIs.Errors;
using WalmartApIs.Models;
using WalmartApIs.Requests.Uploads;

namespace WalmartApIs.Api;

public sealed class Uploads
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Uploads(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Creates an upload destination for the resource given
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CreateUploadDestinationResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateUploadDestinationForResourceError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a pre-signed URL and upload destination ID for uploading
    /// a document for the given resource (e.g. feeds, reports).
    /// <b>Do not log the pre-signed URL — it contains temporary credentials.</b>
    /// </remarks>
    public Task<CreateUploadDestinationResponse> CreateUploadDestinationForResource(CreateUploadDestinationForResourceRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/uploads/v4/uploadDestinations/{resource}"),
            [new TemplateParam("resource", request.Resource)],
            [new Param("contentType", request.ContentType), new Param("marketplaceIds", request.MarketplaceIds)],
            [new HeaderParam("contentMD5", request.ContentMd5), new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            EmptyBody.Instance,
            JsonResponse.Create<CreateUploadDestinationResponse>(),
            CreateUploadDestinationForResourceError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);
}
