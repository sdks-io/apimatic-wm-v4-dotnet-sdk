using System;
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
using WalmartApIs.Requests.Reports;

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
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CancelReportResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CancelReportError"/> when the server returns an error response.</exception>
    public Task<CancelReportResponse> CancelReport(CancelReportRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/reports/v4/reports/{reportId}"),
            [new TemplateParam("reportId", request.ReportId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Delete,
            EmptyBody.Instance,
            JsonResponse.Create<CancelReportResponse>(),
            CancelReportError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Creates a report
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CreateReportResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateReportError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Submits a report request. Poll <c>GET /reports/{reportId}</c> for status.
    /// Report type taxonomy TBD — coordinate with Pod 5 for financial reports.
    /// </remarks>
    public Task<CreateReportResponse> CreateReport(CreateReportRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/reports/v4/reports"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<CreateReportResponse>(),
            CreateReportError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Download current-format settlement summary report (Swift v1)
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="BinaryContent"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="DownloadNewReportError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Downloads the current-format settlement summary report ZIP.
    /// Delegates to mp-payment-reporting GET /v3/report/reconreport/v1/reconFile (Swift v1 storage).
    /// </remarks>
    public Task<BinaryContent> DownloadNewReport(DownloadNewReportRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/disbursements/v4/payment/summary/newReportDownload"),
            [],
            [new Param("partnerId", request.PartnerId), new Param("reportDate", request.ReportDate)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            BinaryResponse.Instance,
            DownloadNewReportError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Download legacy-format settlement summary report
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="BinaryContent"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="DownloadOldReportError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Downloads the legacy-format settlement summary report ZIP.
    /// Delegates to mp-payment-reporting GET /v3/report/reconreport/reconFile (legacy Swift storage).
    /// </remarks>
    public Task<BinaryContent> DownloadOldReport(DownloadOldReportRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/disbursements/v4/payment/summary/oldReportDownload"),
            [],
            [new Param("partnerId", request.PartnerId), new Param("reportDate", request.ReportDate)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            BinaryResponse.Instance,
            DownloadOldReportError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Returns report details (including processing status) for the report
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="Report"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetReportError"/> when the server returns an error response.</exception>
    public Task<Report> GetReport(GetReportRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/reports/v4/reports/{reportId}"),
            [new TemplateParam("reportId", request.ReportId)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<Report>(),
            GetReportError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Returns the information required for retrieving a report document
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ReportDocument"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetReportDocumentError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a pre-signed URL for downloading the completed report.
    /// Do not log the pre-signed URL.
    /// </remarks>
    public Task<ReportDocument> GetReportDocument(GetReportDocumentRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/reports/v4/documents/{reportDocumentId}"),
            [new TemplateParam("reportDocumentId", request.ReportDocumentId)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ReportDocument>(),
            GetReportDocumentError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Returns report details for reports that match the filters
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetReportsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetReportsError"/> when the server returns an error response.</exception>
    public Task<GetReportsResponse> GetReports(GetReportsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/reports/v4/reports"),
            [],
            [
                new Param("reportTypes", request.ReportTypes),
                new Param("processingStatuses", request.ProcessingStatuses),
                new Param("createdSince", request.CreatedSince?.ToIso8601()),
                new Param("createdUntil", request.CreatedUntil?.ToIso8601()),
                new Param("pageSize", request.PageSize),
                new Param("nextToken", request.NextToken),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<GetReportsResponse>(),
            GetReportsError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);
}
