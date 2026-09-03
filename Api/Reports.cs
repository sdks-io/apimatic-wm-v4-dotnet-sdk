using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core;
using WalmartApIs.Core.Exceptions;
using WalmartApIs.Core.Extensions;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Request;
using WalmartApIs.Core.Response;
using WalmartApIs.Errors;
using WalmartApIs.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Api;

/// <summary>
/// Settlement summary report download (new and legacy formats).
/// </summary>
public sealed class Reports
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Reports(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Cancels the report that you specify (only IN_QUEUE or IN_PROGRESS)
    /// </summary>
    /// <param name="reportId"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CancelReportResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="CancelReportError"/> when the server returns an error response.</exception>
    public Task<CancelReportResponse> CancelReport(string reportId,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/reports/v4/reports/{reportId}"),
            [new TemplateParam("reportId", reportId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Delete,
            EmptyBody.Instance,
            JsonResponse.Create<CancelReportResponse>(),
            CancelReportErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Creates a report
    /// </summary>
    /// <param name="body"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CreateReportResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="CreateReportError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Submits a report request. Poll <c>GET /reports/{reportId}</c> for status.
    /// Report type taxonomy TBD — coordinate with Pod 5 for financial reports.
    /// </remarks>
    public Task<CreateReportResponse> CreateReport(CreateReportSpecification body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/reports/v4/reports"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<CreateReportResponse>(),
            CreateReportErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Download current-format settlement summary report (Swift v1)
    /// </summary>
    /// <param name="partnerId">Numeric partner/seller ID</param>
    /// <param name="reportDate">Report date in MMddyyyy format (e.g. 06172026)</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="BinaryContent"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="DownloadNewReportError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Downloads the current-format settlement summary report ZIP.
    /// Delegates to mp-payment-reporting GET /v3/report/reconreport/v1/reconFile (Swift v1 storage).
    /// </remarks>
    public Task<BinaryContent> DownloadNewReport(string partnerId,
        string reportDate,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/disbursements/v4/payment/summary/newReportDownload"),
            [],
            [new Param("partnerId", partnerId), new Param("reportDate", reportDate)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            BinaryResponse.Instance,
            DownloadNewReportErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Download legacy-format settlement summary report
    /// </summary>
    /// <param name="partnerId">Numeric partner/seller ID</param>
    /// <param name="reportDate">Report date in MMddyyyy format (e.g. 06172026)</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="BinaryContent"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="DownloadOldReportError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Downloads the legacy-format settlement summary report ZIP.
    /// Delegates to mp-payment-reporting GET /v3/report/reconreport/reconFile (legacy Swift storage).
    /// </remarks>
    public Task<BinaryContent> DownloadOldReport(string partnerId,
        string reportDate,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/disbursements/v4/payment/summary/oldReportDownload"),
            [],
            [new Param("partnerId", partnerId), new Param("reportDate", reportDate)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            BinaryResponse.Instance,
            DownloadOldReportErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Returns report details (including processing status) for the report
    /// </summary>
    /// <param name="reportId"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="Report"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetReportError"/> when the server returns an error response.</exception>
    public Task<Report> GetReport(string reportId,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/reports/v4/reports/{reportId}"),
            [new TemplateParam("reportId", reportId)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<Report>(),
            GetReportErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Returns the information required for retrieving a report document
    /// </summary>
    /// <param name="reportDocumentId"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ReportDocument"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetReportDocumentError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a pre-signed URL for downloading the completed report.
    /// Do not log the pre-signed URL.
    /// </remarks>
    public Task<ReportDocument> GetReportDocument(string reportDocumentId,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/reports/v4/documents/{reportDocumentId}"),
            [new TemplateParam("reportDocumentId", reportDocumentId)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ReportDocument>(),
            GetReportDocumentErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Returns report details for reports that match the filters
    /// </summary>
    /// <param name="reportTypes">Filter by report type. Values are Walmart Partner Reporting Platform enum names. Runtime availability is CCM-controlled; consult PRP docs for current PROD-enabled types.</param>
    /// <param name="processingStatuses"></param>
    /// <param name="createdSince"></param>
    /// <param name="createdUntil"></param>
    /// <param name="nextToken"></param>
    /// <param name="pageSize"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetReportsResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetReportsError"/> when the server returns an error response.</exception>
    public Task<GetReportsResponse> GetReports(IReadOnlyList<ReportType1>? reportTypes,
        IReadOnlyList<ProcessingStatus>? processingStatuses,
        DateTimeOffset? createdSince,
        DateTimeOffset? createdUntil,
        string? nextToken,
        int? pageSize = 10,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/reports/v4/reports"),
            [],
            [new Param("reportTypes", reportTypes),
                new Param("processingStatuses", processingStatuses),
                new Param("createdSince", createdSince?.ToIso8601()),
                new Param("createdUntil", createdUntil?.ToIso8601()),
                new Param("pageSize", pageSize),
                new Param("nextToken", nextToken)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<GetReportsResponse>(),
            GetReportsErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);
}
