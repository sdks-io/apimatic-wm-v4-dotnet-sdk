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
using WalmartApIs.Requests.TaxFormApIs;

namespace WalmartApIs.Api;

public sealed class TaxFormApIs
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal TaxFormApIs(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Download Tax Form
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="DownloadTaxFormError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// The Download Tax Form API downloads the selected tax form document as a byte stream.
    /// <para>
    /// &lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </remarks>
    public Task DownloadTaxForm(DownloadTaxFormRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v1/settings/downloadtaxformprofile"),
            [],
            [
                new Param("payoutYear", request.PayoutYear),
                new Param("taxFormType", request.TaxFormType),
                new Param("formId", request.FormId),
            ],
            [
                new HeaderParam("WM_SEC.ACCESS_TOKEN", request.WmSecAccessToken),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("WM_PARTNER_ID", request.WmPartnerId),
                new HeaderParam("WM.TENANT_ID", request.WmTenantId),
            ],
            HttpMethod.Get,
            EmptyBody.Instance,
            VoidResponse.Instance,
            DownloadTaxFormError.Response,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get Tax Forms
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="V1SettingsGettaxformprofileResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetTaxFormsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// The Get Tax Forms API returns available tax forms for the authenticated seller, including form type and form ID. The response is a JSON object containing tax form metadata.
    /// <para>
    /// &lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </remarks>
    public Task<V1SettingsGettaxformprofileResponse> GetTaxForms(GetTaxFormsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v1/settings/gettaxformprofile"),
            [],
            [],
            [
                new HeaderParam("WM_SEC.ACCESS_TOKEN", request.WmSecAccessToken),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("WM_PARTNER_ID", request.WmPartnerId),
                new HeaderParam("WM.TENANT_ID", request.WmTenantId),
            ],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<V1SettingsGettaxformprofileResponse>(),
            GetTaxFormsError.Response,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);
}
