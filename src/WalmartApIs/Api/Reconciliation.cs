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
using WalmartApIs.Requests.Reconciliation;

namespace WalmartApIs.Api;

/// <summary>
/// Reconciliation report availability and download.
/// </summary>
public sealed class Reconciliation
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Reconciliation(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Check if a report is available for a given period
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ReportAvailabilityResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CheckDownloadReportByPeriodError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Checks which reconciliation report versions (legacy, v1/WFS) are available
    /// for a given partner and date. Delegates to mp-payment-reporting
    /// GET /v3/report/reconreport/reconReportAvailability.
    /// Note: the upstream date param is named <c>date</c> (not <c>reportDate</c>).
    /// </remarks>
    public Task<ReportAvailabilityResponse> CheckDownloadReportByPeriod(CheckDownloadReportByPeriodRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/disbursements/v4/payment/checkDownloadReportByPeriod"),
            [],
            [new Param("partnerId", request.PartnerId), new Param("date", request.Date.ToDate())],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ReportAvailabilityResponse>(),
            CheckDownloadReportByPeriodError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Download reconciliation report as ZIP
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="BinaryContent"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="DownloadReconciliationReportError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Downloads a reconciliation report ZIP for the given partner and date.
    /// Delegates to mp-payment-reporting GET /v1/mt/report/reconreport/reconFile (Azure MT storage).
    /// </remarks>
    public Task<BinaryContent> DownloadReconciliationReport(DownloadReconciliationReportRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/disbursements/v4/payment/reconciliation/download"),
            [],
            [new Param("partnerId", request.PartnerId), new Param("reportDate", request.ReportDate)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            BinaryResponse.Instance,
            DownloadReconciliationReportError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List available reconciliation report dates
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ReportAvailabilityResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListReconciliationDatesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the set of available reconciliation report dates for a partner.
    /// Delegates to mp-payment-reporting GET /v3/report/reconreport/availableReconFiles.
    /// </remarks>
    public Task<ReportAvailabilityResponse> ListReconciliationDates(ListReconciliationDatesRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/disbursements/v4/payment/reconciliation/dateList"),
            [],
            [new Param("partnerId", request.PartnerId)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ReportAvailabilityResponse>(),
            ListReconciliationDatesError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);
}
