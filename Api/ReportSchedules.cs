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
    /// <param name="reportScheduleId"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CancelReportScheduleResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="CancelReportScheduleError"/> when the server returns an error response.</exception>
    public Task<CancelReportScheduleResponse> CancelReportSchedule(string reportScheduleId,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/reports/v4/schedules/{reportScheduleId}"),
            [new TemplateParam("reportScheduleId", reportScheduleId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Delete,
            EmptyBody.Instance,
            JsonResponse.Create<CancelReportScheduleResponse>(),
            CancelReportScheduleErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Creates a report schedule
    /// </summary>
    /// <param name="body"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CreateReportScheduleResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="CreateReportScheduleError"/> when the server returns an error response.</exception>
    public Task<CreateReportScheduleResponse> CreateReportSchedule(CreateReportScheduleSpecification body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/reports/v4/schedules"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<CreateReportScheduleResponse>(),
            CreateReportScheduleErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Returns report schedule details for the given schedule ID
    /// </summary>
    /// <param name="reportScheduleId"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ReportSchedule"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetReportScheduleError"/> when the server returns an error response.</exception>
    public Task<ReportSchedule> GetReportSchedule(string reportScheduleId,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/reports/v4/schedules/{reportScheduleId}"),
            [new TemplateParam("reportScheduleId", reportScheduleId)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ReportSchedule>(),
            GetReportScheduleErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Returns report schedule details that match the filters
    /// </summary>
    /// <param name="reportTypes">Filter by report type. Values are Walmart Partner Reporting Platform enum names. Runtime availability is CCM-controlled; consult PRP docs for current PROD-enabled types.</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetReportSchedulesResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetReportSchedulesError"/> when the server returns an error response.</exception>
    public Task<GetReportSchedulesResponse> GetReportSchedules(IReadOnlyList<ReportType1>? reportTypes,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/reports/v4/schedules"),
            [],
            [new Param("reportTypes", reportTypes)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<GetReportSchedulesResponse>(),
            GetReportSchedulesErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);
}
