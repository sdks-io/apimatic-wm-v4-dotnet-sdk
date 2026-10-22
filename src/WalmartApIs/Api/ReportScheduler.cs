using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Exceptions;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Request;
using WalmartApIs.Core.Response;
using WalmartApIs.Models;
using WalmartApIs.Requests.ReportScheduler;

namespace WalmartApIs.Api;

public sealed class ReportScheduler
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal ReportScheduler(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Delete Report Schedule
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="RejectRecommendationsResponsePayload"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This API allows you to remove an existing report schedule.
    /// <para>
    /// &lt;strong style="color: green;"&gt;Market availability: US only&lt;/strong&gt;
    /// </para>
    /// </remarks>
    public Task<RejectRecommendationsResponsePayload> DeleteReportSchedule(DeleteReportScheduleRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/reports/schedules/{scheduleId}"),
            [new TemplateParam("scheduleId", request.ScheduleId)],
            [],
            [
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SEC.ACCESS_TOKEN", request.WmSecAccessToken),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Delete,
            EmptyBody.Instance,
            JsonResponse.Create<RejectRecommendationsResponsePayload>(),
            RawErrorResponse.Instance,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get All Report Schedules
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="V3ReportsSchedulesResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// The Get All Report Schedules API retrieves a list of all existing report schedules. This helps you to easily view and manage all scheduled reports in one place.
    /// <para>
    /// &lt;strong style="color: green;"&gt;Market availability: US only&lt;/strong&gt;
    /// </para>
    /// </remarks>
    public Task<V3ReportsSchedulesResponse> GetAllReportSchedules(GetAllReportSchedulesRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/reports/schedules"),
            [],
            [new Param("reportType", request.ReportType)],
            [
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SEC.ACCESS_TOKEN", request.WmSecAccessToken),
            ],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<V3ReportsSchedulesResponse>(),
            RawErrorResponse.Instance,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get Single Report Schedules
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="V3ReportsSchedulesResponse1"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This API retrieves the details of a single report schedule based on the specified scheduleId.
    /// <para>
    /// &lt;strong style="color: green;"&gt;Market availability: US only&lt;/strong&gt;
    /// </para>
    /// </remarks>
    public Task<V3ReportsSchedulesResponse1> GetReportSchedule(GetReportScheduleRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/reports/schedules/{scheduleId}"),
            [new TemplateParam("scheduleId", request.ScheduleId)],
            [],
            [
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SEC.ACCESS_TOKEN", request.WmSecAccessToken),
            ],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<V3ReportsSchedulesResponse1>(),
            RawErrorResponse.Instance,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Update Report Schedule
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="V3ReportsSchedulesResponse1"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This API allows you to modify an existing report schedule. You can change the parameters to better suit your needs, ensuring that reports are generated and delivered according to the most current requirements.
    /// <para>
    /// &lt;strong style="color: green;"&gt;Market availability: US only&lt;/strong&gt;
    /// </para>
    /// </remarks>
    public Task<V3ReportsSchedulesResponse1> UpdateReportSchedule(UpdateReportScheduleRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/reports/schedules/{scheduleId}"),
            [new TemplateParam("scheduleId", request.ScheduleId)],
            [],
            [
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SEC.ACCESS_TOKEN", request.WmSecAccessToken),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Put,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<V3ReportsSchedulesResponse1>(),
            RawErrorResponse.Instance,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);
}
