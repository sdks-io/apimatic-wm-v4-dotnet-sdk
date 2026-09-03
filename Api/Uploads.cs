using System;
using System.Collections.Generic;
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
using WalmartApIs.Models.Enums;

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
    /// <param name="resource">The resource type for the upload destination (e.g. feeds)</param>
    /// <param name="contentType">MIME type of the content to be uploaded</param>
    /// <param name="marketplaceIds"></param>
    /// <param name="contentMd5">MD5 hash of the content to be uploaded, encoded as base64</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CreateUploadDestinationResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="CreateUploadDestinationForResourceError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a pre-signed URL and upload destination ID for uploading
    /// a document for the given resource (e.g. feeds, reports).
    /// <b>Do not log the pre-signed URL — it contains temporary credentials.</b>
    /// </remarks>
    public Task<CreateUploadDestinationResponse> CreateUploadDestinationForResource(Resource resource,
        ContentType1 contentType,
        IReadOnlyList<string> marketplaceIds,
        string contentMd5,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/uploads/v4/uploadDestinations/{resource}"),
            [new TemplateParam("resource", resource)],
            [new Param("contentType", contentType), new Param("marketplaceIds", marketplaceIds)],
            [new HeaderParam("contentMD5", contentMd5), new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            EmptyBody.Instance,
            JsonResponse.Create<CreateUploadDestinationResponse>(),
            CreateUploadDestinationForResourceErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);
}
