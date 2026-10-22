<!-- Generated file — do not edit; regenerated with the SDK. -->

# TaxFormApIs — operations

Accessor: `client.TaxFormApIs` · Source: `src/WalmartApIs/Api/TaxFormApIs.cs` · 2 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### DownloadTaxForm

- **Auth**: `options.AccessToken`
- **Signature**: `DownloadTaxForm(DownloadTaxFormRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `PayoutYear`, `TaxFormType`, `FormId`, `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `WmGlobalVersion`, `WmMarket`, `WmPartnerId`, `WmTenantId`
- **Query params (wire ← C#)**: `payoutYear` ← `PayoutYear`, `taxFormType` ← `TaxFormType`, `formId` ← `FormId`
- **Returns**: `void` (Task)
- **Error**: `ApiException<DownloadTaxFormError>` — **Case A (typed)**
- **Error accessors**: `TryGetV1SettingsDownloadtaxformprofile400Error1(out V1SettingsDownloadtaxformprofile400Error1)` [400] · `TryGetV1SettingsDownloadtaxformprofile404Error1(out V1SettingsDownloadtaxformprofile404Error1)` [404] · `TryGetV1SettingsDownloadtaxformprofile500Error1(out V1SettingsDownloadtaxformprofile500Error1)` [500] · `TryGetV1SettingsDownloadtaxformprofile502Error1(out V1SettingsDownloadtaxformprofile502Error1)` [502] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `DownloadTaxFormRequest` | `src/WalmartApIs/Requests/TaxFormApIs/DownloadTaxFormRequest.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `DownloadTaxFormError` | `src/WalmartApIs/Errors/DownloadTaxFormError.cs` |
| `V1SettingsDownloadtaxformprofile400Error1` | `src/WalmartApIs/Models/V1SettingsDownloadtaxformprofile400Error1.cs` |
| `V1SettingsDownloadtaxformprofile404Error1` | `src/WalmartApIs/Models/V1SettingsDownloadtaxformprofile404Error1.cs` |
| `V1SettingsDownloadtaxformprofile500Error1` | `src/WalmartApIs/Models/V1SettingsDownloadtaxformprofile500Error1.cs` |
| `V1SettingsDownloadtaxformprofile502Error1` | `src/WalmartApIs/Models/V1SettingsDownloadtaxformprofile502Error1.cs` |

### GetTaxForms

- **Auth**: `options.AccessToken`
- **Signature**: `GetTaxForms(GetTaxFormsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `WmGlobalVersion`, `WmMarket`, `WmPartnerId`, `WmTenantId`
- **Returns**: `V1SettingsGettaxformprofileResponse`
- **Error**: `ApiException<GetTaxFormsError>` — **Case A (typed)**
- **Error accessors**: `TryGetV1SettingsGettaxformprofile400Error1(out V1SettingsGettaxformprofile400Error1)` [400] · `TryGetV1SettingsGettaxformprofile404Error1(out V1SettingsGettaxformprofile404Error1)` [404] · `TryGetV1SettingsGettaxformprofile500Error1(out V1SettingsGettaxformprofile500Error1)` [500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetTaxFormsRequest` | `src/WalmartApIs/Requests/TaxFormApIs/GetTaxFormsRequest.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `V1SettingsGettaxformprofileResponse` | `src/WalmartApIs/Models/V1SettingsGettaxformprofileResponse.cs` |
| `GetTaxFormsError` | `src/WalmartApIs/Errors/GetTaxFormsError.cs` |
| `V1SettingsGettaxformprofile400Error1` | `src/WalmartApIs/Models/V1SettingsGettaxformprofile400Error1.cs` |
| `V1SettingsGettaxformprofile404Error1` | `src/WalmartApIs/Models/V1SettingsGettaxformprofile404Error1.cs` |
| `V1SettingsGettaxformprofile500Error1` | `src/WalmartApIs/Models/V1SettingsGettaxformprofile500Error1.cs` |

