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
using WalmartApIs.Requests.ReportSchedules;

namespace WalmartApIs.Api;

public sealed class ReportSchedules
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal ReportSchedules(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Cancels the report schedule that you specify
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CancelReportScheduleResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CancelReportScheduleError"/> when the server returns an error response.</exception>
    public Task<CancelReportScheduleResponse> CancelReportSchedule(CancelReportScheduleRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/reports/v4/schedules/{reportScheduleId}"),
            [new TemplateParam("reportScheduleId", request.ReportScheduleId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Delete,
            EmptyBody.Instance,
            JsonResponse.Create<CancelReportScheduleResponse>(),
            CancelReportScheduleError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Creates a report schedule
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CreateReportScheduleResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateReportScheduleError"/> when the server returns an error response.</exception>
    public Task<CreateReportScheduleResponse> CreateReportSchedule(CreateReportScheduleRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/reports/v4/schedules"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<CreateReportScheduleResponse>(),
            CreateReportScheduleError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Returns report schedule details for the given schedule ID
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ReportSchedule"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetReportScheduleError"/> when the server returns an error response.</exception>
    public Task<ReportSchedule> GetReportSchedule(GetReportScheduleRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/reports/v4/schedules/{reportScheduleId}"),
            [new TemplateParam("reportScheduleId", request.ReportScheduleId)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ReportSchedule>(),
            GetReportScheduleError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Returns report schedule details that match the filters
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetReportSchedulesResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetReportSchedulesError"/> when the server returns an error response.</exception>
    public Task<GetReportSchedulesResponse> GetReportSchedules(GetReportSchedulesRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/reports/v4/schedules"),
            [],
            [new Param("reportTypes", request.ReportTypes)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<GetReportSchedulesResponse>(),
            GetReportSchedulesError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);
}
