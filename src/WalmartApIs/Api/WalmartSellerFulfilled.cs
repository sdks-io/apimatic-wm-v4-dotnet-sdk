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
using WalmartApIs.Requests.WalmartSellerFulfilled;

namespace WalmartApIs.Api;

public sealed class WalmartSellerFulfilled
{
    private readonly RawClient _rawClient;
    private readonly Server _server;

    internal WalmartSellerFulfilled(RawClient rawClient, Server server)
    {
        _rawClient = rawClient;
        _server = server;
    }

    /// <summary>
    /// Bulk Item Enrollment for Walmart+
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="V3FeedsFeedTypeProgramActionsRequestTypeWalmartPlusSffResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="WalmartPlusEnrollmentError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This API endpoint allows you to efficiently manage item participation in the Walmart+ program. Use it to enroll eligible items in Walmart+ or to unenroll items that are currently part of the program.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/b&gt;
    /// <para>
    ///
    /// </para>
    /// <para>
    /// &lt;b&gt;Download and review the &lt;a href="/file/mp/us/PROGRAM_ACTIONS_5.0.20250617-00_03_34_US_WalmartPlusEnrollment.xlsx"&gt;Excel template sample &lt;/a&gt; and the &lt;a href="/file/mp/us/bulk-enroll-requestBody-template.json"&gt;JSON body sample&lt;/a&gt; to ensure proper formatting of the updated file before uploading it for processing.&lt;/b&gt;
    /// </para>
    /// </remarks>
    public Task<V3FeedsFeedTypeProgramActionsRequestTypeWalmartPlusSffResponse> WalmartPlusEnrollment(WalmartPlusEnrollmentRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/feeds?feedType=PROGRAM_ACTIONS&requestType=WALMART_PLUS_SFF"),
            [],
            [new Param("feedType", request.FeedType), new Param("requestType", request.RequestType)],
            [
                new HeaderParam("WM_SEC.ACCESS_TOKEN", request.WmSecAccessToken),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Post,
            FormRequest.Create(new MultipartParam("fileName", request.FileName)),
            JsonResponse.Create<V3FeedsFeedTypeProgramActionsRequestTypeWalmartPlusSffResponse>(),
            WalmartPlusEnrollmentError.Response,
            [],
            requestOptions,
            cancellationToken);
}
