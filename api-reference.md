# Reference

Every operation below is shown in its throwing form. On an error status it throws `ApiException<TError>` — the status code, headers, content type and the operation's error type, `RawError` (the raw body) when the spec declares none — and where an operation offers an `…AsResult` sibling, that sibling returns `ApiResult<TResponse, TError>` instead. A request that produces no usable response surfaces as `SdkConnectionException` or `SdkTimeoutException`, a body that does not match the documented response type as `ResponseDeserializationException`, and a credential that cannot be applied as `AuthSchemeException`; all of them derive from `SdkException` and name the failed call. See [README → Error Handling](README.md#error-handling).

> Source: [WalmartApIsClient](src/WalmartApIs/WalmartApIsClient.cs)

## AssortmentRecommendations

> Source: [AssortmentRecommendations](src/WalmartApIs/Api/AssortmentRecommendations.cs)

<details>
<summary><code>Task&lt;V3GrowthAssortmentRecommendationsTrendsResponse&gt; GetAssortmentRecommendationTrends(GetAssortmentRecommendationTrendsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

You can fetch the monthly and weekly trends for both demand and price, for the assortment recommendations that are recommended for you. <br><b style='color:green;'>Market availability: US only</span></b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.AssortmentRecommendations.GetAssortmentRecommendationTrends(
        new GetAssortmentRecommendationTrendsRequest
        {
            RecommendationUniqueId = "some example string",
            TrendTypes = "PRICE_TRENDS,DEMAND_TRENDS",
            WmGlobalVersion = WmGlobalVersion._31,
            WmSecAccessToken = "eyJraWQiOiIzZjVhYTFmNS1hYWE5LTQzM.....",
            WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
            WmSvcName = "Walmart Service Name",
            WmMarket = WmMarket1.Us,
        });
    // TODO: Handle 'response' of type V3GrowthAssortmentRecommendationsTrendsResponse
}
catch (ApiException<GetAssortmentRecommendationTrendsError> ex)
{
    if (ex.Error.TryGetErrorResponse1(out var error))
    {
        // TODO: Handle 'error' of type ErrorResponse1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetAssortmentRecommendationTrendsRequest](src/WalmartApIs/Requests/AssortmentRecommendations/GetAssortmentRecommendationTrendsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3GrowthAssortmentRecommendationsTrendsResponse](src/WalmartApIs/Models/V3GrowthAssortmentRecommendationsTrendsResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetAssortmentRecommendationTrendsError](src/WalmartApIs/Errors/GetAssortmentRecommendationTrendsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;V3GrowthAssortmentRecommendationsVariantsResponse&gt; GetAssortmentRecommendationVariants(GetAssortmentRecommendationVariantsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

You can fetch variant items corresponding to a recommended primary variant item. <br><b style='color:green;'>Market availability: US only</span></b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.AssortmentRecommendations.GetAssortmentRecommendationVariants(
        new GetAssortmentRecommendationVariantsRequest
        {
            PrimaryVariantItemId = "some example string",
            NextCursor = "*",
            WmGlobalVersion = WmGlobalVersion._31,
            WmSecAccessToken = "eyJraWQiOiIzZjVhYTFmNS1hYWE5LTQzM.....",
            WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
            WmSvcName = "Walmart Service Name",
            WmMarket = WmMarket1.Us,
        });
    // TODO: Handle 'response' of type V3GrowthAssortmentRecommendationsVariantsResponse
}
catch (ApiException<GetAssortmentRecommendationVariantsError> ex)
{
    if (ex.Error.TryGetErrorResponse1(out var error))
    {
        // TODO: Handle 'error' of type ErrorResponse1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetAssortmentRecommendationVariantsRequest](src/WalmartApIs/Requests/AssortmentRecommendations/GetAssortmentRecommendationVariantsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3GrowthAssortmentRecommendationsVariantsResponse](src/WalmartApIs/Models/V3GrowthAssortmentRecommendationsVariantsResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetAssortmentRecommendationVariantsError](src/WalmartApIs/Errors/GetAssortmentRecommendationVariantsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;V3GrowthAssortmentRecommendationsResponse&gt; GetAssortmentRecommendations(GetAssortmentRecommendationsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

You can fetch the list of recommendations that are recommended for you. 

Using ITEM as a recommendationType,
*   You can get the list of ITEM recommendations. You can apply filters to fetch selective item recommendations. <br><b style='color:green;'>Market availability: US | CA | MX</span></b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.AssortmentRecommendations.GetAssortmentRecommendations(
        new GetAssortmentRecommendationsRequest
        {
            WmGlobalVersion = WmGlobalVersion._31,
            WmSecAccessToken = "eyJraWQiOiIzZjVhYTFmNS1hYWE5LTQzM.....",
            WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
            WmSvcName = "Walmart Service Name",
            WmMarket = WmMarket1.Us,
            Body = new V3GrowthAssortmentRecommendationsRequest { Meta = new Meta6 { Limit = 2 } },
        });
    // TODO: Handle 'response' of type V3GrowthAssortmentRecommendationsResponse
}
catch (ApiException<GetAssortmentRecommendationsError> ex)
{
    if (ex.Error.TryGetErrorResponse1(out var error))
    {
        // TODO: Handle 'error' of type ErrorResponse1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetAssortmentRecommendationsRequest](src/WalmartApIs/Requests/AssortmentRecommendations/GetAssortmentRecommendationsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3GrowthAssortmentRecommendationsResponse](src/WalmartApIs/Models/V3GrowthAssortmentRecommendationsResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetAssortmentRecommendationsError](src/WalmartApIs/Errors/GetAssortmentRecommendationsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;V3GrowthAssortmentRecommendationsCategorizationCountsResponse&gt; GetCategorizationDetailsOfAssortmentRecommendations(GetCategorizationDetailsOfAssortmentRecommendationsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

You can get the list of brands or categories associated with the items recommendations that are recommended for you.

Using BRAND as a categorizationType
*   You can get the list of brands sorted by the number of item recommendations associated with it. This is then sorted in lexicographic order of brand name. 

Using CATEGORY as a categorizationType
*   You can get the list of categories sorted by the number of item recommendations associated with it. This is then sorted in lexicographic order of category name. 
<br><b style='color:green;'>Market availability: US | CA | MX</span></b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.AssortmentRecommendations.GetCategorizationDetailsOfAssortmentRecommendations(
        new GetCategorizationDetailsOfAssortmentRecommendationsRequest
        {
            WmSecAccessToken = "eyJraWQiOiIzZjVhYTFmNS1hYWE5LTQzM.....",
            WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
            WmSvcName = "Walmart Service Name",
            WmMarket = WmMarket1.Us,
            WmGlobalVersion = WmGlobalVersion._31,
            Body = new V3GrowthAssortmentRecommendationsCategorizationCountsRequest
            {
                CategorizationType = CategorizationType3.Brand,
                Meta = new Meta10 { Limit = 2 },
            },
        });
    // TODO: Handle 'response' of type V3GrowthAssortmentRecommendationsCategorizationCountsResponse
}
catch (ApiException<GetCategorizationDetailsOfAssortmentRecommendationsError> ex)
{
    if (ex.Error.TryGetErrorResponse1(out var error))
    {
        // TODO: Handle 'error' of type ErrorResponse1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetCategorizationDetailsOfAssortmentRecommendationsRequest](src/WalmartApIs/Requests/AssortmentRecommendations/GetCategorizationDetailsOfAssortmentRecommendationsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3GrowthAssortmentRecommendationsCategorizationCountsResponse](src/WalmartApIs/Models/V3GrowthAssortmentRecommendationsCategorizationCountsResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetCategorizationDetailsOfAssortmentRecommendationsError](src/WalmartApIs/Errors/GetCategorizationDetailsOfAssortmentRecommendationsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;V3GrowthAssortmentRecommendationsRejectionsResponse&gt; RejectAssortmentRecommendations(RejectAssortmentRecommendationsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

You can reject a list of recommendations that are recommended for you. 

Using ITEM as a recommendationType,
*   You can reject specific item recommendations using the filterCriteria or by providing the list of itemRecommendationUniqueIds. 
*   You will need to provide valid rejection code(s) while submitting the reject request. You are required to send the custom rejection message if the rejection code is OTHER_REASON
<br><b style='color:green;'>Market availability: US | CA | MX</span></b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.AssortmentRecommendations.RejectAssortmentRecommendations(
        new RejectAssortmentRecommendationsRequest
        {
            WmGlobalVersion = WmGlobalVersion._31,
            WmSecAccessToken = "eyJraWQiOiIzZjVhYTFmNS1hYWE5LTQzM.....",
            WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
            WmSvcName = "Walmart Service Name",
            WmMarket = WmMarket1.Us,
            Body = new V3GrowthAssortmentRecommendationsRejectionsRequest
            {
                RejectionCodes = RejectionCodes1.NotSellingTheseItems,
            },
        });
    // TODO: Handle 'response' of type V3GrowthAssortmentRecommendationsRejectionsResponse
}
catch (ApiException<RejectAssortmentRecommendationsError> ex)
{
    if (ex.Error.TryGetErrorResponse1(out var error))
    {
        // TODO: Handle 'error' of type ErrorResponse1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[RejectAssortmentRecommendationsRequest](src/WalmartApIs/Requests/AssortmentRecommendations/RejectAssortmentRecommendationsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3GrowthAssortmentRecommendationsRejectionsResponse](src/WalmartApIs/Models/V3GrowthAssortmentRecommendationsRejectionsResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[RejectAssortmentRecommendationsError](src/WalmartApIs/Errors/RejectAssortmentRecommendationsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Authorization

> Source: [Authorization](src/WalmartApIs/Api/Authorization.cs)

<details>
<summary><code>Task&lt;TokenDetailResponse&gt; GetTokenDetail(GetTokenDetailRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This process retrieves the access permissions granted by sellers to applications in the context of OAuth 2.0. The scope encompasses various API categories, each with its respective access levels, for example Reports: View Only, Item: Full Access, etc.
<br><b style='color:green;'>Market availability: Global</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Authorization.GetTokenDetail(new GetTokenDetailRequest
    {
        WmSecAccessToken = "eyJraWQiOiIzZjVhYTFmNS1hYWE5LTQzM.....",
        WmMarket = "us, mx, ca or cl",
        ContentType = "application/x-www-form-urlencoded",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
    });
    // TODO: Handle 'response' of type TokenDetailResponse
}
catch (ApiException<RawError> ex)
{
    // TODO: Handle 'ex.Error' of type RawError
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetTokenDetailRequest](src/WalmartApIs/Requests/Authorization/GetTokenDetailRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[TokenDetailResponse](src/WalmartApIs/Models/TokenDetailResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[RawError](src/WalmartApIs/Core/ErrorResponse/RawError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;OAuthTokenModel&gt; TokenApi(TokenApiRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

<p>This endpoint issues access tokens required for authenticating API requests. It supports multiple OAuth 2.0 grant types to accommodate various integration scenarios.</p> <b style='color:green;'>Market availability: Global</b><br/><h3>Supported Grant Types</h3><table><tr><th>Grant Type</th><th>Description</th><th>How to get the credentials</th></tr><tr><td>authorization_code</td><td>Exchanges an authorization code for an access token.</td><td>Used in app integration only via the OAuth consent screen. This is applicable to the <strong>US market only</strong>. Refer to <a href=/global-marketplace/docs/oauth-20-authorization>OAuth 2.0 authorization</a> for more details.</td></tr><tr><td>client_credentials</td><td>Issues a token using client ID and secret.</td><td>For <strong>sellers</strong>: Obtain client_id and client_secret from the <strong>Developer Portal</strong>.<br/>For <strong>solution providers</strong>: Obtain credentials from sellers via <a href=/global-marketplace/docs/delegated-access-auth>Delegated Access authorization</a>.</td></tr><tr><td>refresh_token</td><td>Issues a new access token using a refresh token.</td><td>Provided during the authorization_code flow. This is applicable to the <strong>US market only</strong>. Refer to <a href=/global-marketplace/docs/oauth-20-authorization>OAuth 2.0 authorization</a> for more details.</td></tr></table><br/><b>Note:<br/></b> Use authorization_code and refresh_token <b>only for app-based integrations.</b> These grant types are currently <b>supported only in the US market</b>.<br/><br/><h3>Token Lifetimes</h3><table><tr><th>Token Type</th><th>Duration</th></tr><tr><td>Access Token</td><td>15 minutes <i>(900 seconds)</i></td></tr><tr><td>Refresh Token</td><td>1 year <i>(365 days)</i></td></tr></table>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Authorization.TokenApi(new TokenApiRequest
    {
        WmMarket = "us, mx, ca or cl",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        WmPartnerId = "43423324",
        GrantType = GrantType1.ClientCredentials,
        Code = "65CA5DA313A549D49D15D3119D9AD85D",
        RedirectUri = "https://example-client-app.com",
        RefreshToken = "APXcIoTpKMH9OQN.....",
    });
    // TODO: Handle 'response' of type OAuthTokenModel
}
catch (ApiException<TokenApiError> ex)
{
    if (ex.Error.TryGetV3Token400Error1(out var error))
    {
        // TODO: Handle 'error' of type V3Token400Error1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[TokenApiRequest](src/WalmartApIs/Requests/Authorization/TokenApiRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[OAuthTokenModel](src/WalmartApIs/Models/OAuthTokenModel.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[TokenApiError](src/WalmartApIs/Errors/TokenApiError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Disputes

> Source: [Disputes](src/WalmartApIs/Api/Disputes.cs)

<details>
<summary><code>Task&lt;DisputeContestResponses&gt; PostContest(PostContestRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Use this API to submit dispute for up to 100 items at a time.

We need to pass `productId`, and `productIdType` in the body for creating a dispute. 

*   POST {{url}}/v3/items/dispute/duplicates/contest 
<br><b style='color:green;'>Market availability: US only</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Disputes.PostContest(new PostContestRequest
    {
        WmSecAccessToken = "eyJraWQiOiIzZjVhYTFmNS1hYWE5LTQzM.....",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        WmMarket = WmMarket1.Us,
        WmGlobalVersion = WmGlobalVersion._31,
        Body = new V3ItemsDisputeDuplicatesContestRequest { Issues = [new Issues1()] },
    });
    // TODO: Handle 'response' of type DisputeContestResponses
}
catch (ApiException<PostContestError> ex)
{
    if (ex.Error.TryGetV3ItemsDisputeDuplicatesContest403Error1(out var error))
    {
        // TODO: Handle 'error' of type V3ItemsDisputeDuplicatesContest403Error1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[PostContestRequest](src/WalmartApIs/Requests/Disputes/PostContestRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[DisputeContestResponses](src/WalmartApIs/Models/DisputeContestResponses.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[PostContestError](src/WalmartApIs/Errors/PostContestError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;V3ItemsDisputeDuplicatesStatusResponse&gt; PostStatus(PostStatusRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Use this API to retrieve the status of up to 100 disputed items at a time.

We need to pass `productId`, and `productIdType` in the body for creating a dispute. 

*   POST {{url}}/v3/items/dispute/duplicates/status 

Responses will be based on the item status: 

* 404: No item Response 

* 200: Response received for all items 

* 206: Partial response received 

An Item can be in 4 different stages: 
* `IN_REVIEW`, `IS_DUPLICATE`, `ERROR`, `NOT_DUPLICATE` 
<br><b style='color:green;'>Market availability: US only</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Disputes.PostStatus(new PostStatusRequest
    {
        WmSecAccessToken = "eyJraWQiOiIzZjVhYTFmNS1hYWE5LTQzM.....",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        WmMarket = WmMarket1.Us,
        WmGlobalVersion = WmGlobalVersion._31,
        Body = new V3ItemsDisputeDuplicatesStatusRequest { Issues = [new Issues1()] },
    });
    // TODO: Handle 'response' of type V3ItemsDisputeDuplicatesStatusResponse
}
catch (ApiException<PostStatusError> ex)
{
    if (ex.Error.TryGetV3ItemsDisputeDuplicatesStatus403Error1(out var error))
    {
        // TODO: Handle 'error' of type V3ItemsDisputeDuplicatesStatus403Error1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[PostStatusRequest](src/WalmartApIs/Requests/Disputes/PostStatusRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3ItemsDisputeDuplicatesStatusResponse](src/WalmartApIs/Models/V3ItemsDisputeDuplicatesStatusResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[PostStatusError](src/WalmartApIs/Errors/PostStatusError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## FeedsApi

> Source: [FeedsApi](src/WalmartApIs/Api/FeedsApi.cs)

<details>
<summary><code>Task&lt;FeedRecordResponse&gt; GetAllFeedStatuses(GetAllFeedStatusesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This API returns the feed statuses for all the specified feed IDs. Use the specified feedTypes to query the status of each feed and identify whether it was processed successfully, failed, or is still in progress. 

 | FeedTypes | Availability |
|--------|----------|
| MP_MAINTENANCE, MP_ITEM_MATCH, LAGTIME | Global |
| MP_INVENTORY, SKU_TEMPLATE_MAP | US, CA, MX |
| MP_ITEM_INTL | CA, MX, CL |
| MP_ITEM, MP_WFS_ITEM, WALMART_FUNDED_INCENTIVES_ENROLLMENT, INCENTIVE_ENROLLMENT,PRICE_AND_PROMOTION | US Only |
| OMNI_WFS, RETIRE_ITEM, SHIPPING_OVERRIDES, FITMENT_ACES, FITMENT_PIES, SPLIT_AND_MERGE | US Only |
| OMNI_WFSSETUP, OMNI_WFSCONVERT | CA, MX | 

<br><b style='color:green;'>Market availability: Global</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.FeedsApi.GetAllFeedStatuses(new GetAllFeedStatusesRequest
    {
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        WmMarket = WmMarket1.Us,
        WmGlobalVersion = WmGlobalVersion._31,
    });
    // TODO: Handle 'response' of type FeedRecordResponse
}
catch (ApiException<GetAllFeedStatusesError> ex)
{
    if (ex.Error.TryGetFeedRecordResponse(out var error))
    {
        // TODO: Handle 'error' of type FeedRecordResponse
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetAllFeedStatusesRequest](src/WalmartApIs/Requests/FeedsApi/GetAllFeedStatusesRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[FeedRecordResponse](src/WalmartApIs/Models/FeedRecordResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetAllFeedStatusesError](src/WalmartApIs/Errors/GetAllFeedStatusesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;BinaryContent&gt; GetFeedErrorReport(GetFeedErrorReportRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Get Feed Error Report API allows you to download a detailed error report for a submitted feed. 

Currently the API supports error report download for the following feeds: 
*   FITMENT_ACES 
*   FITMENT_PIES 

 This API returns a zipped .csv file, which contains line item level detailed error messages. For details and a sample, please refer to the guide section link below. 
<br><b style='color:green;'>Market availability: US only</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.FeedsApi.GetFeedErrorReport(new GetFeedErrorReportRequest
    {
        FeedId = "some example string",
        FeedType = FeedType.FitmentAces,
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        WmMarket = WmMarket1.Us,
        WmGlobalVersion = WmGlobalVersion._31,
    });
    // TODO: Handle 'response' of type BinaryContent
}
catch (ApiException<RawError> ex)
{
    // TODO: Handle 'ex.Error' of type RawError
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetFeedErrorReportRequest](src/WalmartApIs/Requests/FeedsApi/GetFeedErrorReportRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>BinaryContent</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[RawError](src/WalmartApIs/Core/ErrorResponse/RawError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;V3FeedsResponse1&gt; GetFeedItemStatus(GetFeedItemStatusRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the feed and item status for a specified Feed ID.
<br><b style='color:green;'>Market availability: Global</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.FeedsApi.GetFeedItemStatus(new GetFeedItemStatusRequest
    {
        FeedId = "some example string",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        WmMarket = WmMarket1.Us,
        WmGlobalVersion = WmGlobalVersion._31,
    });
    // TODO: Handle 'response' of type V3FeedsResponse1
}
catch (ApiException<GetFeedItemStatusError> ex)
{
    if (ex.Error.TryGetV3Feeds404Error21(out var error))
    {
        // TODO: Handle 'error' of type V3Feeds404Error21
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetFeedItemStatusRequest](src/WalmartApIs/Requests/FeedsApi/GetFeedItemStatusRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3FeedsResponse1](src/WalmartApIs/Models/V3FeedsResponse1.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetFeedItemStatusError](src/WalmartApIs/Errors/GetFeedItemStatusError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## InsightApi

> Source: [InsightApi](src/WalmartApIs/Api/InsightApi.cs)

<details>
<summary><code>Task&lt;V3InsightsItemsListingQualityCountResponse&gt; GetCategoriesList(GetCategoriesListRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Get a list of all item categories that have items with listing quality issues or brands for a seller.<br><b style='color:green;'>Market availability: US only</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.InsightApi.GetCategoriesList(new GetCategoriesListRequest
    {
        WmGlobalVersion = WmGlobalVersion._31,
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        WmMarket = WmMarket1.Us,
    });
    // TODO: Handle 'response' of type V3InsightsItemsListingQualityCountResponse
}
catch (ApiException<GetCategoriesListError> ex)
{
    if (ex.Error.TryGetV3InsightsItemsListingQualityCount400Error1(out var error))
    {
        // TODO: Handle 'error' of type V3InsightsItemsListingQualityCount400Error1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetCategoriesListRequest](src/WalmartApIs/Requests/InsightApi/GetCategoriesListRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3InsightsItemsListingQualityCountResponse](src/WalmartApIs/Models/V3InsightsItemsListingQualityCountResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetCategoriesListError](src/WalmartApIs/Errors/GetCategoriesListError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;V3InsightsItemsListingQualityScoreResponse&gt; GetListingQualityScore(GetListingQualityScoreRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Get the total Listing Quality Score for a seller's entire item catalog.<br><b style='color:green;'>Market availability: US | CA | MX</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.InsightApi.GetListingQualityScore(new GetListingQualityScoreRequest
    {
        WmGlobalVersion = WmGlobalVersion._31,
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        WmMarket = WmMarket1.Us,
    });
    // TODO: Handle 'response' of type V3InsightsItemsListingQualityScoreResponse
}
catch (ApiException<GetListingQualityScoreError> ex)
{
    if (ex.Error.TryGetV3InsightsItemsListingQualityScore400Error1(out var error))
    {
        // TODO: Handle 'error' of type V3InsightsItemsListingQualityScore400Error1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetListingQualityScoreRequest](src/WalmartApIs/Requests/InsightApi/GetListingQualityScoreRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3InsightsItemsListingQualityScoreResponse](src/WalmartApIs/Models/V3InsightsItemsListingQualityScoreResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetListingQualityScoreError](src/WalmartApIs/Errors/GetListingQualityScoreError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;V3InsightsProsellerbadgeResponse&gt; GetProSellerBadgeInfo(GetProSellerBadgeInfoRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

The Pro Seller badge status will provide you with information regarding your current badge status as well as the progress you've made in meeting the criteria.<br><b style='color:green;'>Market availability: MX only</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.InsightApi.GetProSellerBadgeInfo(new GetProSellerBadgeInfoRequest
    {
        WmGlobalVersion = WmGlobalVersion._31,
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        WmMarket = WmMarket1.Us,
    });
    // TODO: Handle 'response' of type V3InsightsProsellerbadgeResponse
}
catch (ApiException<GetProSellerBadgeInfoError> ex)
{
    if (ex.Error.TryGetV3InsightsProsellerbadge400Error1(out var error))
    {
        // TODO: Handle 'error' of type V3InsightsProsellerbadge400Error1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetProSellerBadgeInfoRequest](src/WalmartApIs/Requests/InsightApi/GetProSellerBadgeInfoRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3InsightsProsellerbadgeResponse](src/WalmartApIs/Models/V3InsightsProsellerbadgeResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetProSellerBadgeInfoError](src/WalmartApIs/Errors/GetProSellerBadgeInfoError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;V3InsightsSellerIncentivesResponse&gt; GetSellerIncentivesInfo(GetSellerIncentivesInfoRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

The Pro Seller Tier and Rewards Status API allows you to check your seller’s current tier status within the Pro Seller program, a three-tier incentive structure consisting of Rising, Advanced, and Pro Seller levels in US and a single-tier i.e Pro Seller in CA.<br><b style='color:green;'>Market availability: US | CA</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.InsightApi.GetSellerIncentivesInfo(new GetSellerIncentivesInfoRequest
    {
        WmGlobalVersion = WmGlobalVersion._31,
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        WmMarket = WmMarket1.Us,
    });
    // TODO: Handle 'response' of type V3InsightsSellerIncentivesResponse
}
catch (ApiException<GetSellerIncentivesInfoError> ex)
{
    if (ex.Error.TryGetV3Token400Error1(out var error))
    {
        // TODO: Handle 'error' of type V3Token400Error1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetSellerIncentivesInfoRequest](src/WalmartApIs/Requests/InsightApi/GetSellerIncentivesInfoRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3InsightsSellerIncentivesResponse](src/WalmartApIs/Models/V3InsightsSellerIncentivesResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetSellerIncentivesInfoError](src/WalmartApIs/Errors/GetSellerIncentivesInfoError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;V3InsightsItemsUnpublishedCountsResponse&gt; GetUnpublishedItemCount(GetUnpublishedItemCountRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This API allows you to get the count of unpublished items.<br><b style='color:green;'>Market availability: US | CA | MX</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.InsightApi.GetUnpublishedItemCount(new GetUnpublishedItemCountRequest
    {
        FromDate = "2020-09-23",
        WmGlobalVersion = WmGlobalVersion._31,
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        WmMarket = WmMarket1.Us,
    });
    // TODO: Handle 'response' of type V3InsightsItemsUnpublishedCountsResponse
}
catch (ApiException<GetUnpublishedItemCountError> ex)
{
    if (ex.Error.TryGetV3Token400Error1(out var error))
    {
        // TODO: Handle 'error' of type V3Token400Error1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetUnpublishedItemCountRequest](src/WalmartApIs/Requests/InsightApi/GetUnpublishedItemCountRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3InsightsItemsUnpublishedCountsResponse](src/WalmartApIs/Models/V3InsightsItemsUnpublishedCountsResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetUnpublishedItemCountError](src/WalmartApIs/Errors/GetUnpublishedItemCountError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;V3InsightsItemsUnpublishedItemsResponse&gt; GetUnpublishedItems(GetUnpublishedItemsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Get Unpublished Items<br><b style='color:green;'>Market availability: US | CA | MX</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.InsightApi.GetUnpublishedItems(new GetUnpublishedItemsRequest
    {
        FromDate = "2020-09-23",
        WmGlobalVersion = WmGlobalVersion._31,
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        WmMarket = WmMarket1.Us,
    });
    // TODO: Handle 'response' of type V3InsightsItemsUnpublishedItemsResponse
}
catch (ApiException<GetUnpublishedItemsError> ex)
{
    if (ex.Error.TryGetV3Token400Error1(out var error))
    {
        // TODO: Handle 'error' of type V3Token400Error1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetUnpublishedItemsRequest](src/WalmartApIs/Requests/InsightApi/GetUnpublishedItemsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3InsightsItemsUnpublishedItemsResponse](src/WalmartApIs/Models/V3InsightsItemsUnpublishedItemsResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetUnpublishedItemsError](src/WalmartApIs/Errors/GetUnpublishedItemsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;V3InsightsItemsListingQualityItemsResponse&gt; ItemsDetailsForListing(ItemsDetailsForListingRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Get each item's listing quality details including: item quality score, offer score, content score and issues, and item performance.<br><b style='color:green;'>Market availability: US | CA | MX</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.InsightApi.ItemsDetailsForListing(new ItemsDetailsForListingRequest
    {
        WmGlobalVersion = WmGlobalVersion._31,
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        WmMarket = WmMarket1.Us,
        Body = new V3InsightsItemsListingQualityItemsRequest
        {
            Query = new Query1 { Field = Field41.Sku, Value = "WB 433KP412-12" },
        },
    });
    // TODO: Handle 'response' of type V3InsightsItemsListingQualityItemsResponse
}
catch (ApiException<ItemsDetailsForListingError> ex)
{
    if (ex.Error.TryGetV3Token400Error1(out var error))
    {
        // TODO: Handle 'error' of type V3Token400Error1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ItemsDetailsForListingRequest](src/WalmartApIs/Requests/InsightApi/ItemsDetailsForListingRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3InsightsItemsListingQualityItemsResponse](src/WalmartApIs/Models/V3InsightsItemsListingQualityItemsResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[ItemsDetailsForListingError](src/WalmartApIs/Errors/ItemsDetailsForListingError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## InventoryApi

> Source: [InventoryApi](src/WalmartApIs/Api/InventoryApi.cs)

<details>
<summary><code>Task&lt;Inventory1&gt; GetInventory(GetInventoryRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

You can use this API to get the inventory for a given item.
<br><b style='color:green;'>Market availability: Global</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.InventoryApi.GetInventory(new GetInventoryRequest
    {
        Sku = "some example string",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        WmMarket = WmMarket1.Us,
        WmGlobalVersion = WmGlobalVersion._31,
    });
    // TODO: Handle 'response' of type Inventory1
}
catch (ApiException<GetInventoryError> ex)
{
    if (ex.Error.TryGetInventory1(out var error))
    {
        // TODO: Handle 'error' of type Inventory1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetInventoryRequest](src/WalmartApIs/Requests/InventoryApi/GetInventoryRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[Inventory1](src/WalmartApIs/Models/Inventory1.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetInventoryError](src/WalmartApIs/Errors/GetInventoryError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;MultiNodeInventoryFetchResponseDto&gt; GetMultiNodeInventoryForAllSkuAndAllShipNodes(GetMultiNodeInventoryForAllSkuAndAllShipNodesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This API will retrieve the inventory count for all of a seller's items across all ship nodes by item to ship node mapping. Inventory can be zero or non-zero. Please note that NextCursor value changes and it needs to be passed on from the previous call to next call.
<br><b style='color:green;'>Market availability: US only</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.InventoryApi.GetMultiNodeInventoryForAllSkuAndAllShipNodes(
        new GetMultiNodeInventoryForAllSkuAndAllShipNodesRequest
        {
            WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
            WmSvcName = "Walmart Service Name",
            WmMarket = WmMarket1.Us,
            WmGlobalVersion = WmGlobalVersion._31,
        });
    // TODO: Handle 'response' of type MultiNodeInventoryFetchResponseDto
}
catch (ApiException<GetMultiNodeInventoryForAllSkuAndAllShipNodesError> ex)
{
    if (ex.Error.TryGetV3Inventories403Error1(out var error))
    {
        // TODO: Handle 'error' of type V3Inventories403Error1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetMultiNodeInventoryForAllSkuAndAllShipNodesRequest](src/WalmartApIs/Requests/InventoryApi/GetMultiNodeInventoryForAllSkuAndAllShipNodesRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[MultiNodeInventoryFetchResponseDto](src/WalmartApIs/Models/MultiNodeInventoryFetchResponseDto.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetMultiNodeInventoryForAllSkuAndAllShipNodesError](src/WalmartApIs/Errors/GetMultiNodeInventoryForAllSkuAndAllShipNodesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;InventoriesDto&gt; GetMultiNodeInventoryForSkuAndAllShipnodes(GetMultiNodeInventoryForSkuAndAllShipnodesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This API will retrieve the inventory count for an item across all ship nodes or one specific ship node. You can specify the ship node for which you want to fetch the inventory
<br><b style='color:green;'>Market availability: Global</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.InventoryApi.GetMultiNodeInventoryForSkuAndAllShipnodes(
        new GetMultiNodeInventoryForSkuAndAllShipnodesRequest
        {
            Sku = "some example string",
            WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
            WmSvcName = "Walmart Service Name",
            WmMarket = WmMarket1.Us,
            WmGlobalVersion = WmGlobalVersion._31,
        });
    // TODO: Handle 'response' of type InventoriesDto
}
catch (ApiException<GetMultiNodeInventoryForSkuAndAllShipnodesError> ex)
{
    if (ex.Error.TryGetInventoriesDto(out var error))
    {
        // TODO: Handle 'error' of type InventoriesDto
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetMultiNodeInventoryForSkuAndAllShipnodesRequest](src/WalmartApIs/Requests/InventoryApi/GetMultiNodeInventoryForSkuAndAllShipnodesRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[InventoriesDto](src/WalmartApIs/Models/InventoriesDto.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetMultiNodeInventoryForSkuAndAllShipnodesError](src/WalmartApIs/Errors/GetMultiNodeInventoryForSkuAndAllShipnodesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;V3FulfillmentInventoryResponse&gt; GetWfsInventory(GetWfsInventoryRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

You can use this API to get the current Available to Sell inventory quantities for all WFS items in your catalog. You can also query specific SKUs or filter to only items updated after a specific date in order to reduce the response size.
<br><b style='color:green;'>Market availability: Global</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.InventoryApi.GetWfsInventory(new GetWfsInventoryRequest
    {
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        WmMarket = WmMarket1.Us,
        WmGlobalVersion = WmGlobalVersion._31,
    });
    // TODO: Handle 'response' of type V3FulfillmentInventoryResponse
}
catch (ApiException<GetWfsInventoryError> ex)
{
    if (ex.Error.TryGetV3FulfillmentInventory403Error1(out var error))
    {
        // TODO: Handle 'error' of type V3FulfillmentInventory403Error1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetWfsInventoryRequest](src/WalmartApIs/Requests/InventoryApi/GetWfsInventoryRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3FulfillmentInventoryResponse](src/WalmartApIs/Models/V3FulfillmentInventoryResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetWfsInventoryError](src/WalmartApIs/Errors/GetWfsInventoryError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;FeedId&gt; UpdateBulkInventory(UpdateBulkInventoryRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Updates inventory for items in bulk. 
Seller Can either use feed type "inventory" or "MP_INVENTORY" 
* Inventory spec 1.4 feed type: inventory 
* Inventory spec 1.5 feed type: MP_INVENTORY 

Note: Multi Node Inventory Update Feed (feedType=MP_INVENTORY) only supports JSON Request and Responses.

 Refer to the throttling limits before uploading the Feed Files.

<b>Download the request body sample from </b>

 <a href="/file/mp/us/inventory-samples.zip">US Samples JSON</a>
<a href="/file/mp/ca/inventory-samples.zip">CA Samples JSON</a>
<a href="/file/mp/mx/inventory-samples.zip">MX Samples JSON</a>
<a href="/file/mp/cl/inventory-samples.zip">CL Samples JSON</a>
<br><b style='color:green;'>Market availability: Global</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.InventoryApi.UpdateBulkInventory(new UpdateBulkInventoryRequest
    {
        FeedType = FeedType1.Inventory,
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        WmMarket = WmMarket1.Us,
        WmGlobalVersion = WmGlobalVersion._31,
        File = Array.Empty<byte>(),
    });
    // TODO: Handle 'response' of type FeedId
}
catch (ApiException<RawError> ex)
{
    // TODO: Handle 'ex.Error' of type RawError
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[UpdateBulkInventoryRequest](src/WalmartApIs/Requests/InventoryApi/UpdateBulkInventoryRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[FeedId](src/WalmartApIs/Models/FeedId.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[RawError](src/WalmartApIs/Core/ErrorResponse/RawError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;Inventory1&gt; UpdateInventoryForAnItem(UpdateInventoryForAnItemRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Updates the inventory for a given item.
<br><b style='color:green;'>Market availability: Global</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.InventoryApi.UpdateInventoryForAnItem(new UpdateInventoryForAnItemRequest
    {
        Sku = "some example string",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        WmMarket = WmMarket1.Us,
        WmGlobalVersion = WmGlobalVersion._31,
        Body = new V3InventoryRequest
        {
            Sku = "97964_KFTest",
            Quantity = new Quantity5 { Amount = 10d },
            InventoryAvailableDate = "2024-09-20",
        },
    });
    // TODO: Handle 'response' of type Inventory1
}
catch (ApiException<UpdateInventoryForAnItemError> ex)
{
    if (ex.Error.TryGetInventory1(out var error))
    {
        // TODO: Handle 'error' of type Inventory1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[UpdateInventoryForAnItemRequest](src/WalmartApIs/Requests/InventoryApi/UpdateInventoryForAnItemRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[Inventory1](src/WalmartApIs/Models/Inventory1.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[UpdateInventoryForAnItemError](src/WalmartApIs/Errors/UpdateInventoryForAnItemError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;MultiNodeInventoryUpdateResponseDto&gt; UpdateMultiNodeInventory(UpdateMultiNodeInventoryRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This API will update the inventory for an item across one or more fulfillment centers, known as ship nodes.
<br><b style='color:green;'>Market availability: Global</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.InventoryApi.UpdateMultiNodeInventory(new UpdateMultiNodeInventoryRequest
    {
        Sku = "some example string",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        WmMarket = WmMarket1.Us,
        WmGlobalVersion = WmGlobalVersion._31,
        Body = new V3InventoriesRequest
        {
            Inventories = new Inventories3
            {
                Nodes = [
                    new Node10
                    {
                        ShipNode = "1000005050",
                        InputQty = new InputQty13 { Amount = amount },
                        InventoryAvailableDate = "2024-09-20",
                    },
                    new Node10
                    {
                        ShipNode = "79897837271126017",
                        InputQty = new InputQty13 { Amount = amount },
                        InventoryAvailableDate = "2024-09-20",
                    },
                ],
            },
        },
    });
    // TODO: Handle 'response' of type MultiNodeInventoryUpdateResponseDto
}
catch (ApiException<UpdateMultiNodeInventoryError> ex)
{
    if (ex.Error.TryGetMultiNodeInventoryUpdateResponseDto(out var error))
    {
        // TODO: Handle 'error' of type MultiNodeInventoryUpdateResponseDto
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[UpdateMultiNodeInventoryRequest](src/WalmartApIs/Requests/InventoryApi/UpdateMultiNodeInventoryRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[MultiNodeInventoryUpdateResponseDto](src/WalmartApIs/Models/MultiNodeInventoryUpdateResponseDto.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[UpdateMultiNodeInventoryError](src/WalmartApIs/Errors/UpdateMultiNodeInventoryError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## LagTimeApi

> Source: [LagTimeApi](src/WalmartApIs/Api/LagTimeApi.cs)

<details>
<summary><code>Task&lt;LagTimeResponse&gt; GetLagTime(GetLagTimeRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Use this API to retrieve the lag time for a specific item using its SKU.

Lag Time represents the number of days between when an item is ordered and when it is shipped. Approval thresholds and exemption processes for higher lag times vary by market. For more details, refer to the relevant market-specific knowledge article.
<br><b style='color:green;'>Market availability: Global</strong>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.LagTimeApi.GetLagTime(new GetLagTimeRequest
    {
        Sku = "some example string",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        WmMarket = WmMarket1.Us,
        WmGlobalVersion = WmGlobalVersion._31,
    });
    // TODO: Handle 'response' of type LagTimeResponse
}
catch (ApiException<GetLagTimeError> ex)
{
    if (ex.Error.TryGetV3Lagtime400Error1(out var error))
    {
        // TODO: Handle 'error' of type V3Lagtime400Error1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetLagTimeRequest](src/WalmartApIs/Requests/LagTimeApi/GetLagTimeRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[LagTimeResponse](src/WalmartApIs/Models/LagTimeResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetLagTimeError](src/WalmartApIs/Errors/GetLagTimeError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;FeedId1&gt; UpdateLagTimeBulk(UpdateLagTimeBulkRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Use this API to update lag time for multiple items at once.

Lag Time represents the number of days between when an item is ordered and when it is shipped. Approval thresholds and exemption processes for higher lag times vary by market. For more details, refer to the relevant market-specific knowledge article.
<br><b style='color:green;'>Market availability: Global</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.LagTimeApi.UpdateLagTimeBulk(new UpdateLagTimeBulkRequest
    {
        FeedType = "some example string",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        WmMarket = WmMarket1.Us,
        WmGlobalVersion = WmGlobalVersion._31,
        Body = new V3FeedsRequest { LagTimeHeader = new LagTimeHeader1() },
    });
    // TODO: Handle 'response' of type FeedId1
}
catch (ApiException<RawError> ex)
{
    // TODO: Handle 'ex.Error' of type RawError
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[UpdateLagTimeBulkRequest](src/WalmartApIs/Requests/LagTimeApi/UpdateLagTimeBulkRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[FeedId1](src/WalmartApIs/Models/FeedId1.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[RawError](src/WalmartApIs/Core/ErrorResponse/RawError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Notifications

> Source: [Notifications](src/WalmartApIs/Api/Notifications.cs)

<details>
<summary><code>Task&lt;V3WebhooksSubscriptionsResponse1&gt; CreateSubscription(CreateSubscriptionOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Create one or more webhook subscriptions for event notifications by selecting an event type, event version, resource name, and providing a destination event URL.

Use the Get Event Types API to retrieve available event types, versions, and resource names. Configure the eventUrl to receive notifications.

URL authentication options
- If authMethod is BASIC_AUTH, Walmart passes an authentication header to the eventUrl using authHeaderName as the header key and the Base64-encoded userName:password as the value.
- If authMethod is HMAC, Walmart passes an authentication header to the eventUrl using authHeaderName as the header key and HMACSHA256 of the complete response as the value, with clientSecret as the key.
- If authMethod is OAUTH, Walmart makes a POST call to authUrl to generate a token with request body "grant_type=client_credentials" and headers:
(1) Authorization header using authHeaderName as the key and Base64-encoded clientId:clientSecret as the value, (2) Accept: "application/json; charset=UTF-8", (3) Content-Type: "application/x-www-form-urlencoded; charset=ISO-8859-1", and (4) any custom headers provided in headers. The authUrl must return HTTP 200 with access_token and expires_in fields. When sending notifications to eventUrl, Walmart includes the access_token in headers using authHeaderName as the key and value "Bearer <access_token>", along with any custom headers provided in headers.

<b style='color:green;'>Market availability: Global</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Notifications.CreateSubscription(new CreateSubscriptionOperationRequest
    {
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Marketplace",
        WmMarket = WmMarket2.Us,
        WmGlobalVersion = WmGlobalVersion._31,
        Body = new V3WebhooksSubscriptionsRequest
        {
            Events = [
                new Events3
                {
                    EventType = "OFFER_UNPUBLISHED",
                    EventVersion = "V1",
                    ResourceName = "ITEM",
                    EventUrl = "https://example.com/events",
                    Status = "ACTIVE",
                },
                new Events3
                {
                    EventType = "PO_CREATED",
                    EventVersion = "V1",
                    ResourceName = "ORDER",
                    EventUrl = "https://example.com/orders",
                    Status = "ACTIVE",
                },
            ],
        },
    });
    // TODO: Handle 'response' of type V3WebhooksSubscriptionsResponse1
}
catch (ApiException<RawError> ex)
{
    // TODO: Handle 'ex.Error' of type RawError
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateSubscriptionOperationRequest](src/WalmartApIs/Requests/Notifications/CreateSubscriptionOperationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3WebhooksSubscriptionsResponse1](src/WalmartApIs/Models/V3WebhooksSubscriptionsResponse1.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[RawError](src/WalmartApIs/Core/ErrorResponse/RawError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;V3WebhooksSubscriptionsResponse2&gt; DeleteSubscription(DeleteSubscriptionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Delete an existing webhook subscription by ID. After deletion, the subscription cannot be retrieved.

<b style='color:green;'>Market availability: Global</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Notifications.DeleteSubscription(new DeleteSubscriptionRequest
    {
        SubscriptionId = "some example string",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Marketplace",
        WmMarket = WmMarket2.Us,
        WmGlobalVersion = WmGlobalVersion._31,
    });
    // TODO: Handle 'response' of type V3WebhooksSubscriptionsResponse2
}
catch (ApiException<RawError> ex)
{
    // TODO: Handle 'ex.Error' of type RawError
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[DeleteSubscriptionRequest](src/WalmartApIs/Requests/Notifications/DeleteSubscriptionRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3WebhooksSubscriptionsResponse2](src/WalmartApIs/Models/V3WebhooksSubscriptionsResponse2.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[RawError](src/WalmartApIs/Core/ErrorResponse/RawError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;V3WebhooksSubscriptionsResponse&gt; GetAllSubscriptions(GetAllSubscriptionsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Retrieve details of all webhook subscriptions created using the Create Subscription API. Use query parameters to filter by subscription ID, event type, resource, or status.

<b style='color:green;'>Market availability: Global</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Notifications.GetAllSubscriptions(new GetAllSubscriptionsRequest
    {
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Marketplace",
        WmMarket = WmMarket2.Us,
        WmGlobalVersion = WmGlobalVersion._31,
    });
    // TODO: Handle 'response' of type V3WebhooksSubscriptionsResponse
}
catch (ApiException<RawError> ex)
{
    // TODO: Handle 'ex.Error' of type RawError
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetAllSubscriptionsRequest](src/WalmartApIs/Requests/Notifications/GetAllSubscriptionsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3WebhooksSubscriptionsResponse](src/WalmartApIs/Models/V3WebhooksSubscriptionsResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[RawError](src/WalmartApIs/Core/ErrorResponse/RawError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;V3WebhooksEventTypesResponse&gt; GetEventTypes(GetEventTypesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Retrieve the list of event types and resource names available for subscription. Notifications are triggered only for event types that you subscribe to using the Create Subscription API.

Event types are workflow events fired when statuses or conditions change (for example, an offer moving from published to unpublished, an order auto-cancellation, or a buy box change).

Resource names are functional API categories (for example, ITEM, PRICE, ORDER, INVENTORY). Permissions to subscribe to an event type are governed by the resource's delegated access permissions.

<b style='color:green;'>Market availability: Global</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Notifications.GetEventTypes(new GetEventTypesRequest
    {
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Marketplace",
        WmMarket = WmMarket2.Us,
        WmGlobalVersion = WmGlobalVersion._31,
    });
    // TODO: Handle 'response' of type V3WebhooksEventTypesResponse
}
catch (ApiException<RawError> ex)
{
    // TODO: Handle 'ex.Error' of type RawError
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetEventTypesRequest](src/WalmartApIs/Requests/Notifications/GetEventTypesRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3WebhooksEventTypesResponse](src/WalmartApIs/Models/V3WebhooksEventTypesResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[RawError](src/WalmartApIs/Core/ErrorResponse/RawError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;RejectRecommendationsResponsePayload&gt; TestNotification(TestNotificationOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Send a test notification to a destination URL using a sample payload.

<b style='color:green;'>Market availability: Global</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Notifications.TestNotification(new TestNotificationOperationRequest
    {
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Marketplace",
        WmMarket = WmMarket2.Us,
        WmGlobalVersion = WmGlobalVersion._31,
        Body = new V3WebhooksTestRequest
        {
            EventType = "OFFER_UNPUBLISHED",
            EventVersion = "V1",
            ResourceName = "ITEM",
            EventUrl = "https://example.com/events",
            AuthDetails = new AuthDetails8
            {
                AuthMethod = "BASIC_AUTH",
                UserName = "abc",
                Password = "test",
                AuthHeaderName = "Authorization",
            },
            Headers = new Dictionary<string, string> { ["X-Custom-Header"] = "my-value" },
        },
    });
    // TODO: Handle 'response' of type RejectRecommendationsResponsePayload
}
catch (ApiException<RawError> ex)
{
    // TODO: Handle 'ex.Error' of type RawError
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[TestNotificationOperationRequest](src/WalmartApIs/Requests/Notifications/TestNotificationOperationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[RejectRecommendationsResponsePayload](src/WalmartApIs/Models/RejectRecommendationsResponsePayload.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[RawError](src/WalmartApIs/Core/ErrorResponse/RawError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;V3WebhooksSubscriptionsResponse3&gt; UpdateSubscription(UpdateSubscriptionOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Update the details of a subscription. You can update the event version, destination URL, headers, and authentication details. You can also enable or disable the subscription by changing the status to ACTIVE or INACTIVE.

<b style='color:green;'>Market availability: Global</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Notifications.UpdateSubscription(new UpdateSubscriptionOperationRequest
    {
        SubscriptionId = "some example string",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Marketplace",
        WmMarket = WmMarket2.Us,
        WmGlobalVersion = WmGlobalVersion._31,
        Body = new V3WebhooksSubscriptionsRequest1
        {
            EventUrl = "https://example.com/events",
            AuthDetails = new AuthDetails8
            {
                AuthMethod = "BASIC_AUTH",
                UserName = "abc",
                Password = "test",
                AuthHeaderName = "Authorization",
            },
            Status = "ACTIVE",
        },
    });
    // TODO: Handle 'response' of type V3WebhooksSubscriptionsResponse3
}
catch (ApiException<RawError> ex)
{
    // TODO: Handle 'ex.Error' of type RawError
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[UpdateSubscriptionOperationRequest](src/WalmartApIs/Requests/Notifications/UpdateSubscriptionOperationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3WebhooksSubscriptionsResponse3](src/WalmartApIs/Models/V3WebhooksSubscriptionsResponse3.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[RawError](src/WalmartApIs/Core/ErrorResponse/RawError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## OnRequestReport

> Source: [OnRequestReport](src/WalmartApIs/Api/OnRequestReport.cs)

<details>
<summary><code>Task&lt;V3ReportsReportRequestsResponse1&gt; GenerateReport(GenerateReportRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Creates a new request for report by specifying the `reportType` and `reportVersion`.
<br><b style='color:green;'>Market availability: Global</b>

**Max reporting window:** For `ITEM_PERFORMANCE` v3, the date range between `dataStartTime` and `dataEndTime` must not exceed 2 years (730 days). Exceeding this limit will return a `400` error.

**Row limit:** There is no limit on the number of rows returned in the report.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.OnRequestReport.GenerateReport(new GenerateReportRequest
    {
        ReportType = ReportType4.Item,
        ReportVersion = "v1",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        WmMarket = WmMarket1.Us,
        WmGlobalVersion = WmGlobalVersion._31,
        Accept = "application/json",
        Body = new V3ReportsReportRequestsRequest
        {
            RowFilters = [
                new EnumFilter2 { ColumnName = "Offer Start Date", Type = Type4.RangeFilter },
                new EnumFilter2 { ColumnName = "Offer End Date", Type = Type4.RangeFilter },
                new EnumFilter2 { ColumnName = "Price", Type = Type4.RangeFilter },
                new EnumFilter2 { Values = ["PUBLISHED"], ColumnName = "Publish Status", Type = Type4.EnumFilter },
                new EnumFilter2
                {
                    Values = ["FELIX LECHEF", "ANEZUS"],
                    ColumnName = "brand",
                    Type = Type4.MultiValueFilter,
                },
                new EnumFilter2
                {
                    Values = ["JEWELRY MAKING AND STORAGE"],
                    ColumnName = "category",
                    Type = Type4.MultiValueFilter,
                },
            ],
            ExcludeColumns = ["Average Rating", "Shelf Name"],
            DataStartTime = "2024-08-10T20:11:24.000Z",
            DataEndTime = "2024-09-10T20:11:24.000Z",
        },
    });
    // TODO: Handle 'response' of type V3ReportsReportRequestsResponse1
}
catch (ApiException<GenerateReportError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GenerateReportRequest](src/WalmartApIs/Requests/OnRequestReport/GenerateReportRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3ReportsReportRequestsResponse1](src/WalmartApIs/Models/V3ReportsReportRequestsResponse1.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GenerateReportError](src/WalmartApIs/Errors/GenerateReportError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## OnRequestReportApi

> Source: [OnRequestReportApi](src/WalmartApIs/Api/OnRequestReportApi.cs)

<details>
<summary><code>Task&lt;DownloadReportResponse&gt; DownloadReport(DownloadReportRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Fetches URL to download a generated report.
<br><b style='color:green;'>Market availability: Global</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.OnRequestReportApi.DownloadReport(new DownloadReportRequest
    {
        RequestId = "28fae71e-7f34-4493-ad5b-1edca6afebf7",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        WmMarket = WmMarket1.Us,
        WmGlobalVersion = WmGlobalVersion._31,
        Accept = "application/json",
    });
    // TODO: Handle 'response' of type DownloadReportResponse
}
catch (ApiException<RawError> ex)
{
    // TODO: Handle 'ex.Error' of type RawError
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[DownloadReportRequest](src/WalmartApIs/Requests/OnRequestReportApi/DownloadReportRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[DownloadReportResponse](src/WalmartApIs/Models/DownloadReportResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[RawError](src/WalmartApIs/Core/ErrorResponse/RawError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;RequestsStatusResponse&gt; GetRequestsStatus(GetRequestsStatusRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Fetches a list of all report requests for specified search criteria by using query parameters.

You can fetch details of report requests created in the last 30 days only.
<br><b style='color:green;'>Market availability: Global</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.OnRequestReportApi.GetRequestsStatus(new GetRequestsStatusRequest
    {
        ReportType = ReportType4.Item,
        ReportVersion = "v1",
        RequestStatus = RequestStatus4.Ready,
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        WmMarket = WmMarket1.Us,
        WmGlobalVersion = WmGlobalVersion._31,
        Accept = "application/json",
    });
    // TODO: Handle 'response' of type RequestsStatusResponse
}
catch (ApiException<RawError> ex)
{
    // TODO: Handle 'ex.Error' of type RawError
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetRequestsStatusRequest](src/WalmartApIs/Requests/OnRequestReportApi/GetRequestsStatusRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[RequestsStatusResponse](src/WalmartApIs/Models/RequestsStatusResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[RawError](src/WalmartApIs/Core/ErrorResponse/RawError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;RequestStatusResponse&gt; GetSingleRequestStatus(GetSingleRequestStatusRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Fetches status and other details of a report request by providing a requestID.

You can fetch details of report request created in the last 30 days only.
<br><b style='color:green;'>Market availability: Global</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.OnRequestReportApi.GetSingleRequestStatus(new GetSingleRequestStatusRequest
    {
        RequestId = "28fae71e-7f34-4493-ad5b-1edca6afebf7",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        WmMarket = WmMarket1.Us,
        WmGlobalVersion = WmGlobalVersion._31,
        Accept = "application/json",
    });
    // TODO: Handle 'response' of type RequestStatusResponse
}
catch (ApiException<RawError> ex)
{
    // TODO: Handle 'ex.Error' of type RawError
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetSingleRequestStatusRequest](src/WalmartApIs/Requests/OnRequestReportApi/GetSingleRequestStatusRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[RequestStatusResponse](src/WalmartApIs/Models/RequestStatusResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[RawError](src/WalmartApIs/Core/ErrorResponse/RawError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Prices

> Source: [Prices](src/WalmartApIs/Api/Prices.cs)

<details>
<summary><code>Task&lt;V3RepricerStrategyResponse2&gt; CreateStrategy(CreateStrategyRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Creates a new strategy for the seller.<br><b style='color:green;'>Market availability: US | CA | MX</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Prices.CreateStrategy(new CreateStrategyRequest
    {
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        WmMarket = WmMarket1.Us,
        WmGlobalVersion = WmGlobalVersion._31,
        Body = new V3RepricerStrategyRequest1(),
    });
    // TODO: Handle 'response' of type V3RepricerStrategyResponse2
}
catch (ApiException<CreateStrategyError> ex)
{
    if (ex.Error.TryGetV3RepricerStrategy400Error1(out var error))
    {
        // TODO: Handle 'error' of type V3RepricerStrategy400Error1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateStrategyRequest](src/WalmartApIs/Requests/Prices/CreateStrategyRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3RepricerStrategyResponse2](src/WalmartApIs/Models/V3RepricerStrategyResponse2.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[CreateStrategyError](src/WalmartApIs/Errors/CreateStrategyError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;RejectRecommendationsResponsePayload&gt; DeleteStrategy(DeleteStrategyRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Deletes the strategy.<br><b style='color:green;'>Market availability: US | CA | MX</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Prices.DeleteStrategy(new DeleteStrategyRequest
    {
        StrategyCollectionId = "some example string",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        WmMarket = WmMarket1.Us,
        WmGlobalVersion = WmGlobalVersion._31,
    });
    // TODO: Handle 'response' of type RejectRecommendationsResponsePayload
}
catch (ApiException<DeleteStrategyError> ex)
{
    if (ex.Error.TryGetV3RepricerStrategy400Error1(out var error))
    {
        // TODO: Handle 'error' of type V3RepricerStrategy400Error1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[DeleteStrategyRequest](src/WalmartApIs/Requests/Prices/DeleteStrategyRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[RejectRecommendationsResponsePayload](src/WalmartApIs/Models/RejectRecommendationsResponsePayload.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[DeleteStrategyError](src/WalmartApIs/Errors/DeleteStrategyError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;V3PriceIncentivesResponse&gt; GetAllIncentives(GetAllIncentivesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Get Incentives API endpoint gives you the list of all price incentives for items in your catalog. 

The details include Item Id, Product Name, Product Url, SKU Id, Target Price, current Price, Incentive Type, Incentive Status, Base referral fee, Reduced Referral Fee, Enrollment Type, Inventory count, Enrollment Date (epoch Timestamp), Start date (epoch Timestamp), Expiration date (epoch Timestamp), and Incentive Id. 

Target Price, Expiration date, Start date, Incentive Id, and Reduced Ref fee and Enrollment Type for WF items would not be shown (null values). 

Enrollment Type and Date for Eligible Reduced Referral Fee incentives will not show up.<br><b style='color:green;'>Market availability: US</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Prices.GetAllIncentives(new GetAllIncentivesRequest
    {
        IncentiveStatus = IncentiveStatus.Eligible,
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        WmMarket = WmMarket1.Us,
        WmGlobalVersion = WmGlobalVersion._31,
    });
    // TODO: Handle 'response' of type V3PriceIncentivesResponse
}
catch (ApiException<GetAllIncentivesError> ex)
{
    if (ex.Error.TryGetV3PriceIncentives400Error1(out var error))
    {
        // TODO: Handle 'error' of type V3PriceIncentives400Error1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetAllIncentivesRequest](src/WalmartApIs/Requests/Prices/GetAllIncentivesRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3PriceIncentivesResponse](src/WalmartApIs/Models/V3PriceIncentivesResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetAllIncentivesError](src/WalmartApIs/Errors/GetAllIncentivesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;FeedId1&gt; GetRepricerFeed(GetRepricerFeedRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Add/Remove one or more items from a strategy.<br><b style='color:green;'>Market availability: US | CA | MX</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Prices.GetRepricerFeed(new GetRepricerFeedRequest
    {
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        WmMarket = WmMarket1.Us,
        WmGlobalVersion = WmGlobalVersion._31,
        Body = new V3RepricerFeedsRequest(),
    });
    // TODO: Handle 'response' of type FeedId1
}
catch (ApiException<GetRepricerFeedError> ex)
{
    if (ex.Error.TryGetV3Token400Error1(out var error))
    {
        // TODO: Handle 'error' of type V3Token400Error1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetRepricerFeedRequest](src/WalmartApIs/Requests/Prices/GetRepricerFeedRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[FeedId1](src/WalmartApIs/Models/FeedId1.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetRepricerFeedError](src/WalmartApIs/Errors/GetRepricerFeedError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;V3RepricerStrategiesResponse&gt; GetStrategies(GetStrategiesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Get the list of strategies.<br><b style='color:green;'>Market availability: US | CA | MX</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Prices.GetStrategies(new GetStrategiesRequest
    {
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        WmMarket = WmMarket1.Us,
        WmGlobalVersion = WmGlobalVersion._31,
    });
    // TODO: Handle 'response' of type V3RepricerStrategiesResponse
}
catch (ApiException<GetStrategiesError> ex)
{
    if (ex.Error.TryGetV3Token400Error1(out var error))
    {
        // TODO: Handle 'error' of type V3Token400Error1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetStrategiesRequest](src/WalmartApIs/Requests/Prices/GetStrategiesRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3RepricerStrategiesResponse](src/WalmartApIs/Models/V3RepricerStrategiesResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetStrategiesError](src/WalmartApIs/Errors/GetStrategiesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;FeedId&gt; PriceAndPromotionBulkUploads(PriceAndPromotionBulkUploadsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Updates prices and promotions in bulk for multiple items. You can modify the prices of multiple items in bulk using a price feed. This is useful for implementing pricing strategies across your catalog, such as seasonal discounts, competitive pricing adjustments, or clearance sales.

Each price feed can contain up to 10,000 items. To ensure optimal performance (feed processing time), we recommend limiting feeds to 1,000 items and keeping the payload under 10 MB.

Use this API instead of the single price update API when updating prices for multiple items. For newly created items, ensure that the Walmart Part ID (WPID) has been assigned and that at least 24 hours have passed since item creation before submitting a bulk price update feed. The bulk price update Service Level Agreement (SLA) is 15 minutes.

The price sequence guarantee is observed by the bulk price update functionality, subject to the following rules:

<ul><li>You may include the same Stock Keeping Unit (SKU) multiple times in a single feed. However, if a SKU is repeated in a feed, only one price will be applied.</li><li>The price sequence guarantee ensures that the latest price update, based on its creation timestamp, is the one that changes the item's price, overwriting the previous version.</li><li>Price updates received with an earlier timestamp are ignored. We recommend using UTC timestamps for the value of <code>feedDate</code> in all feed-based bulk updates.</li></ul>

After submitting the price feed, wait at least 5 minutes before checking whether the bulk price update was successful. If a price update fails, for example, due to duplicate SKU entries, an error response will be returned.

For more information and usage examples, refer to the <a href="https://developer.walmart.com/global-marketplace/docs/update-pricing-for-multiple-items-bulk">Pricing API Guide</a>.

<strong style="color: green;">Market availability: Global</strong>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Prices.PriceAndPromotionBulkUploads(new PriceAndPromotionBulkUploadsRequest
    {
        FeedType = FeedType21.PriceAndPromotion,
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        WmMarket = WmMarket1.Us,
        WmGlobalVersion = WmGlobalVersion._31,
        Body = new V3FeedsFeedTypePriceAndPromotionRequest(),
    });
    // TODO: Handle 'response' of type FeedId
}
catch (ApiException<PriceAndPromotionBulkUploadsError> ex)
{
    if (ex.Error.TryGetV3Token400Error1(out var error))
    {
        // TODO: Handle 'error' of type V3Token400Error1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[PriceAndPromotionBulkUploadsRequest](src/WalmartApIs/Requests/Prices/PriceAndPromotionBulkUploadsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[FeedId](src/WalmartApIs/Models/FeedId.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[PriceAndPromotionBulkUploadsError](src/WalmartApIs/Errors/PriceAndPromotionBulkUploadsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;V3FeedsFeedTypeIncentiveEnrollmentResponse&gt; ReducedReferralFeeIncentivesEnrollment(ReducedReferralFeeIncentivesEnrollmentRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

You can use this API endpoint to enroll any eligible reduced referral fee incentive and unenroll any active reduced referral fee incentives.<br><b style='color:green;'>Market availability: US</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Prices.ReducedReferralFeeIncentivesEnrollment(
        new ReducedReferralFeeIncentivesEnrollmentRequest
        {
            FeedType = FeedType11.IncentiveEnrollment,
            WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
            WmSvcName = "Walmart Service Name",
            WmMarket = WmMarket1.Us,
            WmGlobalVersion = WmGlobalVersion._31,
            Body = new V3FeedsFeedTypeIncentiveEnrollmentRequest(),
        });
    // TODO: Handle 'response' of type V3FeedsFeedTypeIncentiveEnrollmentResponse
}
catch (ApiException<ReducedReferralFeeIncentivesEnrollmentError> ex)
{
    if (ex.Error.TryGetV3Token400Error1(out var error))
    {
        // TODO: Handle 'error' of type V3Token400Error1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ReducedReferralFeeIncentivesEnrollmentRequest](src/WalmartApIs/Requests/Prices/ReducedReferralFeeIncentivesEnrollmentRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3FeedsFeedTypeIncentiveEnrollmentResponse](src/WalmartApIs/Models/V3FeedsFeedTypeIncentiveEnrollmentResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[ReducedReferralFeeIncentivesEnrollmentError](src/WalmartApIs/Errors/ReducedReferralFeeIncentivesEnrollmentError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;V3PriceResponse&gt; UpdatePrice(UpdatePriceRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Updates the price of an item listed on Walmart Marketplace. Use this API to change the price of a single item. If you want to update pricing for multiple items, we recommend using the <a href="https://developer.walmart.com/global-marketplace/reference/priceandpromotionbulkuploads">Update pricing for multiple items in bulk</a> API. 

For more information and usage examples, refer to the <a href="https://developer.walmart.com/us-marketplace/docs/update-pricing-for-a-single-item">Pricing API Guide</a>.<br><b style='color:green;'>Market availability: CA | MX | CL</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Prices.UpdatePrice(new UpdatePriceRequest
    {
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        WmMarket = WmMarket1.Us,
        WmGlobalVersion = WmGlobalVersion._31,
        Body = new V3PriceRequest(),
    });
    // TODO: Handle 'response' of type V3PriceResponse
}
catch (ApiException<UpdatePriceError> ex)
{
    if (ex.Error.TryGetV3Token400Error1(out var error))
    {
        // TODO: Handle 'error' of type V3Token400Error1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[UpdatePriceRequest](src/WalmartApIs/Requests/Prices/UpdatePriceRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3PriceResponse](src/WalmartApIs/Models/V3PriceResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[UpdatePriceError](src/WalmartApIs/Errors/UpdatePriceError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;V3RepricerStrategyResponse&gt; UpdateStrategy(UpdateStrategyRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Updates the existing strategy.<br><b style='color:green;'>Market availability: US | CA | MX</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Prices.UpdateStrategy(new UpdateStrategyRequest
    {
        StrategyCollectionId = "some example string",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        WmMarket = WmMarket1.Us,
        WmGlobalVersion = WmGlobalVersion._31,
        Body = new V3RepricerStrategyRequest { Enabled = true },
    });
    // TODO: Handle 'response' of type V3RepricerStrategyResponse
}
catch (ApiException<UpdateStrategyError> ex)
{
    if (ex.Error.TryGetV3RepricerStrategy400Error1(out var error))
    {
        // TODO: Handle 'error' of type V3RepricerStrategy400Error1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[UpdateStrategyRequest](src/WalmartApIs/Requests/Prices/UpdateStrategyRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3RepricerStrategyResponse](src/WalmartApIs/Models/V3RepricerStrategyResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[UpdateStrategyError](src/WalmartApIs/Errors/UpdateStrategyError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;V3PriceIncentivesWfpreferenceResponse&gt; UpdateWalmartFundedIncentivesEnrollmentStatus(UpdateWalmartFundedIncentivesEnrollmentStatusRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

If you wish to permanently disable Walmart-funded incentives for all items of your catalog, you can use this API to set the Walmart-funded incentives program as OFF. 

The default value of this variable is ON. 

Any changes to preferences will lock in (disable) the preference option for a period of 4 hours as indicated by isDisabled response field of the API.<br><b style='color:green;'>Market availability: US</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Prices.UpdateWalmartFundedIncentivesEnrollmentStatus(
        new UpdateWalmartFundedIncentivesEnrollmentStatusRequest
        {
            AutoEnrollEnabled = true,
            WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
            WmSvcName = "Walmart Service Name",
            WmMarket = WmMarket1.Us,
            WmGlobalVersion = WmGlobalVersion._31,
        });
    // TODO: Handle 'response' of type V3PriceIncentivesWfpreferenceResponse
}
catch (ApiException<UpdateWalmartFundedIncentivesEnrollmentStatusError> ex)
{
    if (ex.Error.TryGetV3Token400Error1(out var error))
    {
        // TODO: Handle 'error' of type V3Token400Error1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[UpdateWalmartFundedIncentivesEnrollmentStatusRequest](src/WalmartApIs/Requests/Prices/UpdateWalmartFundedIncentivesEnrollmentStatusRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3PriceIncentivesWfpreferenceResponse](src/WalmartApIs/Models/V3PriceIncentivesWfpreferenceResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[UpdateWalmartFundedIncentivesEnrollmentStatusError](src/WalmartApIs/Errors/UpdateWalmartFundedIncentivesEnrollmentStatusError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;FeedId&gt; WalmartFundedIncentivesEnrollment(WalmartFundedIncentivesEnrollmentRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

While all Walmart-funded incentives are auto-enrolled by default, you can use this API endpoint to 'Opt-out' specific Walmart-funded items whose price you don't wish to lower. 

You can also 'Opt-in' items which were previously Opted-out by you at any time using this API.<br><b style='color:green;'>Market availability: US</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Prices.WalmartFundedIncentivesEnrollment(new WalmartFundedIncentivesEnrollmentRequest
    {
        FeedType = FeedType2.WalmartFundedIncentivesEnrollment,
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        WmMarket = WmMarket1.Us,
        WmGlobalVersion = WmGlobalVersion._31,
        Body = new V3FeedsFeedTypeWalmartFundedIncentivesEnrollmentRequest(),
    });
    // TODO: Handle 'response' of type FeedId
}
catch (ApiException<WalmartFundedIncentivesEnrollmentError> ex)
{
    if (ex.Error.TryGetV3Token400Error1(out var error))
    {
        // TODO: Handle 'error' of type V3Token400Error1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[WalmartFundedIncentivesEnrollmentRequest](src/WalmartApIs/Requests/Prices/WalmartFundedIncentivesEnrollmentRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[FeedId](src/WalmartApIs/Models/FeedId.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[WalmartFundedIncentivesEnrollmentError](src/WalmartApIs/Errors/WalmartFundedIncentivesEnrollmentError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Promotions

> Source: [Promotions](src/WalmartApIs/Api/Promotions.cs)

<details>
<summary><code>Task&lt;V3PromoSkuResponse&gt; GetPromotionalPrices(GetPromotionalPricesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Retrieves a list of promotional prices for a single SKU.<br><b style='color:green;'>Market availability: Global</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Promotions.GetPromotionalPrices(new GetPromotionalPricesRequest
    {
        Sku = "some example string",
        WmSecAccessToken = "eyJraWQiOiIzZjVhYTFmNS1hYWE5LTQzM.....",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        WmMarket = WmMarket1.Us,
        WmGlobalVersion = WmGlobalVersion._31,
    });
    // TODO: Handle 'response' of type V3PromoSkuResponse
}
catch (ApiException<GetPromotionalPricesError> ex)
{
    if (ex.Error.TryGetV3Token500Error1(out var error))
    {
        // TODO: Handle 'error' of type V3Token500Error1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetPromotionalPricesRequest](src/WalmartApIs/Requests/Promotions/GetPromotionalPricesRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3PromoSkuResponse](src/WalmartApIs/Models/V3PromoSkuResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetPromotionalPricesError](src/WalmartApIs/Errors/GetPromotionalPricesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;FeedId1&gt; PriceBulkUploads(PriceBulkUploadsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

The price and promotional price API allows you to creates, updates, or deletes promotional prices for multiple SKUs 

 To set a new promotional price, set the "promotionSettingAction" attribute to "Create". To update an existing one, set the "promotionSettingAction" attribute to "Create" with promoId. To delete a promotional price, set the "promotionSettingAction" attribute to "Delete". To delete all promotions for a SKU, set the "promotionSettingAction" attribute to "Replace All" 

 Please Note: 
- The effective start date for a given promotion should be within 365 days from the current date and time. 
- The end date of a given promotion should be within 180 days from the start date and time. Any promotions beyond 180 days will result in an error <br><b style='color:green;'>Market availability: Global</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Promotions.PriceBulkUploads(new PriceBulkUploadsRequest
    {
        FeedType = FeedType21.PriceAndPromotion,
        WmSecAccessToken = "eyJraWQiOiIzZjVhYTFmNS1hYWE5LTQzM.....",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        WmMarket = WmMarket1.Us,
        WmGlobalVersion = WmGlobalVersion._31,
    });
    // TODO: Handle 'response' of type FeedId1
}
catch (ApiException<PriceBulkUploadsError> ex)
{
    if (ex.Error.TryGetV3Token500Error1(out var error))
    {
        // TODO: Handle 'error' of type V3Token500Error1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[PriceBulkUploadsRequest](src/WalmartApIs/Requests/Promotions/PriceBulkUploadsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[FeedId1](src/WalmartApIs/Models/FeedId1.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[PriceBulkUploadsError](src/WalmartApIs/Errors/PriceBulkUploadsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;V3PriceResponse&gt; UpdatePromotionalPrices(UpdatePromotionalPricesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

The update a promotional price API allows you to creates, updates, or deletes promotional prices for single SKUs 

 To set a new promotional price, set the "promotionSettingAction" attribute to "Create". To update an existing one, set the "promotionSettingAction" attribute to "Create" with promoId. To delete a promotional price, set the "promotionSettingAction" attribute to "Delete". To delete all promotions for a SKU, set the "promotionSettingAction" attribute to "Replace All" 

 Please Note: 
- The effective start date for a given promotion should be within 365 days from the current date and time. 
- The end date of a given promotion should be within 180 days from the start date and time. Any promotions beyond 180 days will result in an error <br><b style='color:green;'>Market availability: CA | MX | CL</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Promotions.UpdatePromotionalPrices(new UpdatePromotionalPricesRequest
    {
        WmSecAccessToken = "eyJraWQiOiIzZjVhYTFmNS1hYWE5LTQzM.....",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        WmMarket = WmMarket1.Us,
        WmGlobalVersion = WmGlobalVersion._31,
        Body = new V3PriceRequest(),
    });
    // TODO: Handle 'response' of type V3PriceResponse
}
catch (ApiException<UpdatePromotionalPricesError> ex)
{
    if (ex.Error.TryGetV3Token500Error1(out var error))
    {
        // TODO: Handle 'error' of type V3Token500Error1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[UpdatePromotionalPricesRequest](src/WalmartApIs/Requests/Promotions/UpdatePromotionalPricesRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3PriceResponse](src/WalmartApIs/Models/V3PriceResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[UpdatePromotionalPricesError](src/WalmartApIs/Errors/UpdatePromotionalPricesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## RecommendationsApi

> Source: [RecommendationsApi](src/WalmartApIs/Api/RecommendationsApi.cs)

<details>
<summary><code>Task&lt;V3WfsRecommendationFulfilWithWfsResponse&gt; GetFulfillWithWfsRecommendations(GetFulfillWithWfsRecommendationsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Use **Fulfill With WFS Recommendations** to identify which seller-fulfilled items in your catalog Walmart suggests could potentially perform best when fulfilled by WFS. These suggestions are available on demand, and suggestions are refreshed the 1st and 15th of each month.

Key attributes include:

- **estimatedSalesLift**: The estimated increase in sales you could see if you converted the suggested items from seller-fulfilled to WFS.

- **sellerFulfilledPast30DaysSales**: A historical view of your seller-fulfilled sales for the past 30 days.
- **walmartFulfilledEstimatedSales**: An estimated view of your potential sales if the suggested items were fulfilled by WFS.

You can use these suggestions to determine which items to convert to WFS.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.RecommendationsApi.GetFulfillWithWfsRecommendations(
        new GetFulfillWithWfsRecommendationsRequest
        {
            CustomerFavorite = true,
            Limit = 10,
            Offset = 1,
            SortBy = "estimatedSalesLift",
            ContentType = "application/json",
            Accept = "application/json",
            WmGlobalVersion = "3.1",
            WmMarket = "US",
            WmAuditOriginSource = "SELLER_API",
        });
    // TODO: Handle 'response' of type V3WfsRecommendationFulfilWithWfsResponse
}
catch (ApiException<GetFulfillWithWfsRecommendationsError> ex)
{
    if (ex.Error.TryGetErrorResponse2(out var error))
    {
        // TODO: Handle 'error' of type ErrorResponse2
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetFulfillWithWfsRecommendationsRequest](src/WalmartApIs/Requests/RecommendationsApi/GetFulfillWithWfsRecommendationsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3WfsRecommendationFulfilWithWfsResponse](src/WalmartApIs/Models/V3WfsRecommendationFulfilWithWfsResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetFulfillWithWfsRecommendationsError](src/WalmartApIs/Errors/GetFulfillWithWfsRecommendationsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;V3WfsRecommendationRestockResponse&gt; GetRestockRecommendations(GetRestockRecommendationsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Use **Restock Recommendations** to get Walmart-generated suggestions for the items you should restock with WFS based on your current inventory and forecasted sales demand. These suggestions are available on demand. Key attributes include:

- **suggestedUnits**: The number of units we suggest you send of this item to WFS
- **forecastedSalesLift**: The estimated increase in sales you may see if your items are restocked according to our suggestions
- **totalForecastedSalesLost**: How much money you're estimated to lose out on if you don't restock your inventory

Once you determine which suggested items to restock, you can use the Create inbound shipment API to create a shipping plan to send inventory to WFS.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.RecommendationsApi.GetRestockRecommendations(new GetRestockRecommendationsRequest
    {
        CustomerFavorite = true,
        Limit = 10,
        Offset = 1,
        SortBy = "forecastedSalesLift",
        Authorization = "Basic YzcyOTFjNmItNzI5MC00....",
        ContentType = "application/json",
        Accept = "application/json",
        WmGlobalVersion = "3.1",
        WmMarket = "US",
        WmAuditOriginSource = "SELLER_API",
    });
    // TODO: Handle 'response' of type V3WfsRecommendationRestockResponse
}
catch (ApiException<GetRestockRecommendationsError> ex)
{
    if (ex.Error.TryGetErrorResponse2(out var error))
    {
        // TODO: Handle 'error' of type ErrorResponse2
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetRestockRecommendationsRequest](src/WalmartApIs/Requests/RecommendationsApi/GetRestockRecommendationsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3WfsRecommendationRestockResponse](src/WalmartApIs/Models/V3WfsRecommendationRestockResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetRestockRecommendationsError](src/WalmartApIs/Errors/GetRestockRecommendationsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;V3WfsRecommendationShipmentQuantityResponse&gt; GetShipmentQuantityRecommendations(GetShipmentQuantityRecommendationsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Use this API to get recommended shipment quantities for the items that you plan to send to Walmart Fulfillment Services (WFS) in order to achieve optimal inventory levels.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.RecommendationsApi.GetShipmentQuantityRecommendations(
        new GetShipmentQuantityRecommendationsRequest
        {
            Authorization = "Basic YzcyOTFjNmItNzI5MC00....",
            WmSecAccessToken = "eyJraWQiOiIzZjVhYTFmNS1hYWE5LTQzM.....",
            WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
            WmSvcName = "Walmart Service Name",
            Accept = "application/json",
            WmGlobalVersion = "3.1",
            WmMarket = "US",
            Body = new V3WfsRecommendationShipmentQuantityRequest
            {
                ListOfGtins = ["00723508807642", "00643131798370", "00643131799155"],
                ListOfSkus = [],
            },
        });
    // TODO: Handle 'response' of type V3WfsRecommendationShipmentQuantityResponse
}
catch (ApiException<GetShipmentQuantityRecommendationsError> ex)
{
    if (ex.Error.TryGetErrorResponse2(out var error))
    {
        // TODO: Handle 'error' of type ErrorResponse2
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetShipmentQuantityRecommendationsRequest](src/WalmartApIs/Requests/RecommendationsApi/GetShipmentQuantityRecommendationsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3WfsRecommendationShipmentQuantityResponse](src/WalmartApIs/Models/V3WfsRecommendationShipmentQuantityResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetShipmentQuantityRecommendationsError](src/WalmartApIs/Errors/GetShipmentQuantityRecommendationsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;V3WfsRecommendationUnpublishedResponse&gt; GetUnpublishedRecommendations(GetUnpublishedRecommendationsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This call helps you identify the estimated storage fees with Walmart for your unpublished WFS items.

Use **Unpublish Recommendations** to fetch a current list of your unpublished WFS items. This is available on demand. 

Key data attributes include:

- **unpublishedIssue**: The reason your item is currently unpublished with Walmart.
- **estimatedStorageFee**: The estimated storage costs associated with your unpublished WFS inventory.
- **totalunpublishedunitsstored**: The total quantity of units in WFS fulfillment centers for unpublished items.

Use this data to identify the reason these items are unpublished and the estimated costs associated with these unpublished items. By default, these suggestions will only include items that are active with an Available to Sell (ATS) quantity of 0.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.RecommendationsApi.GetUnpublishedRecommendations(
        new GetUnpublishedRecommendationsRequest
        {
            CustomerFavorite = true,
            Limit = 10,
            Offset = 1,
            SortBy = "forecastedSalesLift",
            ContentType = "application/json",
            Accept = "application/json",
            WmGlobalVersion = "3.1",
            WmMarket = "US",
            WmAuditOriginSource = "SELLER_API",
        });
    // TODO: Handle 'response' of type V3WfsRecommendationUnpublishedResponse
}
catch (ApiException<GetUnpublishedRecommendationsError> ex)
{
    if (ex.Error.TryGetErrorResponse2(out var error))
    {
        // TODO: Handle 'error' of type ErrorResponse2
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetUnpublishedRecommendationsRequest](src/WalmartApIs/Requests/RecommendationsApi/GetUnpublishedRecommendationsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3WfsRecommendationUnpublishedResponse](src/WalmartApIs/Models/V3WfsRecommendationUnpublishedResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetUnpublishedRecommendationsError](src/WalmartApIs/Errors/GetUnpublishedRecommendationsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## ReportScheduler

> Source: [ReportScheduler](src/WalmartApIs/Api/ReportScheduler.cs)

<details>
<summary><code>Task&lt;RejectRecommendationsResponsePayload&gt; DeleteReportSchedule(DeleteReportScheduleRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This API allows you to remove an existing report schedule. 

<strong style="color: green;">Market availability: US only</strong>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ReportScheduler.DeleteReportSchedule(new DeleteReportScheduleRequest
    {
        ScheduleId = "some example string",
        WmSvcName = "Walmart Marketplace",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
    });
    // TODO: Handle 'response' of type RejectRecommendationsResponsePayload
}
catch (ApiException<RawError> ex)
{
    // TODO: Handle 'ex.Error' of type RawError
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[DeleteReportScheduleRequest](src/WalmartApIs/Requests/ReportScheduler/DeleteReportScheduleRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[RejectRecommendationsResponsePayload](src/WalmartApIs/Models/RejectRecommendationsResponsePayload.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[RawError](src/WalmartApIs/Core/ErrorResponse/RawError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;V3ReportsSchedulesResponse&gt; GetAllReportSchedules(GetAllReportSchedulesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

The Get All Report Schedules API retrieves a list of all existing report schedules. This helps you to easily view and manage all scheduled reports in one place. 

<strong style="color: green;">Market availability: US only</strong>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ReportScheduler.GetAllReportSchedules(new GetAllReportSchedulesRequest
    {
        ReportType = ReportType10.Item,
        WmSvcName = "Walmart Marketplace",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
    });
    // TODO: Handle 'response' of type V3ReportsSchedulesResponse
}
catch (ApiException<RawError> ex)
{
    // TODO: Handle 'ex.Error' of type RawError
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetAllReportSchedulesRequest](src/WalmartApIs/Requests/ReportScheduler/GetAllReportSchedulesRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3ReportsSchedulesResponse](src/WalmartApIs/Models/V3ReportsSchedulesResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[RawError](src/WalmartApIs/Core/ErrorResponse/RawError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;V3ReportsSchedulesResponse1&gt; GetReportSchedule(GetReportScheduleRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This API retrieves the details of a single report schedule based on the specified scheduleId.

<strong style="color: green;">Market availability: US only</strong>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ReportScheduler.GetReportSchedule(new GetReportScheduleRequest
    {
        ScheduleId = "some example string",
        WmSvcName = "Walmart Marketplace",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
    });
    // TODO: Handle 'response' of type V3ReportsSchedulesResponse1
}
catch (ApiException<RawError> ex)
{
    // TODO: Handle 'ex.Error' of type RawError
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetReportScheduleRequest](src/WalmartApIs/Requests/ReportScheduler/GetReportScheduleRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3ReportsSchedulesResponse1](src/WalmartApIs/Models/V3ReportsSchedulesResponse1.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[RawError](src/WalmartApIs/Core/ErrorResponse/RawError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;V3ReportsSchedulesResponse1&gt; UpdateReportSchedule(UpdateReportScheduleRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This API allows you to modify an existing report schedule. You can change the parameters to better suit your needs, ensuring that reports are generated and delivered according to the most current requirements. 

<strong style="color: green;">Market availability: US only</strong>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ReportScheduler.UpdateReportSchedule(new UpdateReportScheduleRequest
    {
        ScheduleId = "some example string",
        WmSvcName = "Walmart Marketplace",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
    });
    // TODO: Handle 'response' of type V3ReportsSchedulesResponse1
}
catch (ApiException<RawError> ex)
{
    // TODO: Handle 'ex.Error' of type RawError
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[UpdateReportScheduleRequest](src/WalmartApIs/Requests/ReportScheduler/UpdateReportScheduleRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3ReportsSchedulesResponse1](src/WalmartApIs/Models/V3ReportsSchedulesResponse1.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[RawError](src/WalmartApIs/Core/ErrorResponse/RawError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## ReportsApi

> Source: [ReportsApi](src/WalmartApIs/Api/ReportsApi.cs)

<details>
<summary><code>Task&lt;ReconReportDateResponse&gt; GetAvailableReconReportDates(GetAvailableReconReportDatesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This API will list all the available Marketplace reconciliation report dates for the Seller.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ReportsApi.GetAvailableReconReportDates(new GetAvailableReconReportDatesRequest
    {
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
    });
    // TODO: Handle 'response' of type ReconReportDateResponse
}
catch (ApiException<RawError> ex)
{
    // TODO: Handle 'ex.Error' of type RawError
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetAvailableReconReportDatesRequest](src/WalmartApIs/Requests/ReportsApi/GetAvailableReconReportDatesRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ReconReportDateResponse](src/WalmartApIs/Models/ReconReportDateResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[RawError](src/WalmartApIs/Core/ErrorResponse/RawError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ReconReportV1AsJsonResponse&gt; GetAvailableV1ReconReportAsJson(GetAvailableV1ReconReportAsJsonRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This API will get a partner’s transaction details in JSON format for a specific date range (available only for v1 reports). Dates for accessing the report can be found by using the ‘GET Available recon report dates’ API.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ReportsApi.GetAvailableV1ReconReportAsJson(new GetAvailableV1ReconReportAsJsonRequest
    {
        ReportDate = "some example string",
        Offset = 1L,
        NoOfRecords = 1,
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
    });
    // TODO: Handle 'response' of type ReconReportV1AsJsonResponse
}
catch (ApiException<RawError> ex)
{
    // TODO: Handle 'ex.Error' of type RawError
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetAvailableV1ReconReportAsJsonRequest](src/WalmartApIs/Requests/ReportsApi/GetAvailableV1ReconReportAsJsonRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ReconReportV1AsJsonResponse](src/WalmartApIs/Models/ReconReportV1AsJsonResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[RawError](src/WalmartApIs/Core/ErrorResponse/RawError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ReconReportDateResponse&gt; GetAvailableV1ReconReportDates(GetAvailableV1ReconReportDatesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This API will list all the available Marketplace reconciliation report dates for the Seller.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ReportsApi.GetAvailableV1ReconReportDates(new GetAvailableV1ReconReportDatesRequest
    {
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
    });
    // TODO: Handle 'response' of type ReconReportDateResponse
}
catch (ApiException<RawError> ex)
{
    // TODO: Handle 'ex.Error' of type RawError
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetAvailableV1ReconReportDatesRequest](src/WalmartApIs/Requests/ReportsApi/GetAvailableV1ReconReportDatesRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ReconReportDateResponse](src/WalmartApIs/Models/ReconReportDateResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[RawError](src/WalmartApIs/Core/ErrorResponse/RawError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;PartnerProgramPerformanceRes&gt; GetPartnerPerformance(GetPartnerPerformanceRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This API will get a partner's current cycle performance

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ReportsApi.GetPartnerPerformance(new GetPartnerPerformanceRequest
    {
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
    });
    // TODO: Handle 'response' of type PartnerProgramPerformanceRes
}
catch (ApiException<RawError> ex)
{
    // TODO: Handle 'ex.Error' of type RawError
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetPartnerPerformanceRequest](src/WalmartApIs/Requests/ReportsApi/GetPartnerPerformanceRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[PartnerProgramPerformanceRes](src/WalmartApIs/Models/PartnerProgramPerformanceRes.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[RawError](src/WalmartApIs/Core/ErrorResponse/RawError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;PartnerProgramStatementRes&gt; GetPartnerStatement(GetPartnerStatementRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This API will get a partner's current cycle statement

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ReportsApi.GetPartnerStatement(new GetPartnerStatementRequest
    {
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
    });
    // TODO: Handle 'response' of type PartnerProgramStatementRes
}
catch (ApiException<RawError> ex)
{
    // TODO: Handle 'ex.Error' of type RawError
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetPartnerStatementRequest](src/WalmartApIs/Requests/ReportsApi/GetPartnerStatementRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[PartnerProgramStatementRes](src/WalmartApIs/Models/PartnerProgramStatementRes.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[RawError](src/WalmartApIs/Core/ErrorResponse/RawError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;BinaryContent&gt; GetReconReport(GetReconReportRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Seller can download the reconciliation report for a specific date using this API. Dates available to be downloaded can be found by using the Get available reconciliation report dates API.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ReportsApi.GetReconReport(new GetReconReportRequest
    {
        ReportDate = "some example string",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
    });
    // TODO: Handle 'response' of type BinaryContent
}
catch (ApiException<GetReconReportError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetReconReportRequest](src/WalmartApIs/Requests/ReportsApi/GetReconReportRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>BinaryContent</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetReconReportError](src/WalmartApIs/Errors/GetReconReportError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;BinaryContent&gt; GetReconReportV1(GetReconReportV1Request request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Seller can download the reconciliation report for a specific date using this API. Dates available to be downloaded can be found by using the Get available reconciliation report dates API.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ReportsApi.GetReconReportV1(new GetReconReportV1Request
    {
        ReportDate = "some example string",
        ReportVersion = "some example string",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
    });
    // TODO: Handle 'response' of type BinaryContent
}
catch (ApiException<GetReconReportV1Error> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetReconReportV1Request](src/WalmartApIs/Requests/ReportsApi/GetReconReportV1Request.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>BinaryContent</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetReconReportV1Error](src/WalmartApIs/Errors/GetReconReportV1Error.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## ReturnsRefund

> Source: [ReturnsRefund](src/WalmartApIs/Api/ReturnsRefund.cs)

<details>
<summary><code>Task&lt;ReturnOrderResponse&gt; GetReturns(GetReturnsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Retrieves the details of all return orders for the specified filter criteria.

<br><b style='color:green;'>Market availability: Global</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ReturnsRefund.GetReturns(new GetReturnsRequest
    {
        QueryParams = new QueryParams(),
        WmQosCorrelationId = "some example string",
        WmSvcName = "some example string",
        WmMarket = WmMarket1.Us,
        WmGlobalVersion = WmGlobalVersion._31,
    });
    // TODO: Handle 'response' of type ReturnOrderResponse
}
catch (ApiException<GetReturnsError> ex)
{
    if (ex.Error.TryGetErrorResponse3(out var error))
    {
        // TODO: Handle 'error' of type ErrorResponse3
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetReturnsRequest](src/WalmartApIs/Requests/ReturnsRefund/GetReturnsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ReturnOrderResponse](src/WalmartApIs/Models/ReturnOrderResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetReturnsError](src/WalmartApIs/Errors/GetReturnsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;RequestModel&gt; RefundRequest(RefundRequestOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Refunds one or more order lines that have been shipped. The response to a successful call contains the order with the refunded line item. 

<br><b style='color:green;'>Market availability: US | MX</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ReturnsRefund.RefundRequest(new RefundRequestOperationRequest
    {
        ReturnOrderId = "some example string",
        WmQosCorrelationId = "some example string",
        WmSvcName = "some example string",
        WmMarket = WmMarket3.Us,
        WmGlobalVersion = WmGlobalVersion._31,
        Body = new RefundRequest
        {
            CustomerOrderId = "some example string",
            RefundLines = [
                new RefundLine
                {
                    ReturnOrderLineNumber = 1,
                    Quantity = new Quantity { UnitOfMeasure = "some example string", MeasurementValue = 1 },
                },
            ],
            OrderRefund = new OrderRefund(),
        },
    });
    // TODO: Handle 'response' of type RequestModel
}
catch (ApiException<RefundRequestError> ex)
{
    if (ex.Error.TryGetErrorResponse3(out var error))
    {
        // TODO: Handle 'error' of type ErrorResponse3
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[RefundRequestOperationRequest](src/WalmartApIs/Requests/ReturnsRefund/RefundRequestOperationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[RequestModel](src/WalmartApIs/Models/RequestModel.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[RefundRequestError](src/WalmartApIs/Errors/RefundRequestError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ReturnOrdersResponses&gt; ReturnOrderCursor(ReturnOrderCursorRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This API retrieves the details of all return orders based on the specified filter criteria and returns all orders in the response. It returns a nextCursorMark for the next 100 orders, and continues in this manner until the last order. The same API can also be used to search for a single order based on returnOrderId or customerOrderId.<br><b style='color:green;'>Market availability: MX</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ReturnsRefund.ReturnOrderCursor(new ReturnOrderCursorRequest
    {
        QueryParams = new QueryParamsMx(),
        WmQosCorrelationId = "some example string",
        WmSvcName = "some example string",
        WmMarket = WmMarket21.Mx,
        WmGlobalVersion = WmGlobalVersion._31,
    });
    // TODO: Handle 'response' of type ReturnOrdersResponses
}
catch (ApiException<ReturnOrderCursorError> ex)
{
    if (ex.Error.TryGetErrorResponse3(out var error))
    {
        // TODO: Handle 'error' of type ErrorResponse3
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ReturnOrderCursorRequest](src/WalmartApIs/Requests/ReturnsRefund/ReturnOrderCursorRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ReturnOrdersResponses](src/WalmartApIs/Models/ReturnOrdersResponses.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[ReturnOrderCursorError](src/WalmartApIs/Errors/ReturnOrderCursorError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Reviews

> Source: [Reviews](src/WalmartApIs/Api/Reviews.cs)

<details>
<summary><code>Task&lt;V3GrowthReviewsAcceleratorItemsStatusResponse&gt; BulkUpdateItemStatus(BulkUpdateItemStatusRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Use this API to enroll or disenroll items in the Review Accelerator Program (RAP).<br><b style='color:green;'>Market availability: US only</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Reviews.BulkUpdateItemStatus(new BulkUpdateItemStatusRequest
    {
        WmGlobalVersion = WmGlobalVersion._31,
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Marketplace",
        WmMarket = WmMarket1.Us,
        Body = new V3GrowthReviewsAcceleratorItemsStatusRequest
        {
            Status = Status11.Enroll,
            Items = [new Item9 { ItemId = "2719243" }, new Item9 { ItemId = "2719255" }],
        },
    });
    // TODO: Handle 'response' of type V3GrowthReviewsAcceleratorItemsStatusResponse
}
catch (ApiException<BulkUpdateItemStatusError> ex)
{
    if (ex.Error.TryGetV3GrowthReviewsAcceleratorItemsStatus400Error1(out var error))
    {
        // TODO: Handle 'error' of type V3GrowthReviewsAcceleratorItemsStatus400Error1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[BulkUpdateItemStatusRequest](src/WalmartApIs/Requests/Reviews/BulkUpdateItemStatusRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3GrowthReviewsAcceleratorItemsStatusResponse](src/WalmartApIs/Models/V3GrowthReviewsAcceleratorItemsStatusResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[BulkUpdateItemStatusError](src/WalmartApIs/Errors/BulkUpdateItemStatusError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;V3GrowthReviewsAcceleratorCategoriesResponse&gt; GetIrpCategories(GetIrpCategoriesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Use this API to get the set of categories the RAP post-purchase items belong to.<br><b style='color:green;'>Market availability: US only</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Reviews.GetIrpCategories(new GetIrpCategoriesRequest
    {
        WmGlobalVersion = WmGlobalVersion._31,
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Marketplace",
        WmMarket = WmMarket1.Us,
        Body = new V3GrowthReviewsAcceleratorCategoriesRequest(),
    });
    // TODO: Handle 'response' of type V3GrowthReviewsAcceleratorCategoriesResponse
}
catch (ApiException<GetIrpCategoriesError> ex)
{
    if (ex.Error.TryGetV3GrowthReviewsAcceleratorCategories400Error1(out var error))
    {
        // TODO: Handle 'error' of type V3GrowthReviewsAcceleratorCategories400Error1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetIrpCategoriesRequest](src/WalmartApIs/Requests/Reviews/GetIrpCategoriesRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3GrowthReviewsAcceleratorCategoriesResponse](src/WalmartApIs/Models/V3GrowthReviewsAcceleratorCategoriesResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetIrpCategoriesError](src/WalmartApIs/Errors/GetIrpCategoriesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;V3GrowthReviewsAcceleratorItemsResponse&gt; GetIrpItems(GetIrpItemsOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

To get all eligible products that can be enrolled in the Reviews Accelerator post-purchase program, as well as to retrieve all products currently enrolled in the program, and all products that have attained target reviews after enrollment, you can use the following criteria:
<li>Filter products by category and price.
<li>Sort products by Walmart-recommended item priorities.
<li>Search using wildcards to match the product name and SKU.<br><b style='color:green;'>Market availability: US only</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Reviews.GetIrpItems(new GetIrpItemsOperationRequest
    {
        ScrollId = "some example string",
        WmGlobalVersion = WmGlobalVersion._31,
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Marketplace",
        WmMarket = WmMarket1.Us,
        Body = new V3GrowthReviewsAcceleratorItemsRequest
        {
            Filter = new Filter1 { ItemStatus = ItemStatus8.Eligible },
        },
    });
    // TODO: Handle 'response' of type V3GrowthReviewsAcceleratorItemsResponse
}
catch (ApiException<GetIrpItemsError> ex)
{
    if (ex.Error.TryGetV3GrowthReviewsAcceleratorItems400Error1(out var error))
    {
        // TODO: Handle 'error' of type V3GrowthReviewsAcceleratorItems400Error1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetIrpItemsOperationRequest](src/WalmartApIs/Requests/Reviews/GetIrpItemsOperationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3GrowthReviewsAcceleratorItemsResponse](src/WalmartApIs/Models/V3GrowthReviewsAcceleratorItemsResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetIrpItemsError](src/WalmartApIs/Errors/GetIrpItemsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## RichMedia

> Source: [RichMedia](src/WalmartApIs/Api/RichMedia.cs)

<details>
<summary><code>Task&lt;AssetsResponse&gt; GetAllAssets(GetAllAssetsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Use this API to retrieve rich media assets, including 360-spin images and videos, from the seller catalog. Assets can be created in seller center media library or programmatically through the API. Use this endpoint to retrieve the asset hash, which uniquely identifies each media asset for future management.

<b style="color: green;">Market availability: US only</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.RichMedia.GetAllAssets(new GetAllAssetsRequest
    {
        Page = 1,
        Limit = 25,
        LinkedGtins = ["00716999676446", "07815386164856"],
        RichMediaTitle = "title",
        RichMediaType = RichMediaType.Video,
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Marketplace",
    });
    // TODO: Handle 'response' of type AssetsResponse
}
catch (ApiException<GetAllAssetsError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetAllAssetsRequest](src/WalmartApIs/Requests/RichMedia/GetAllAssetsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[AssetsResponse](src/WalmartApIs/Models/AssetsResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetAllAssetsError](src/WalmartApIs/Errors/GetAllAssetsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;FeedId1&gt; RichMediaOperation(RichMediaOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Use this API to create, update, or delink rich media assets for items in the seller catalog. Supported asset types are `IMAGES360` and `VIDEO`. Use this API to 1) add new rich media, 2) update associations for existing rich media, or 3) delink item association on existing rich media. Provide accessible media URLs and related metadata in the request body. Video assets require one video URL. 360-spin image assets require 24 image URLs.

<b style="color: green;">Market availability: US only</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.RichMedia.RichMediaOperation(new RichMediaOperationRequest
    {
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Marketplace",
        Body = new RichMediaFeedRequest
        {
            SupplierItemFeedHeader = new SupplierItemFeedHeader
            {
                Locale = "some example string",
                Version = "some example string",
                SubCategory = SubCategory.Video,
            },
            SupplierItem = [
                new SupplierItemPayload
                {
                    Orderable = new SupplierItemOrderable { ProductId = "some example string" },
                    Visible = new VisibleVideoPayload(),
                },
            ],
        },
    });
    // TODO: Handle 'response' of type FeedId1
}
catch (ApiException<RichMediaOperationError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[RichMediaOperationRequest](src/WalmartApIs/Requests/RichMedia/RichMediaOperationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[FeedId1](src/WalmartApIs/Models/FeedId1.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[RichMediaOperationError](src/WalmartApIs/Errors/RichMediaOperationError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## SemCampaignManagement

> Source: [SemCampaignManagement](src/WalmartApIs/Api/SemCampaignManagement.cs)

<details>
<summary><code>Task&lt;SemCampaignResponse&gt; CreateCampaign(CreateCampaignRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This API allows you to create a new campaign by providing the required details in the request. Upon successful creation, a unique campaign ID will be assigned to the newly created campaign for identification and management purposes.<br><b style='color:green;'>Market availability: US only</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.SemCampaignManagement.CreateCampaign(new CreateCampaignRequest
    {
        WmSecAccessToken = "eyJraWQiOiIxNWNhNGIyYi0yODVjLTQ0ZDUtYmExNC05ZDk1NTlkZmUwNjgiLCJlbmMiOiJBMjU2R0NNIiwiYWxnIjoiZGlyIn0....",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Marketplace",
        Body = new SemCampaignCreateRequest
        {
            Metadata = new SemCampaignCreateMetadata
            {
                Name = "some example string",
                StartDate = "some example string",
                DailyBudget = 1.5d,
            },
            ItemsOperations = [
                new SemCampaignItemsOperation { OperationType = OperationType.Add, Skus = ["some example string"] },
            ],
        },
    });
    // TODO: Handle 'response' of type SemCampaignResponse
}
catch (ApiException<CreateCampaignError> ex)
{
    if (ex.Error.TryGetSemErrorResponse400(out var error))
    {
        // TODO: Handle 'error' of type SemErrorResponse400
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateCampaignRequest](src/WalmartApIs/Requests/SemCampaignManagement/CreateCampaignRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[SemCampaignResponse](src/WalmartApIs/Models/SemCampaignResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[CreateCampaignError](src/WalmartApIs/Errors/CreateCampaignError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;SemCampaignResponse&gt; DeleteCampaign(DeleteCampaignRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This API allows you to permanently remove an existing campaign from the system. Once deleted, the campaign and its unique ID will no longer be retrievable. The campaign's unique ID must be included in the request.<br><b style='color:green;'>Market availability: US only</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.SemCampaignManagement.DeleteCampaign(new DeleteCampaignRequest
    {
        CampaignId = "some example string",
        WmSecAccessToken = "eyJraWQiOiIxNWNhNGIyYi0yODVjLTQ0ZDUtYmExNC05ZDk1NTlkZmUwNjgiLCJlbmMiOiJBMjU2R0NNIiwiYWxnIjoiZGlyIn0....",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Marketplace",
    });
    // TODO: Handle 'response' of type SemCampaignResponse
}
catch (ApiException<DeleteCampaignError> ex)
{
    if (ex.Error.TryGetSemErrorResponse400(out var error))
    {
        // TODO: Handle 'error' of type SemErrorResponse400
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[DeleteCampaignRequest](src/WalmartApIs/Requests/SemCampaignManagement/DeleteCampaignRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[SemCampaignResponse](src/WalmartApIs/Models/SemCampaignResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[DeleteCampaignError](src/WalmartApIs/Errors/DeleteCampaignError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;SemCampaign&gt; GetCampaignDetails(GetCampaignDetailsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This API allows you to retrieve detailed information about a specific campaign. Provide the campaign's unique ID in the request to fetch its attributes.<br><b style='color:green;'>Market availability: US only</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.SemCampaignManagement.GetCampaignDetails(new GetCampaignDetailsRequest
    {
        CampaignId = "some example string",
        WmSecAccessToken = "eyJraWQiOiIxNWNhNGIyYi0yODVjLTQ0ZDUtYmExNC05ZDk1NTlkZmUwNjgiLCJlbmMiOiJBMjU2R0NNIiwiYWxnIjoiZGlyIn0....",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Marketplace",
    });
    // TODO: Handle 'response' of type SemCampaign
}
catch (ApiException<GetCampaignDetailsError> ex)
{
    if (ex.Error.TryGetSemErrorResponse400(out var error))
    {
        // TODO: Handle 'error' of type SemErrorResponse400
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetCampaignDetailsRequest](src/WalmartApIs/Requests/SemCampaignManagement/GetCampaignDetailsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[SemCampaign](src/WalmartApIs/Models/SemCampaign.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetCampaignDetailsError](src/WalmartApIs/Errors/GetCampaignDetailsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CampaignRecommendationsSearchResponse&gt; SearchCampaignRecommendations(SearchCampaignRecommendationsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Search for campaign-level recommendations to improve SEM campaign performance. Returns a paginated list of active campaigns for the authenticated seller, each enriched with actionable recommendations — including budget adjustments and bidding strategy optimizations — along with projected performance impact metrics (clicks, impressions, ad spend).<br><b style='color:green;'>Market availability: US only</b>

### Why this API matters
SEM campaigns require continuous optimization to stay competitive. Budget constraints and suboptimal bidding strategies are the two most common reasons campaigns underperform. Without data-driven guidance, sellers either overspend without results or miss revenue opportunities by underspending.

This API bridges that gap by surfacing **machine-generated recommendations** for each active campaign, complete with projected impact on clicks, impressions, and ad spend. Partners can integrate these recommendations into their dashboards and automation pipelines to:
- **Increase ROAS**: Apply budget and bidding strategy recommendations to maximize return on ad spend
- **Reduce wasted spend**: Identify campaigns where budget is being underutilized or misallocated
- **Automate campaign tuning**: Build automated workflows that periodically fetch recommendations and apply them programmatically, reducing manual effort and reaction time
- **Enable data-driven decisions**: Each recommendation includes three impact scenarios (recommended, conservative, aggressive) so sellers can choose the option that fits their risk tolerance

### Key use cases
1. **Campaign Health Dashboard**: Display campaigns with pending recommendations, color-coded by type (`BUDGET` vs `BIDDING_STRATEGY`), with projected impact metrics
2. **Automated Budget Optimizer**: Periodically poll this API and auto-apply budget recommendations that meet a minimum projected ROAS threshold
3. **Bidding Strategy Advisor**: Surface bidding strategy change suggestions to sellers with before/after performance projections
4. **Bulk Campaign Management**: Retrieve all recommendations across campaigns in a single paginated call, enabling batch review and bulk application of changes

### How it works
The API returns only active campaigns that are eligible for recommendations. You can filter results using `campaignIds` or `recommendationType` (`BUDGET` or `BIDDING_STRATEGY`).

### Default behavior
- When no request body is provided, the API defaults to `offset=0`, `limit=10`.
- By default, the API returns recommendations for both `BUDGET` and `BIDDING_STRATEGY`.
- Results are not sorted by default; use the sort object to order by adspend.
- Returns only **active campaigns** that have at least one pending recommendation
- Results are not sorted by default; use the `sort` object to order by `adspend`

### Supported filters
Filters are combined with AND logic. Multiple values within a single filter act as OR.

| Filter Field              | Supported Values              | Description                                              |
|---------------------------|-------------------------------|----------------------------------------------------------|
| `campaignIds`             | Numeric string campaign IDs   | Filter by specific campaign identifiers                  |
| `recommendationType`  | `BUDGET`, `BIDDING_STRATEGY`  | Filter by recommendation type                            |

### Sorting
Results can be sorted using the `sort` object:

| Sort Field | Supported Orders | Description                              |
|------------|------------------|------------------------------------------|
| `adspend`  | `ASC`, `DESC`    | Sort campaigns by ad spend               |

### Recommendation types
| Type               | Description                                                              |
|--------------------|--------------------------------------------------------------------------|
| `BUDGET`           | Recommended total or daily budget adjustment to improve campaign reach    |
| `BIDDING_STRATEGY` | Recommended change to bidding strategy for better performance            |

### Response structure
Each response contains two top-level fields:
- `pagination`: Standard pagination metadata (`pageNo`, `pageSize`, `totalCount`, `totalPages`, `hasNextPage`, `hasPreviousPage`)
- `data`: Array of campaign-level suggestions. Each campaign includes current settings (bidding strategy, target ROAS, daily budget) and an array of `campaignRecommendations` with projected performance impact at three levels: recommended, minimum, and maximum.

### Performance impact projections
Each recommendation includes a `recommendedValueImpact` object with up to three scenarios:
- **recommended**: The optimal suggested value (marked `isRecommended: true`)
- **minRecommendation**: A conservative lower-bound option (may be `null` if not applicable)
- **maxRecommendation**: An aggressive upper-bound option

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.SemCampaignManagement.SearchCampaignRecommendations(
        new SearchCampaignRecommendationsRequest
        {
            WmSvcName = "Walmart Marketplace",
            WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
            WmGlobalVersion = WmGlobalVersion._31,
            WmMarket = WmMarket.Us,
            Accept = Accept.ApplicationJson,
            Body = new CampaignRecommendationsSearchRequest
            {
                Page = new CampaignRecommendationsPage { Offset = 0, Limit = 10 },
            },
        });
    // TODO: Handle 'response' of type CampaignRecommendationsSearchResponse
}
catch (ApiException<SearchCampaignRecommendationsError> ex)
{
    if (ex.Error.TryGetErrorResponseModel(out var error))
    {
        // TODO: Handle 'error' of type ErrorResponseModel
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[SearchCampaignRecommendationsRequest](src/WalmartApIs/Requests/SemCampaignManagement/SearchCampaignRecommendationsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CampaignRecommendationsSearchResponse](src/WalmartApIs/Models/CampaignRecommendationsSearchResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[SearchCampaignRecommendationsError](src/WalmartApIs/Errors/SearchCampaignRecommendationsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;SemCampaignResponse&gt; StopCampaign(StopCampaignRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This API allows you to stop an active campaign. Stopping a campaign does not delete it but prevents further actions. The campaign's unique ID must be included in the request.<br><b style='color:green;'>Market availability: US only</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.SemCampaignManagement.StopCampaign(new StopCampaignRequest
    {
        CampaignId = "some example string",
        WmSecAccessToken = "eyJraWQiOiIxNWNhNGIyYi0yODVjLTQ0ZDUtYmExNC05ZDk1NTlkZmUwNjgiLCJlbmMiOiJBMjU2R0NNIiwiYWxnIjoiZGlyIn0....",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Marketplace",
    });
    // TODO: Handle 'response' of type SemCampaignResponse
}
catch (ApiException<StopCampaignError> ex)
{
    if (ex.Error.TryGetSemErrorResponse400(out var error))
    {
        // TODO: Handle 'error' of type SemErrorResponse400
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[StopCampaignRequest](src/WalmartApIs/Requests/SemCampaignManagement/StopCampaignRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[SemCampaignResponse](src/WalmartApIs/Models/SemCampaignResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[StopCampaignError](src/WalmartApIs/Errors/StopCampaignError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;SemCampaignResponse&gt; UpdateCampaign(UpdateCampaignRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This API allows you to modify an existing campaign's details and manage its associated items. You must provide the campaign's unique ID along with the necessary changes in the request. The specified updates will be applied while preserving the campaign's unique identifier.<br><b style='color:green;'>Market availability: US only</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.SemCampaignManagement.UpdateCampaign(new UpdateCampaignRequest
    {
        CampaignId = "some example string",
        WmSecAccessToken = "eyJraWQiOiIxNWNhNGIyYi0yODVjLTQ0ZDUtYmExNC05ZDk1NTlkZmUwNjgiLCJlbmMiOiJBMjU2R0NNIiwiYWxnIjoiZGlyIn0....",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Marketplace",
        Body = new SemCampaignUpdateRequest(),
    });
    // TODO: Handle 'response' of type SemCampaignResponse
}
catch (ApiException<UpdateCampaignError> ex)
{
    if (ex.Error.TryGetSemErrorResponse400(out var error))
    {
        // TODO: Handle 'error' of type SemErrorResponse400
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[UpdateCampaignRequest](src/WalmartApIs/Requests/SemCampaignManagement/UpdateCampaignRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[SemCampaignResponse](src/WalmartApIs/Models/SemCampaignResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[UpdateCampaignError](src/WalmartApIs/Errors/UpdateCampaignError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## SemCatalog

> Source: [SemCatalog](src/WalmartApIs/Api/SemCatalog.cs)

<details>
<summary><code>Task&lt;SemCatalogueResponse&gt; GetEligibleItems(GetEligibleItemsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This API allows you to check whether an item from your catalog meets the required conditions for Search Engine Marketing ads.<br><b style='color:green;'>Market availability: US only</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.SemCatalog.GetEligibleItems(new GetEligibleItemsRequest
    {
        WmSecAccessToken = "eyJraWQiOiIxNWNhNGIyYi0yODVjLTQ0ZDUtYmExNC05ZDk1NTlkZmUwNjgiLCJlbmMiOiJBMjU2R0NNIiwiYWxnIjoiZGlyIn0....",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Marketplace",
        Body = new SemItemEligibilityRequest
        {
            Filters = [new SemFilter { Field = "some example string", Values = ["some example string"] }],
        },
    });
    // TODO: Handle 'response' of type SemCatalogueResponse
}
catch (ApiException<GetEligibleItemsError> ex)
{
    if (ex.Error.TryGetSemErrorResponse400(out var error))
    {
        // TODO: Handle 'error' of type SemErrorResponse400
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetEligibleItemsRequest](src/WalmartApIs/Requests/SemCatalog/GetEligibleItemsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[SemCatalogueResponse](src/WalmartApIs/Models/SemCatalogueResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetEligibleItemsError](src/WalmartApIs/Errors/GetEligibleItemsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;SemCatalogueResponse&gt; GetItemRecommendations(GetItemRecommendationsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This API allows you to fetch a list of top recommended items from your catalog. You can customize the number of recommendations to be returned by adjusting the request parameter.<br><b style='color:green;'>Market availability: US only</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.SemCatalog.GetItemRecommendations(new GetItemRecommendationsRequest
    {
        WmSecAccessToken = "eyJraWQiOiIxNWNhNGIyYi0yODVjLTQ0ZDUtYmExNC05ZDk1NTlkZmUwNjgiLCJlbmMiOiJBMjU2R0NNIiwiYWxnIjoiZGlyIn0....",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Marketplace",
    });
    // TODO: Handle 'response' of type SemCatalogueResponse
}
catch (ApiException<GetItemRecommendationsError> ex)
{
    if (ex.Error.TryGetSemErrorResponse400(out var error))
    {
        // TODO: Handle 'error' of type SemErrorResponse400
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetItemRecommendationsRequest](src/WalmartApIs/Requests/SemCatalog/GetItemRecommendationsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[SemCatalogueResponse](src/WalmartApIs/Models/SemCatalogueResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetItemRecommendationsError](src/WalmartApIs/Errors/GetItemRecommendationsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## SemItemDiagnostics

> Source: [SemItemDiagnostics](src/WalmartApIs/Api/SemItemDiagnostics.cs)

<details>
<summary><code>Task&lt;IReadOnlyDictionary&lt;string, IssueMetadata&gt;&gt; GetIssueTypes(GetIssueTypesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the complete, authoritative metadata for all SEM eligibility issue types (~61 issue types, ~5KB).<br><b style='color:green;'>Market availability: US only</b>

Items used in Search Engine Marketing (SEM) campaigns such as Google Shopping Ads must meet specific content, quality, and policy requirements before they can be advertised on search engines. When items fail to meet these requirements, they are flagged with specific issue types that either **block** the item from being advertised entirely or **limit** its visibility and performance in SEM.

This endpoint returns the complete catalog of all issue types that can affect an item's SEM eligibility, along with human-readable names, descriptions, remediation guidance, severity categories, and help links. It serves as the **single source of truth** for issue metadata.

### Current scope
The issue types returned by this endpoint apply to items that are currently part of active SEM campaigns. The `POST /item-issues/search` endpoint uses these issue types to report diagnostics on campaign items.

### Future extensibility
In a future release, the `POST /item-issues/search` endpoint will support querying diagnostic issues for any item in the seller's catalog — even items not yet added to a campaign — using the `itemId` filter. The same issue types returned by this endpoint will apply to those items as well, enabling sellers to proactively diagnose and fix issues before campaign onboarding.

### SEM eligibility issue categories
Each issue type belongs to one of three categories that indicate its impact on an item's ability to be advertised on search engines:

| Category     | Count | SEM Impact                                                                     |
|--------------|-------|--------------------------------------------------------------------------------|
| `BLOCKED`    | ~49   | Item **cannot be advertised** on search engines. Must be resolved before the item can appear in SEM ads. Examples: `ITEM_OUT_OF_STOCK`, `POLICY_VIOLATION`, `MISSING_INVALID_TITLE`, `INVALID_IMAGE`, `BUYBOX_NOT_WINNER` |
| `LIMITED`    | ~11   | Item **can be advertised but with reduced visibility** or performance on search engines. Resolving these issues improves ad reach and effectiveness. Examples: `TITLE_TOO_LONG`, `LOW_IMAGE_QUALITY`, `DESCRIPTION_TOO_SHORT`, `LOW_OFFER_LISTING_QUALITY` |
| `NO_ISSUES`  | ~1    | Informational statuses such as `DUPLICATE_OFFER` — item has no SEM eligibility issues |

### Actionable vs non-actionable issues
Each issue type includes an `isFixable` flag that indicates whether the seller can resolve the issue:
- `isFixable=true`: Seller can take action to restore or improve SEM eligibility (For example, restock inventory, update title, improve image quality). Partners should surface these with a "Fix Now" UI affordance.
- `isFixable=false`: Requires Walmart or system intervention (For example, Google policy violations, BuyBox eligibility). Partners should display these as informational — the seller cannot directly resolve them.

### Response structure
The response is a map keyed by `issueType` (string), where each value is an `IssueMetadata` object containing:
- `issueName`: Human-readable short headline for UI display (For example, "Item Out of Stock")
- `issueCategory`: SEM eligibility impact — `BLOCKED` (cannot advertise on search engines) or `LIMITED` (reduced SEM visibility)
- `isFixable`: Whether the partner can remediate this issue to restore SEM eligibility
- `issueDescription`: Human-readable description with specific remediation guidance (For example, "Item is out of stock. Add inventory to make the item available.")
- `learnMoreUrl`: Help link to Walmart-hosted or Google support documentation for step-by-step remediation. May be null for some issue types.

### Recommended usage pattern
1. Call this endpoint **once** on application initialization
2. Cache the result locally (recommended **TTL: 24 hours**)
3. Use cached metadata to enrich items returned by the `POST /item-issues/search` endpoint — match each item's `issueType` to the cached metadata for display name, description, and help links
4. Use `isFixable` to drive UI affordances: show "Fix Now" buttons for fixable SEM issues, informational badges for non-fixable ones
5. Use `learnMoreUrl` to deep-link to help documentation for step-by-step remediation guidance
6. Use `issueCategory` to color-code or badge issues in your UI: red for `BLOCKED` (cannot advertise), yellow for `LIMITED` (reduced SEM performance)

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.SemItemDiagnostics.GetIssueTypes(new GetIssueTypesRequest
    {
        WmSvcName = "Walmart Marketplace",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmGlobalVersion = WmGlobalVersion._31,
        WmMarket = WmMarket.Us,
    });
    // TODO: Handle 'response' of type IReadOnlyDictionary<string, IssueMetadata>
}
catch (ApiException<GetIssueTypesError> ex)
{
    if (ex.Error.TryGetErrorResponseModel(out var error))
    {
        // TODO: Handle 'error' of type ErrorResponseModel
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetIssueTypesRequest](src/WalmartApIs/Requests/SemItemDiagnostics/GetIssueTypesRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>IReadOnlyDictionary&lt;string, [IssueMetadata](src/WalmartApIs/Models/IssueMetadata.cs)&gt;</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetIssueTypesError](src/WalmartApIs/Errors/GetIssueTypesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ItemDiagnosticSearchResponse&gt; SearchItemIssues(SearchItemIssuesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Search for item-level diagnostic issues that block or limit items from being used in Search Engine Marketing (SEM). Returns paginated, item-level diagnostic details including campaign associations, issue types, severity, remediation guidance, and overall item status.<br><b style='color:green;'>Market availability: US only</b>

Items in SEM campaigns must meet content, quality, and policy requirements before they can be advertised on search engines (For example, Google Shopping Ads). This endpoint surfaces the specific issues preventing or limiting an item's SEM eligibility, along with actionable remediation guidance so sellers can resolve problems and restore advertising reach.

### Current scope
This endpoint currently returns diagnostics for **items that are part of active SEM campaigns** for the authenticated seller. Each item in the response includes its `campaignAssociations` — the list of campaigns the item belongs to. Items not associated with any campaign are not included in the results.

### Default behavior
- When no request body is provided, defaults to `offset=0`, `limit=100` with no filters
- When no `issueCategory` filter is provided, returns **only items with issues** (`BLOCKED` or `LIMITED`)
- To include healthy items, explicitly pass `issueCategory` filter with `NO_ISSUES` or all three values
- By default, the API prioritizes returning actionable diagnostic issues rather than healthy items. This reduces payload size and improves relevance

### Supported filters
Filters are combined with AND logic. Multiple values within a single filter act as OR.

| Filter Field    | Supported Values                          | Max Values | Description                                              |
|-----------------|-------------------------------------------|------------|----------------------------------------------------------|
| `issues`        | Any valid `issueType` enum value          | 100        | Filter by specific SEM issue types (For example, `ITEM_OUT_OF_STOCK`, `TITLE_TOO_LONG`, `POLICY_VIOLATION`) |
| `issueCategory` | `LIMITED`, `BLOCKED`, `NO_ISSUES`         | 100        | Filter by SEM issue severity — `BLOCKED` items cannot be advertised at all, `LIMITED` items have reduced SEM performance |
| `itemId`        | Numeric string item IDs                   | 100        | Filter by Walmart catalog item identifiers within the seller's active campaigns. *In a future release, this filter will also support items outside of campaigns.* |

### Response structure
Each response contains two top-level fields:
- `pagination`: Standard pagination metadata including `hasNextPage`/`hasPreviousPage` for convenient UI navigation
- `data`: Array of item-level diagnostics. Each item appears **once** per unique `offerId` with all campaign associations listed. Each item includes an `issueCategory` field representing the overall SEM eligibility status of the item, and an `issues` array containing issue type identifiers. Issues are item-level, not campaign-specific — a blocked item is blocked in all SEM campaigns it belongs to.

Issue metadata (name, description, fixability, help links) is not included in this response. Partners should use the dedicated `GET /item-issues/issue-types` endpoint to retrieve complete issue metadata and cache it locally (TTL: 24 hours).

### Issue categories
| Category     | SEM Impact                                                                     |
|--------------|--------------------------------------------------------------------------------|
| `BLOCKED`    | Item **cannot be advertised** on search engines. Must be resolved before the item can appear in SEM ads. Examples: out of stock, missing title, policy violation, invalid image. |
| `LIMITED`    | Item **can be advertised but with reduced visibility** or performance on search engines. Resolving these issues improves ad reach and effectiveness. Examples: title too long, low image quality, description too short. |
| `NO_ISSUES`  | Item has no SEM issues and can be advertised normally with full visibility.      |

### Actionable vs non-actionable issues
Each issue type has an `isFixable` flag available via the `GET /item-issues/issue-types` reference endpoint:
- `isFixable=true`: Seller can fix the issue to restore SEM eligibility (For example, restock inventory, update title, fix image). Partners should surface these with a "Fix Now" UI affordance.
- `isFixable=false`: Requires Walmart or system intervention (For example, Google policy violations). Partners should display these as informational — the seller cannot directly resolve them.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.SemItemDiagnostics.SearchItemIssues(new SearchItemIssuesRequest
    {
        WmSvcName = "Walmart Marketplace",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmGlobalVersion = WmGlobalVersion._31,
        WmMarket = WmMarket.Us,
        Accept = Accept.ApplicationJson,
        Body = new ItemDiagnosticSearchRequest { Page = new DiagnosticPage { Offset = 0, Limit = 20 } },
    });
    // TODO: Handle 'response' of type ItemDiagnosticSearchResponse
}
catch (ApiException<SearchItemIssuesError> ex)
{
    if (ex.Error.TryGetErrorResponseModel(out var error))
    {
        // TODO: Handle 'error' of type ErrorResponseModel
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[SearchItemIssuesRequest](src/WalmartApIs/Requests/SemItemDiagnostics/SearchItemIssuesRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ItemDiagnosticSearchResponse](src/WalmartApIs/Models/ItemDiagnosticSearchResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[SearchItemIssuesError](src/WalmartApIs/Errors/SearchItemIssuesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## SemReporting

> Source: [SemReporting](src/WalmartApIs/Api/SemReporting.cs)

<details>
<summary><code>Task&lt;SemBillingHistoryResponse&gt; GetBillingHistory(GetBillingHistoryRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This API allows you to fetch your billing history.<br><b style='color:green;'>Market availability: US only</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.SemReporting.GetBillingHistory(new GetBillingHistoryRequest
    {
        WmSecAccessToken = "eyJraWQiOiIxNWNhNGIyYi0yODVjLTQ0ZDUtYmExNC05ZDk1NTlkZmUwNjgiLCJlbmMiOiJBMjU2R0NNIiwiYWxnIjoiZGlyIn0....",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Marketplace",
    });
    // TODO: Handle 'response' of type SemBillingHistoryResponse
}
catch (ApiException<GetBillingHistoryError> ex)
{
    if (ex.Error.TryGetSemErrorResponse400(out var error))
    {
        // TODO: Handle 'error' of type SemErrorResponse400
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetBillingHistoryRequest](src/WalmartApIs/Requests/SemReporting/GetBillingHistoryRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[SemBillingHistoryResponse](src/WalmartApIs/Models/SemBillingHistoryResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetBillingHistoryError](src/WalmartApIs/Errors/GetBillingHistoryError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;SemCampaignLevelReportResponse&gt; GetCampaignLevelSummary(GetCampaignLevelSummaryRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This API allows you to fetch comprehensive performance metrics for all campaigns, allowing you to analyze key performance indicators based on specified filtering and sorting criteria.<br><b style='color:green;'>Market availability: US only</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.SemReporting.GetCampaignLevelSummary(new GetCampaignLevelSummaryRequest
    {
        WmSecAccessToken = "eyJraWQiOiIxNWNhNGIyYi0yODVjLTQ0ZDUtYmExNC05ZDk1NTlkZmUwNjgiLCJlbmMiOiJBMjU2R0NNIiwiYWxnIjoiZGlyIn0....",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Marketplace",
    });
    // TODO: Handle 'response' of type SemCampaignLevelReportResponse
}
catch (ApiException<GetCampaignLevelSummaryError> ex)
{
    if (ex.Error.TryGetSemErrorResponse400(out var error))
    {
        // TODO: Handle 'error' of type SemErrorResponse400
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetCampaignLevelSummaryRequest](src/WalmartApIs/Requests/SemReporting/GetCampaignLevelSummaryRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[SemCampaignLevelReportResponse](src/WalmartApIs/Models/SemCampaignLevelReportResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetCampaignLevelSummaryError](src/WalmartApIs/Errors/GetCampaignLevelSummaryError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;SemItemLevelReportResponse&gt; GetItemLevelSummary(GetItemLevelSummaryRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This API allows you to fetch comprehensive performance metrics for all the items in a specific campaign, allowing you to analyze key performance indicators based on specified filtering and sorting criteria.<br><b style='color:green;'>Market availability: US only</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.SemReporting.GetItemLevelSummary(new GetItemLevelSummaryRequest
    {
        CampaignId = "some example string",
        WmSecAccessToken = "eyJraWQiOiIxNWNhNGIyYi0yODVjLTQ0ZDUtYmExNC05ZDk1NTlkZmUwNjgiLCJlbmMiOiJBMjU2R0NNIiwiYWxnIjoiZGlyIn0....",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Marketplace",
    });
    // TODO: Handle 'response' of type SemItemLevelReportResponse
}
catch (ApiException<GetItemLevelSummaryError> ex)
{
    if (ex.Error.TryGetSemErrorResponse400(out var error))
    {
        // TODO: Handle 'error' of type SemErrorResponse400
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetItemLevelSummaryRequest](src/WalmartApIs/Requests/SemReporting/GetItemLevelSummaryRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[SemItemLevelReportResponse](src/WalmartApIs/Models/SemItemLevelReportResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetItemLevelSummaryError](src/WalmartApIs/Errors/GetItemLevelSummaryError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## SeoRecommendations

> Source: [SeoRecommendations](src/WalmartApIs/Api/SeoRecommendations.cs)

<details>
<summary><code>Task&lt;V3SeoRecommendationGetItemsResponse&gt; GetSeoRecommendations(GetSeoRecommendationsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Get list of items with SEO recommendations. Sellers can filter items by status (all, new, accepted, rejected), search for specific items using identifiers like (itemId, sku, or name) and paginate results for large datasets..

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.SeoRecommendations.GetSeoRecommendations(new GetSeoRecommendationsRequest
    {
        Limit = "200",
        NextCursor = "*",
        PreviousCursor = "1374004777531007833",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        Accept = "application/json",
    });
    // TODO: Handle 'response' of type V3SeoRecommendationGetItemsResponse
}
catch (ApiException<GetSeoRecommendationsError> ex)
{
    if (ex.Error.TryGetV3SeoRecommendationGetItems400Error1(out var error))
    {
        // TODO: Handle 'error' of type V3SeoRecommendationGetItems400Error1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetSeoRecommendationsRequest](src/WalmartApIs/Requests/SeoRecommendations/GetSeoRecommendationsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3SeoRecommendationGetItemsResponse](src/WalmartApIs/Models/V3SeoRecommendationGetItemsResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetSeoRecommendationsError](src/WalmartApIs/Errors/GetSeoRecommendationsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;V3SeoRecommendationUpdateItemsResponse&gt; UpdateSeoRecommendations(UpdateSeoRecommendationsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Sellers can accept or reject SEO recommendations with optimal feedback for rejected recommendations

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.SeoRecommendations.UpdateSeoRecommendations(new UpdateSeoRecommendationsRequest
    {
        ItemId = "some example string",
        Decision = Decision.Approved,
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        Accept = "application/json",
    });
    // TODO: Handle 'response' of type V3SeoRecommendationUpdateItemsResponse
}
catch (ApiException<UpdateSeoRecommendationsError> ex)
{
    if (ex.Error.TryGetV3SeoRecommendationUpdateItems400Error1(out var error))
    {
        // TODO: Handle 'error' of type V3SeoRecommendationUpdateItems400Error1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[UpdateSeoRecommendationsRequest](src/WalmartApIs/Requests/SeoRecommendations/UpdateSeoRecommendationsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3SeoRecommendationUpdateItemsResponse](src/WalmartApIs/Models/V3SeoRecommendationUpdateItemsResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[UpdateSeoRecommendationsError](src/WalmartApIs/Errors/UpdateSeoRecommendationsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## ShipWithWalmart

> Source: [ShipWithWalmart](src/WalmartApIs/Api/ShipWithWalmart.cs)

<details>
<summary><code>Task&lt;V3ShippingLabelsResponse&gt; CreateLabel(CreateLabelRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Generates a shipping label using the provided shipment information. A successful response includes a tracking number and a label file in the media type specified in the Accept header.<br><br>This API is supported for <b>all shipping programs</b>, including <b>Walmart Provided Shipping (WPS)</b> and <b>Ship with Walmart (SWW)</b>.<br><br><b>Media Type Options (via Accept header):</b><br>• application/json, application/pdf → Returns label in PDF format.
• application/json, image/png → Returns label in PNG format.
• application/json → Returns tracking info only in JSON. <br><br> <b>Note:</b> The <b>Ship with Walmart service from China to the U.S.</b> is <b>paused until further notice</b>.

<b style="color: green;">Market availability: Global</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ShipWithWalmart.CreateLabel(new CreateLabelRequest
    {
        Accept = "application/json",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        WmMarket = WmMarket1.Us,
        WmGlobalVersion = WmGlobalVersion._31,
        Body = new V3ShippingLabelsRequest
        {
            PackageType = "CUSTOM_PACKAGE",
            BoxDimensions = new BoxDimensions3
            {
                BoxLength = 13d,
                BoxWidth = 9d,
                BoxHeight = 0d,
                BoxWeight = 13d,
                BoxDimensionUnit = BoxDimensionUnit3.In,
                BoxWeightUnit = BoxWeightUnit3.Lb,
            },
            BoxItems = [new BoxItem6 { Sku = "PRECISE3PGLASS9", Quantity = 1, LineNumber = "1" }],
            FromAddress = new FromAddress2
            {
                ContactName = "Test Seller",
                CompanyName = "Test Company",
                AddressLine1 = "Add1",
                AddressLine2 = "Add2",
                City = "Anchorage",
                State = "AK",
                PostalCode = "99501",
                Country = "US",
                Phone = "12253",
                Email = "test@walmart.com",
            },
            PurchaseOrderId = "97108719025934786",
            CarrierName = "FedEx",
            CarrierServiceType = "FEDEX_2_DAY",
            Hazmat = true,
        },
    });
    // TODO: Handle 'response' of type V3ShippingLabelsResponse
}
catch (ApiException<CreateLabelError> ex)
{
    if (ex.Error.TryGetV3ShippingLabels500Error1(out var error))
    {
        // TODO: Handle 'error' of type V3ShippingLabels500Error1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateLabelRequest](src/WalmartApIs/Requests/ShipWithWalmart/CreateLabelRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3ShippingLabelsResponse](src/WalmartApIs/Models/V3ShippingLabelsResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[CreateLabelError](src/WalmartApIs/Errors/CreateLabelError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;V3ShippingMultiPackageLabelsResponse&gt; CreateLabelMps(CreateLabelMpsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Creates a shipping label for items, supporting multiple packages per request. A successful response includes a tracking number and a label file in the media type specified by the Accept header. This API supports <b>all shipping programs</b>, including <b>Walmart Provided Shipping (WPS)</b> and <b>Ship with Walmart (SWW)</b>.<br><br><b>Media Type Options (via Accept header):</b><br>•application/json, application/pdf → Returns the label in PDF format.<br>•application/json → Returns tracking info only, in JSON format.

<b style="color: green;">Market availability: CA | MX</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ShipWithWalmart.CreateLabelMps(new CreateLabelMpsRequest
    {
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        WmMarket = WmMarket11.Mx,
        WmGlobalVersion = WmGlobalVersion._31,
        Accept = "application/json",
        Body = new V3ShippingMultiPackageLabelsRequest
        {
            PackageDimensions = [
                new PackageDimension
                {
                    PackageType = "CUSTOM_PACKAGE",
                    BoxDimensions = new BoxDimensions4
                    {
                        BoxDimensionUnit = BoxDimensionUnit4.In,
                        BoxWeightUnit = BoxWeightUnit4.Lb,
                        BoxWeight = 3d,
                        BoxLength = 9d,
                        BoxWidth = 12d,
                        BoxHeight = 1d,
                    },
                },
                new PackageDimension
                {
                    PackageType = "CUSTOM_PACKAGE",
                    BoxDimensions = new BoxDimensions4
                    {
                        BoxDimensionUnit = BoxDimensionUnit4.In,
                        BoxWeightUnit = BoxWeightUnit4.Lb,
                        BoxWeight = 3d,
                        BoxLength = 9d,
                        BoxWidth = 12d,
                        BoxHeight = 1d,
                    },
                },
                new PackageDimension
                {
                    PackageType = "CUSTOM_PACKAGE",
                    BoxDimensions = new BoxDimensions4
                    {
                        BoxDimensionUnit = BoxDimensionUnit4.In,
                        BoxWeightUnit = BoxWeightUnit4.Lb,
                        BoxWeight = 3d,
                        BoxLength = 9d,
                        BoxWidth = 12d,
                        BoxHeight = 1d,
                    },
                },
            ],
            BoxItems = [
                new BoxItem8 { Sku = "EDF07661449630550", Quantity = 1, CountryOfOrigin = "MX", LineNumber = "1" },
            ],
            FromAddress = new FromAddress3
            {
                ContactName = "Test",
                CompanyName = "Walmart",
                AddressLine1 = "Add1",
                AddressLine2 = "Add2",
                City = "Anchorage",
                State = "AK",
                PostalCode = "99501",
                Country = "US",
                Phone = "12253",
                Email = "test@walmart.com",
            },
            PurchaseOrderId = "309006496534952",
            CarrierName = "FedEx",
            CarrierServiceType = "FEDEX_INTERNATIONAL_ECONOMY",
        },
    });
    // TODO: Handle 'response' of type V3ShippingMultiPackageLabelsResponse
}
catch (ApiException<CreateLabelMpsError> ex)
{
    if (ex.Error.TryGetListOfError5(out var error))
    {
        // TODO: Handle 'error' of type IReadOnlyList<Error5>
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateLabelMpsRequest](src/WalmartApIs/Requests/ShipWithWalmart/CreateLabelMpsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3ShippingMultiPackageLabelsResponse](src/WalmartApIs/Models/V3ShippingMultiPackageLabelsResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[CreateLabelMpsError](src/WalmartApIs/Errors/CreateLabelMpsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;V3ShippingLabelsCarriersTrackingsResponse&gt; DiscardLabel(DiscardLabelRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Marks a previously generated shipping label as discarded.
This API is used when the label should no longer be used for shipment processing. <br><br> <b>Applicable Shipping Programs:</b><br>This API is supported for the following <b>shipping programs:  Walmart Provided Shipping (WPS) and Ship with Walmart (SWW).</b>

<b style="color: green;">Market availability: US | CA | MX</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ShipWithWalmart.DiscardLabel(new DiscardLabelRequest
    {
        CarrierShortName = "some example string",
        TrackingNo = "some example string",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        WmMarket = WmMarket6.Mx,
        WmGlobalVersion = WmGlobalVersion._31,
    });
    // TODO: Handle 'response' of type V3ShippingLabelsCarriersTrackingsResponse
}
catch (ApiException<DiscardLabelError> ex)
{
    if (ex.Error.TryGetListOfV3ShippingLabelsCarriersTrackings400Error1(out var error))
    {
        // TODO: Handle 'error' of type IReadOnlyList<V3ShippingLabelsCarriersTrackings400Error1>
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[DiscardLabelRequest](src/WalmartApIs/Requests/ShipWithWalmart/DiscardLabelRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3ShippingLabelsCarriersTrackingsResponse](src/WalmartApIs/Models/V3ShippingLabelsCarriersTrackingsResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[DiscardLabelError](src/WalmartApIs/Errors/DiscardLabelError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;V3ShippingLabelsCarriersPackageTypesResponse&gt; GetCarrierPackageTypes(GetCarrierPackageTypesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This API retrieves all supported package types for the selected carrier.

<b style="color: green;">Market availability: Global</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ShipWithWalmart.GetCarrierPackageTypes(new GetCarrierPackageTypesRequest
    {
        CarrierShortName = "some example string",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        WmMarket = WmMarket11.Mx,
        WmGlobalVersion = WmGlobalVersion._31,
    });
    // TODO: Handle 'response' of type V3ShippingLabelsCarriersPackageTypesResponse
}
catch (ApiException<RawError> ex)
{
    // TODO: Handle 'ex.Error' of type RawError
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetCarrierPackageTypesRequest](src/WalmartApIs/Requests/ShipWithWalmart/GetCarrierPackageTypesRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3ShippingLabelsCarriersPackageTypesResponse](src/WalmartApIs/Models/V3ShippingLabelsCarriersPackageTypesResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[RawError](src/WalmartApIs/Core/ErrorResponse/RawError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;V3ShippingLabelsCarriersResponse&gt; GetCarriers(GetCarriersRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This API retrieves all carriers supported by Ship With Walmart.

<b style="color: green;">Market availability: Global</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ShipWithWalmart.GetCarriers(new GetCarriersRequest
    {
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        WmMarket = WmMarket11.Mx,
        WmGlobalVersion = WmGlobalVersion._31,
    });
    // TODO: Handle 'response' of type V3ShippingLabelsCarriersResponse
}
catch (ApiException<RawError> ex)
{
    // TODO: Handle 'ex.Error' of type RawError
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetCarriersRequest](src/WalmartApIs/Requests/ShipWithWalmart/GetCarriersRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3ShippingLabelsCarriersResponse](src/WalmartApIs/Models/V3ShippingLabelsCarriersResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[RawError](src/WalmartApIs/Core/ErrorResponse/RawError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;V3ShippingLabelsPurchaseOrdersResponse&gt; GetLabel(GetLabelRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This API retrieves all label details generated for a purchase order id.

<b style="color: green;">Market availability: Global</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ShipWithWalmart.GetLabel(new GetLabelRequest
    {
        PurchaseOrderId = "some example string",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        WmMarket = WmMarket11.Mx,
        WmGlobalVersion = WmGlobalVersion._31,
    });
    // TODO: Handle 'response' of type V3ShippingLabelsPurchaseOrdersResponse
}
catch (ApiException<RawError> ex)
{
    // TODO: Handle 'ex.Error' of type RawError
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetLabelRequest](src/WalmartApIs/Requests/ShipWithWalmart/GetLabelRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3ShippingLabelsPurchaseOrdersResponse](src/WalmartApIs/Models/V3ShippingLabelsPurchaseOrdersResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[RawError](src/WalmartApIs/Core/ErrorResponse/RawError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task GetLabelByTrackingAndCarrier(GetLabelByTrackingAndCarrierRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Retrieves the shipping label for a specific carrier and tracking number combination.
The response includes the tracking number and the label in the requested media type (PDF or PNG), based on the Accept header provided. <br><br> <b>Media Type Options:</b><br>•Accept: application/json,application/pdf → Returns label in PDF format.<br>•Accept: application/json,image/png → Returns label in PNG format. <br><br><b>Market and Shipment Program Applicability:</b><br>•<b>CL</b> : Applicable for <b>International</b> shipments only.<br>•<b>US, MX, CA</b>: Applicable for <b>Domestic and International</b> shipments across <b>all shipping programs</b> (including <b>Walmart Provided Shipping (WPS)</b> and <b>Ship with Walmart (SWW)</b>).

<b style="color: green;">Market availability: Global</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    await client.ShipWithWalmart.GetLabelByTrackingAndCarrier(new GetLabelByTrackingAndCarrierRequest
    {
        CarrierShortName = "some example string",
        TrackingNo = "some example string",
        Accept = "application/pdf",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        WmMarket = WmMarket11.Mx,
        WmGlobalVersion = WmGlobalVersion._31,
    });
}
catch (ApiException<RawError> ex)
{
    // TODO: Handle 'ex.Error' of type RawError
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetLabelByTrackingAndCarrierRequest](src/WalmartApIs/Requests/ShipWithWalmart/GetLabelByTrackingAndCarrierRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: No content

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[RawError](src/WalmartApIs/Core/ErrorResponse/RawError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;BinaryContent&gt; GetScanFormByManifestId(GetScanFormByManifestIdRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This API retrieves a scan form for a given manifest ID.

**Rate Limits:** This endpoint allows 100 requests per minute. Exceeding this limit returns a `429 Too Many Requests` response. See the [Rate Limiting guide](https://developer.walmart.com/us-marketplace/docs/rate-limiting) for full details. The response includes `x-current-token-count` (remaining requests in the current window) and `X-Next-Replenishment-Time` (when the token count next increases).

**Sandbox:** Use base URL `https://sandbox.walmartapis.com`. The sandbox returns a stub binary document for any valid sandbox `manifestId`. The `documentFormat` selection (PDF/ZPL/PNG) is honored in production; in sandbox, a PDF stub is always returned regardless of the format requested during scan form creation.

**Note:** This endpoint returns a binary document stream (application/octet-stream). Treat the response body as bytes and save it to a file. The underlying document format aligns with the scan form documentFormat selected during creation (for example, PDF, ZPL, PNG).

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ShipWithWalmart.GetScanFormByManifestId(new GetScanFormByManifestIdRequest
    {
        ManifestId = "some example string",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Marketplace",
        WmMarket = WmMarket.Us,
        WmGlobalVersion = WmGlobalVersion._31,
        Accept = "application/octet-stream",
    });
    // TODO: Handle 'response' of type BinaryContent
}
catch (ApiException<RawError> ex)
{
    // TODO: Handle 'ex.Error' of type RawError
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetScanFormByManifestIdRequest](src/WalmartApIs/Requests/ShipWithWalmart/GetScanFormByManifestIdRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>BinaryContent</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[RawError](src/WalmartApIs/Core/ErrorResponse/RawError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;V3ShippingLabelsShippingEstimatesResponse&gt; GetShippingEstimate(GetShippingEstimateRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This API retrieves shipping cost estimates for available shipping services based on address and package (example, customer address, packaged weight.)

<b style="color: green;">Market availability: US only</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ShipWithWalmart.GetShippingEstimate(new GetShippingEstimateRequest
    {
        Accept = "application/json",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        WmMarket = WmMarket11.Mx,
        WmGlobalVersion = WmGlobalVersion._31,
        Body = new V3ShippingLabelsShippingEstimatesRequest
        {
            BoxDimensions = new BoxDimensions5
            {
                BoxLength = 6d,
                BoxWidth = 6d,
                BoxHeight = 6d,
                BoxWeight = 0.8d,
                BoxDimensionUnit = BoxDimensionUnit.In,
                BoxWeightUnit = BoxWeightUnit.Lb,
            },
            DeliverByDate = "2023-06-07T23:00:00.611Z",
            ShipByDate = "2023-06-05T08:00:00.611Z",
            FromAddress = new FromAddress4
            {
                PostalCode = "91776",
                CountryCode = "US",
                AddressLines = ["311 E VALLEY BLVD STE 112 PMB 271as"],
                City = "SAN GABRIEL1as",
                State = "CA",
            },
            ToAddress = new ToAddress1
            {
                PostalCode = "94085",
                CountryCode = "US",
                AddressLines = ["748 N Mathilda Ave", "Room # 224"],
                City = "SUNNYVALE",
                State = "CA",
            },
            Carriers = ["FEDEX"],
            PackageType = "CUSTOM_PACKAGE",
            IncludeServicesNotMeetingDeliveryPromise = true,
            PurchaseOrderId = "91088062299813853",
            BoxItems = [new BoxItem10 { Sku = "sku-1NMeZnK1B1MNJdXde5771022", Quantity = 1, LineNumber = "1" }],
        },
    });
    // TODO: Handle 'response' of type V3ShippingLabelsShippingEstimatesResponse
}
catch (ApiException<GetShippingEstimateError> ex)
{
    if (ex.Error.TryGetListOfV3ShippingLabelsShippingEstimates400Error1(out var error))
    {
        // TODO: Handle 'error' of type IReadOnlyList<V3ShippingLabelsShippingEstimates400Error1>
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetShippingEstimateRequest](src/WalmartApIs/Requests/ShipWithWalmart/GetShippingEstimateRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3ShippingLabelsShippingEstimatesResponse](src/WalmartApIs/Models/V3ShippingLabelsShippingEstimatesResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetShippingEstimateError](src/WalmartApIs/Errors/GetShippingEstimateError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;V3ShippingScanFormResponse&gt; ScanForm(ScanFormRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This API generates a scan form using the provided tracking numbers. The scan form is a consolidated document that contains all the tracking numbers and shipping details for the packages being shipped out on a particular day. It is used by carriers to verify and process the shipments during pickup and delivery. Currently, only USPS supports scan forms.

**Idempotency:** `scanFormId` acts as a natural idempotency key — the client supplies it in the request body before the call. Submitting a second POST with a `scanFormId` that was already successfully processed returns `409 Conflict`; no duplicate scan form is created. On network failure or timeout, clients may safely retry using the same `scanFormId`. This guarantee is critical for EOD automation — a duplicate manifest can cause carrier processing errors and shipment delays.

**Rate Limits:** This endpoint allows 100 requests per minute. Exceeding this limit returns a `429 Too Many Requests` response. See the [Rate Limiting guide](https://developer.walmart.com/us-marketplace/docs/rate-limiting) for full details. The response includes `x-current-token-count` (remaining requests in the current window) and `X-Next-Replenishment-Time` (when the token count next increases).

**Sandbox:** Use base URL `https://sandbox.walmartapis.com`. The sandbox accepts test tracking numbers and returns a synthetic `manifestId` (e.g. `SANDBOX-12345`). Use that `manifestId` with the GET endpoint to retrieve the stub scan form document.

<b style="color: green;">Market availability: US only</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ShipWithWalmart.ScanForm(new ScanFormRequest
    {
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Marketplace",
        WmMarket = WmMarket.Us,
        WmGlobalVersion = WmGlobalVersion._31,
        Accept = "application/json",
        Body = new V3ShippingScanFormRequest
        {
            ScanFormId = "string",
            CarrierName = "USPS",
            ShipOnDate = "2025-08-23",
            FromAddress = new FromAddress5
            {
                ContactName = "John Doe",
                CompanyName = "Walmart",
                AddressLine1 = "1375 Crossman Ave",
                AddressLine2 = "string",
                City = "Sunnyvale",
                State = "CA",
                PostalCode = "63116",
                Country = "US",
                Phone = "6172012456",
                Email = "",
            },
            TrackingNumbers = ["100044481029", "100044481030"],
            DocumentFormat = "PDF",
        },
    });
    // TODO: Handle 'response' of type V3ShippingScanFormResponse
}
catch (ApiException<ScanFormError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ScanFormRequest](src/WalmartApIs/Requests/ShipWithWalmart/ScanFormRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3ShippingScanFormResponse](src/WalmartApIs/Models/V3ShippingScanFormResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[ScanFormError](src/WalmartApIs/Errors/ScanFormError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## ShipmentProtection

> Source: [ShipmentProtection](src/WalmartApIs/Api/ShipmentProtection.cs)

<details>
<summary><code>Task&lt;BinaryContent&gt; DownloadClaimDocuments(DownloadClaimDocumentsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns a ZIP file containing one or more uploaded claim documents.<br><b style='color:green;'>Market availability: US Only</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ShipmentProtection.DownloadClaimDocuments(new DownloadClaimDocumentsRequest
    {
        ClaimNumber = "some example string",
        WmSecAccessToken = "eyJraWQiOiIzZjVhYTFmNS1hYWE5LTQzM.....",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        Body = new V3ClaimsShipmentProtectionClaimDocumentsRequest { DocumentIds = ["some example string"] },
    });
    // TODO: Handle 'response' of type BinaryContent
}
catch (ApiException<DownloadClaimDocumentsError> ex)
{
    if (ex.Error.TryGetV3ClaimsShipmentProtectionClaimDocuments400Error1(out var error))
    {
        // TODO: Handle 'error' of type V3ClaimsShipmentProtectionClaimDocuments400Error1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[DownloadClaimDocumentsRequest](src/WalmartApIs/Requests/ShipmentProtection/DownloadClaimDocumentsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>BinaryContent</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[DownloadClaimDocumentsError](src/WalmartApIs/Errors/DownloadClaimDocumentsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;object&gt; GetClaimDetails(GetClaimDetailsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Retrieves detailed information for a single claim.<br><b style='color:green;'>Market availability: US Only</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ShipmentProtection.GetClaimDetails(new GetClaimDetailsRequest
    {
        ClaimNumber = "some example string",
        WmSecAccessToken = "eyJraWQiOiIzZjVhYTFmNS1hYWE5LTQzM.....",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
    });
    // TODO: Handle 'response' of type object
}
catch (ApiException<GetClaimDetailsError> ex)
{
    if (ex.Error.TryGetV3ClaimsShipmentProtectionClaim400Error1(out var error))
    {
        // TODO: Handle 'error' of type V3ClaimsShipmentProtectionClaim400Error1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetClaimDetailsRequest](src/WalmartApIs/Requests/ShipmentProtection/GetClaimDetailsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetClaimDetailsError](src/WalmartApIs/Errors/GetClaimDetailsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;V3ClaimsShipmentProtectionClaimHistoryResponse&gt; GetClaimHistory(GetClaimHistoryRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns a chronological log of status changes, notes, and uploaded documents.<br><b style='color:green;'>Market availability: US Only</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ShipmentProtection.GetClaimHistory(new GetClaimHistoryRequest
    {
        ClaimNumber = "some example string",
        WmSecAccessToken = "eyJraWQiOiIzZjVhYTFmNS1hYWE5LTQzM.....",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
    });
    // TODO: Handle 'response' of type V3ClaimsShipmentProtectionClaimHistoryResponse
}
catch (ApiException<GetClaimHistoryError> ex)
{
    if (ex.Error.TryGetV3ClaimsShipmentProtectionClaimHistory400Error1(out var error))
    {
        // TODO: Handle 'error' of type V3ClaimsShipmentProtectionClaimHistory400Error1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetClaimHistoryRequest](src/WalmartApIs/Requests/ShipmentProtection/GetClaimHistoryRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3ClaimsShipmentProtectionClaimHistoryResponse](src/WalmartApIs/Models/V3ClaimsShipmentProtectionClaimHistoryResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetClaimHistoryError](src/WalmartApIs/Errors/GetClaimHistoryError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;object&gt; ListClaims(ListClaimsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns a paginated list of claims, with optional filters.<br><b style='color:green;'>Market availability: US Only</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ShipmentProtection.ListClaims(new ListClaimsRequest
    {
        WmSecAccessToken = "eyJraWQiOiIzZjVhYTFmNS1hYWE5LTQzM.....",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
    });
    // TODO: Handle 'response' of type object
}
catch (ApiException<ListClaimsError> ex)
{
    if (ex.Error.TryGetV3ClaimsShipmentProtection400Error1(out var error))
    {
        // TODO: Handle 'error' of type V3ClaimsShipmentProtection400Error1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListClaimsRequest](src/WalmartApIs/Requests/ShipmentProtection/ListClaimsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[ListClaimsError](src/WalmartApIs/Errors/ListClaimsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;object&gt; SubmitAdditionalInfo(SubmitAdditionalInfoRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Adds documents or notes to an existing claim when Walmart requests more details.<br><b style='color:green;'>Market availability: US Only</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ShipmentProtection.SubmitAdditionalInfo(new SubmitAdditionalInfoRequest
    {
        ClaimNumber = "some example string",
        WmSecAccessToken = "eyJraWQiOiIzZjVhYTFmNS1hYWE5LTQzM.....",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        Files = Array.Empty<byte>(),
        DocumentTypes = [new DocumentType1 { FileName = "item_damage.jpg", Type = Type11.ProofOfDamagedItem }],
        Notes = "Here is the picture you requested.",
    });
    // TODO: Handle 'response' of type object
}
catch (ApiException<SubmitAdditionalInfoError> ex)
{
    if (ex.Error.TryGetV3ClaimsShipmentProtectionClaim400Error1(out var error))
    {
        // TODO: Handle 'error' of type V3ClaimsShipmentProtectionClaim400Error1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[SubmitAdditionalInfoRequest](src/WalmartApIs/Requests/ShipmentProtection/SubmitAdditionalInfoRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[SubmitAdditionalInfoError](src/WalmartApIs/Errors/SubmitAdditionalInfoError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;object&gt; SubmitClaim(SubmitClaimRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Creates a shipment-protection claim. Send multipart/form-data with files, documentTypes, and payload.<br><b style='color:green;'>Market availability: US Only</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ShipmentProtection.SubmitClaim(new SubmitClaimRequest
    {
        WmSecAccessToken = "eyJraWQiOiIzZjVhYTFmNS1hYWE5LTQzM.....",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        Files = Array.Empty<byte>(),
        DocumentTypes = [
            new DocumentType { FileName = "file1.jpg", Type = Type1.ProofOfDamagedItem },
            new DocumentType { FileName = "invoice.pdf", Type = Type1.Invoice },
        ],
        Payload = new Payload
        {
            PurchaseOrderNo = "RAPMOCK1729803026938",
            PurchaseOrderLineNo = "1",
            SalesOrderNo = "RAPMOCK1729803026883",
            SalesOrderLineNo = "1",
            FulfillerLineId = "1",
            Quantity = 3,
            ReturnOrderId = "136900073772361154",
            ClaimType = ClaimType.Damaged,
            Notes = "Claim submission notes.",
        },
    });
    // TODO: Handle 'response' of type object
}
catch (ApiException<SubmitClaimError> ex)
{
    if (ex.Error.TryGetV3ClaimsShipmentProtectionClaim400Error1(out var error))
    {
        // TODO: Handle 'error' of type V3ClaimsShipmentProtectionClaim400Error1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[SubmitClaimRequest](src/WalmartApIs/Requests/ShipmentProtection/SubmitClaimRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[SubmitClaimError](src/WalmartApIs/Errors/SubmitClaimError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## SimplifiedShippingSettings

> Source: [SimplifiedShippingSettings](src/WalmartApIs/Api/SimplifiedShippingSettings.cs)

<details>
<summary><code>Task&lt;FeedId1&gt; BulkMigrateOffersForSimplifiedShippingSettings(BulkMigrateOffersForSimplifiedShippingSettingsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This API is used to bulk migrate offers from manual templates to Simplified Shipping Settings and vice-versa. Make sure to create account level settings before proceeding with item migration to Simplified Shipping Settings.
<br><b style='color:green;'>Market availability: US</span></b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.SimplifiedShippingSettings.BulkMigrateOffersForSimplifiedShippingSettings(
        new BulkMigrateOffersForSimplifiedShippingSettingsRequest
        {
            FeedType = "some example string",
            RequestType = "some example string",
            WmSecAccessToken = "eyJraWQiOiIzZjVhYTFmNS1hYWE5LTQzM.....",
            WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
            WmSvcName = "Walmart Service Name",
            WmMarket = WmMarket1.Us,
            WmGlobalVersion = WmGlobalVersion._31,
            Body = new V3FeedsRequest1
            {
                ProgramActionFeedHeader = new ProgramActionFeedHeader11
                {
                    Version = "5.0.20241002-17_27_17-api",
                    Locale = "en",
                    BusinessUnit = "WALMART_US",
                },
                ProgramAction = [
                    new ProgramAction11
                    {
                        Programs = new Programs21(),
                        ItemIdentifiers = new ItemIdentifiers { Sku = "8922gfgf" },
                    },
                ],
            },
        });
    // TODO: Handle 'response' of type FeedId1
}
catch (ApiException<RawError> ex)
{
    // TODO: Handle 'ex.Error' of type RawError
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[BulkMigrateOffersForSimplifiedShippingSettingsRequest](src/WalmartApIs/Requests/SimplifiedShippingSettings/BulkMigrateOffersForSimplifiedShippingSettingsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[FeedId1](src/WalmartApIs/Models/FeedId1.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[RawError](src/WalmartApIs/Core/ErrorResponse/RawError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;IReadOnlyList&lt;V3SettingsShippingSimplifiedshippingsettingsAccountResponse1&gt;&gt; CreateSimplifiedShippingSettings(CreateSimplifiedShippingSettingsOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This API is used to update the account-level configuration. The carrier configurations created using this API will be applied across all Fulfillment Centers (FCs) unless they are overridden using the FC Configuration API..
<br><b style='color:green;'>Market availability: US</span></b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.SimplifiedShippingSettings.CreateSimplifiedShippingSettings(
        new CreateSimplifiedShippingSettingsOperationRequest
        {
            WmSecAccessToken = "eyJraWQiOiIzZjVhYTFmNS1hYWE5LTQzM.....",
            WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
            WmSvcName = "Walmart Service Name",
            WmMarket = WmMarket1.Us,
            WmGlobalVersion = WmGlobalVersion._31,
            Body = new V3SettingsShippingSimplifiedshippingsettingsAccountRequest1
            {
                SimplifiedShippingSettings = new SimplifiedShippingSettings10
                {
                    AccountConfigs = new AccountConfigs9
                    {
                        ShippingPriority = ShippingPriority7.Fastest,
                        MigrateEligibleOffers = false,
                        CarrierConfigs = [new CarrierConfig20(), new CarrierConfig20()],
                    },
                },
            },
        });
    // TODO: Handle 'response' of type IReadOnlyList<V3SettingsShippingSimplifiedshippingsettingsAccountResponse1>
}
catch (ApiException<RawError> ex)
{
    // TODO: Handle 'ex.Error' of type RawError
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateSimplifiedShippingSettingsOperationRequest](src/WalmartApIs/Requests/SimplifiedShippingSettings/CreateSimplifiedShippingSettingsOperationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>IReadOnlyList&lt;[V3SettingsShippingSimplifiedshippingsettingsAccountResponse1](src/WalmartApIs/Models/V3SettingsShippingSimplifiedshippingsettingsAccountResponse1.cs)&gt;</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[RawError](src/WalmartApIs/Core/ErrorResponse/RawError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;IReadOnlyList&lt;V3SettingsShippingSimplifiedshippingsettingsResponse&gt;&gt; GetSimplifiedShippingSettings(GetSimplifiedShippingSettingsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This API helps seller to fetch the Simplified Shipping Settings for a seller account and FC-level configurations.
<br><b style='color:green;'>Market availability: Global</span></b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.SimplifiedShippingSettings.GetSimplifiedShippingSettings(
        new GetSimplifiedShippingSettingsRequest
        {
            WmSecAccessToken = "eyJraWQiOiIzZjVhYTFmNS1hYWE5LTQzM.....",
            WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
            WmSvcName = "Walmart Service Name",
            WmMarket = WmMarket1.Us,
            WmGlobalVersion = WmGlobalVersion._31,
        });
    // TODO: Handle 'response' of type IReadOnlyList<V3SettingsShippingSimplifiedshippingsettingsResponse>
}
catch (ApiException<RawError> ex)
{
    // TODO: Handle 'ex.Error' of type RawError
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetSimplifiedShippingSettingsRequest](src/WalmartApIs/Requests/SimplifiedShippingSettings/GetSimplifiedShippingSettingsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>IReadOnlyList&lt;[V3SettingsShippingSimplifiedshippingsettingsResponse](src/WalmartApIs/Models/V3SettingsShippingSimplifiedshippingsettingsResponse.cs)&gt;</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[RawError](src/WalmartApIs/Core/ErrorResponse/RawError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;IReadOnlyList&lt;V3SettingsShippingSimplifiedshippingsettingsFulfillmentcenterResponse&gt;&gt; UpdateFcLevelSimplifiedShippingSettings(UpdateFcLevelSimplifiedShippingSettingsOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This API can be used for overriding the configurations at one or more Fulfillment Centers.
<br><b style='color:green;'>Market availability: US</span></b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.SimplifiedShippingSettings.UpdateFcLevelSimplifiedShippingSettings(
        new UpdateFcLevelSimplifiedShippingSettingsOperationRequest
        {
            WmSecAccessToken = "eyJraWQiOiIzZjVhYTFmNS1hYWE5LTQzM.....",
            WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
            WmSvcName = "Walmart Service Name",
            WmMarket = WmMarket1.Us,
            WmGlobalVersion = WmGlobalVersion._31,
            Body = new V3SettingsShippingSimplifiedshippingsettingsFulfillmentcenterRequest
            {
                SimplifiedShippingSettings = new SimplifiedShippingSettings6
                {
                    ShipNodeConfigs = [
                        new ShipNodeConfig5 { ShipNodes = ["1234567616356"], IsOverridden = false },
                        new ShipNodeConfig5
                        {
                            ShipNodes = ["1234567616357"],
                            IsOverridden = true,
                            CarrierConfigs = [new CarrierConfig16()],
                        },
                    ],
                },
            },
        });
    // TODO: Handle 'response' of type IReadOnlyList<V3SettingsShippingSimplifiedshippingsettingsFulfillmentcenterResponse>
}
catch (ApiException<RawError> ex)
{
    // TODO: Handle 'ex.Error' of type RawError
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[UpdateFcLevelSimplifiedShippingSettingsOperationRequest](src/WalmartApIs/Requests/SimplifiedShippingSettings/UpdateFcLevelSimplifiedShippingSettingsOperationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>IReadOnlyList&lt;[V3SettingsShippingSimplifiedshippingsettingsFulfillmentcenterResponse](src/WalmartApIs/Models/V3SettingsShippingSimplifiedshippingsettingsFulfillmentcenterResponse.cs)&gt;</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[RawError](src/WalmartApIs/Core/ErrorResponse/RawError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;IReadOnlyList&lt;V3SettingsShippingSimplifiedshippingsettingsAccountResponse&gt;&gt; UpdateSimplifiedShippingSettings(UpdateSimplifiedShippingSettingsOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This API is used to update the account-level configuration. The carrier configurations updated using this API will be applied across all Fulfillment Centers (FCs) unless they are overridden using the FC Configuration API.

<br><b style='color:green;'>Market availability: US</span></b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.SimplifiedShippingSettings.UpdateSimplifiedShippingSettings(
        new UpdateSimplifiedShippingSettingsOperationRequest
        {
            WmSecAccessToken = "eyJraWQiOiIzZjVhYTFmNS1hYWE5LTQzM.....",
            WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
            WmSvcName = "Walmart Service Name",
            WmMarket = WmMarket1.Us,
            WmGlobalVersion = WmGlobalVersion._31,
            Body = new V3SettingsShippingSimplifiedshippingsettingsAccountRequest
            {
                SimplifiedShippingSettings = new SimplifiedShippingSettings8
                {
                    AccountConfigs = new AccountConfigs7
                    {
                        CarrierConfigs = [new CarrierConfig18(), new CarrierConfig18()],
                    },
                },
            },
        });
    // TODO: Handle 'response' of type IReadOnlyList<V3SettingsShippingSimplifiedshippingsettingsAccountResponse>
}
catch (ApiException<RawError> ex)
{
    // TODO: Handle 'ex.Error' of type RawError
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[UpdateSimplifiedShippingSettingsOperationRequest](src/WalmartApIs/Requests/SimplifiedShippingSettings/UpdateSimplifiedShippingSettingsOperationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>IReadOnlyList&lt;[V3SettingsShippingSimplifiedshippingsettingsAccountResponse](src/WalmartApIs/Models/V3SettingsShippingSimplifiedshippingsettingsAccountResponse.cs)&gt;</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[RawError](src/WalmartApIs/Core/ErrorResponse/RawError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## TaxFormApIs

> Source: [TaxFormApIs](src/WalmartApIs/Api/TaxFormApIs.cs)

<details>
<summary><code>Task DownloadTaxForm(DownloadTaxFormRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

The Download Tax Form API downloads the selected tax form document as a byte stream.

<b style='color:green;'>Market availability: US only</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    await client.TaxFormApIs.DownloadTaxForm(new DownloadTaxFormRequest
    {
        PayoutYear = "some example string",
        TaxFormType = "some example string",
        FormId = "some example string",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        WmGlobalVersion = WmGlobalVersion._31,
        WmMarket = "US",
        WmPartnerId = "123456789",
        WmTenantId = "0",
    });
}
catch (ApiException<DownloadTaxFormError> ex)
{
    if (ex.Error.TryGetV1SettingsDownloadtaxformprofile400Error1(out var error))
    {
        // TODO: Handle 'error' of type V1SettingsDownloadtaxformprofile400Error1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[DownloadTaxFormRequest](src/WalmartApIs/Requests/TaxFormApIs/DownloadTaxFormRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: No content

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[DownloadTaxFormError](src/WalmartApIs/Errors/DownloadTaxFormError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;V1SettingsGettaxformprofileResponse&gt; GetTaxForms(GetTaxFormsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

The Get Tax Forms API returns available tax forms for the authenticated seller, including form type and form ID. The response is a JSON object containing tax form metadata.

<b style='color:green;'>Market availability: US only</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.TaxFormApIs.GetTaxForms(new GetTaxFormsRequest
    {
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Service Name",
        WmGlobalVersion = WmGlobalVersion._31,
        WmMarket = "US",
        WmPartnerId = "123456789",
        WmTenantId = "0",
    });
    // TODO: Handle 'response' of type V1SettingsGettaxformprofileResponse
}
catch (ApiException<GetTaxFormsError> ex)
{
    if (ex.Error.TryGetV1SettingsGettaxformprofile400Error1(out var error))
    {
        // TODO: Handle 'error' of type V1SettingsGettaxformprofile400Error1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetTaxFormsRequest](src/WalmartApIs/Requests/TaxFormApIs/GetTaxFormsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V1SettingsGettaxformprofileResponse](src/WalmartApIs/Models/V1SettingsGettaxformprofileResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetTaxFormsError](src/WalmartApIs/Errors/GetTaxFormsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## WsrAttributionReports

> Source: [WsrAttributionReports](src/WalmartApIs/Api/WsrAttributionReports.cs)

<details>
<summary><code>Task&lt;WsrTagTemplatesResponse&gt; GetTagTemplates(GetTagTemplatesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Fetch referral link tag templates for different page types (ITEM, BRANDSHOP). Tag templates contain URL patterns with placeholders that can be used to construct final referral URLs/tags for affiliate tracking.

<span style="color:green">**Market availability: US**</span>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WsrAttributionReports.GetTagTemplates(new GetTagTemplatesRequest
    {
        TemplateType = TemplateType.NonMacro,
        WmSecAccessToken = "eyJraWQiOiIxNWNhNGIyYi0yODVjLTQ0ZDUtYmExNC05ZDk1NTlkZmUwNjgiLCJlbmMiOiJBMjU2R0NNIiwiYWxnIjoiZGlyIn0....",
        WmSvcName = "Walmart Marketplace",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmGlobalVersion = WmGlobalVersion._31,
        WmMarket = WmMarket.Us,
    });
    // TODO: Handle 'response' of type WsrTagTemplatesResponse
}
catch (ApiException<GetTagTemplatesError> ex)
{
    if (ex.Error.TryGetWsrErrorResponse(out var error))
    {
        // TODO: Handle 'error' of type WsrErrorResponse
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetTagTemplatesRequest](src/WalmartApIs/Requests/WsrAttributionReports/GetTagTemplatesRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[WsrTagTemplatesResponse](src/WalmartApIs/Models/WsrTagTemplatesResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetTagTemplatesError](src/WalmartApIs/Errors/GetTagTemplatesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;WsrItemReportResponse&gt; GetWsrItemReport(GetWsrItemReportRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Retrieve detailed item-level performance reports for affiliate campaigns.

<span style="color:green">**Market availability: US only**</span>

This endpoint returns performance data at the individual item/product level,
including product details such as item name, category, and product type along
with performance metrics. This is useful for understanding which products are
driving the most revenue through affiliate channels.

### Aggregation Levels and Field Availability
The `performanceBy` parameter determines which identifier fields are populated in the response:

| performanceBy | campaignId | adGroupId | creativeId |
|---------------|------------|-----------|------------|
| CAMPAIGN      | ✓          | null      | null       |
| ADGROUP       | ✓          | ✓         | null       |
| CREATIVE      | ✓          | ✓         | ✓          |

### Supported filters
- `startDate`: Report start date (required)
- `endDate`: Report end date (required)
- `campaignId`: Filter by specific campaign IDs
- `adGroupId`: Filter by specific ad group IDs
- `creativeId`: Filter by specific creative IDs

### Date Validation Rules
- End date must be strictly after start date
- Maximum date range: less than 1 year
- Dates must be in ISO format (YYYY-MM-DD)

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WsrAttributionReports.GetWsrItemReport(new GetWsrItemReportRequest
    {
        WmSecAccessToken = "eyJraWQiOiIxNWNhNGIyYi0yODVjLTQ0ZDUtYmExNC05ZDk1NTlkZmUwNjgiLCJlbmMiOiJBMjU2R0NNIiwiYWxnIjoiZGlyIn0....",
        WmSvcName = "Walmart Marketplace",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmGlobalVersion = WmGlobalVersion._31,
        WmMarket = WmMarket.Us,
        Body = new WsrReportRequest
        {
            PerformanceBy = PerformanceBy.Campaign,
            StartDate = DateTimeOffset.Parse("2026-01-01T00:00:00Z"),
            EndDate = DateTimeOffset.Parse("2026-01-31T00:00:00Z"),
            Page = new WsrPage { Limit = 10, Offset = 0 },
            Sort = new WsrSort { Field = Field.Gmv, Order = Order.Desc },
        },
    });
    // TODO: Handle 'response' of type WsrItemReportResponse
}
catch (ApiException<GetWsrItemReportError> ex)
{
    if (ex.Error.TryGetWsrErrorResponse(out var error))
    {
        // TODO: Handle 'error' of type WsrErrorResponse
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetWsrItemReportRequest](src/WalmartApIs/Requests/WsrAttributionReports/GetWsrItemReportRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[WsrItemReportResponse](src/WalmartApIs/Models/WsrItemReportResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetWsrItemReportError](src/WalmartApIs/Errors/GetWsrItemReportError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;WsrPerformanceReportResponse&gt; GetWsrPerformanceReport(GetWsrPerformanceReportRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Retrieve performance analytics and metrics for affiliate campaigns.

<span style="color:green">**Market availability: US only**</span>

This endpoint returns aggregated performance data including clicks, orders,
GMV, and commission metrics within a specified date range. Data can be
aggregated at different levels based on the `performanceBy` parameter.

### Aggregation Levels and Field Availability
The `performanceBy` parameter determines which identifier fields are populated in the response:

| performanceBy | campaignId | adGroupId | creativeId |
|---------------|------------|-----------|------------|
| CAMPAIGN      | ✓          | null      | null       |
| ADGROUP       | ✓          | ✓         | null       |
| CREATIVE      | ✓          | ✓         | ✓          |

### Supported filters
- `startDate`: Report start date (required)
- `endDate`: Report end date (required)
- `campaignId`: Filter by specific campaign IDs
- `adGroupId`: Filter by specific ad group IDs
- `creativeId`: Filter by specific creative IDs

### Date Validation Rules
- End date must be strictly after start date
- Maximum date range: less than 1 year
- Dates must be in ISO format (YYYY-MM-DD)

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WsrAttributionReports.GetWsrPerformanceReport(new GetWsrPerformanceReportRequest
    {
        WmSecAccessToken = "eyJraWQiOiIxNWNhNGIyYi0yODVjLTQ0ZDUtYmExNC05ZDk1NTlkZmUwNjgiLCJlbmMiOiJBMjU2R0NNIiwiYWxnIjoiZGlyIn0....",
        WmSvcName = "Walmart Marketplace",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmGlobalVersion = WmGlobalVersion._31,
        WmMarket = WmMarket.Us,
        Body = new WsrReportRequest
        {
            PerformanceBy = PerformanceBy.Campaign,
            StartDate = DateTimeOffset.Parse("2026-01-01T00:00:00Z"),
            EndDate = DateTimeOffset.Parse("2026-01-31T00:00:00Z"),
            Page = new WsrPage { Limit = 10, Offset = 0 },
            Sort = new WsrSort { Field = Field.Gmv, Order = Order.Desc },
        },
    });
    // TODO: Handle 'response' of type WsrPerformanceReportResponse
}
catch (ApiException<GetWsrPerformanceReportError> ex)
{
    if (ex.Error.TryGetWsrErrorResponse(out var error))
    {
        // TODO: Handle 'error' of type WsrErrorResponse
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetWsrPerformanceReportRequest](src/WalmartApIs/Requests/WsrAttributionReports/GetWsrPerformanceReportRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[WsrPerformanceReportResponse](src/WalmartApIs/Models/WsrPerformanceReportResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetWsrPerformanceReportError](src/WalmartApIs/Errors/GetWsrPerformanceReportError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## WalmartSellerFulfilled

> Source: [WalmartSellerFulfilled](src/WalmartApIs/Api/WalmartSellerFulfilled.cs)

<details>
<summary><code>Task&lt;V3FeedsFeedTypeProgramActionsRequestTypeWalmartPlusSffResponse&gt; WalmartPlusEnrollment(WalmartPlusEnrollmentRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This API endpoint allows you to efficiently manage item participation in the Walmart+ program. Use it to enroll eligible items in Walmart+ or to unenroll items that are currently part of the program.<br><b style='color:green;'>Market availability: US</b> 



<b>Download and review the <a href="/file/mp/us/PROGRAM_ACTIONS_5.0.20250617-00_03_34_US_WalmartPlusEnrollment.xlsx">Excel template sample </a> and the <a href="/file/mp/us/bulk-enroll-requestBody-template.json">JSON body sample</a> to ensure proper formatting of the updated file before uploading it for processing.</b>

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WalmartSellerFulfilled.WalmartPlusEnrollment(new WalmartPlusEnrollmentRequest
    {
        FeedType = FeedType3.ProgramActions,
        RequestType = RequestType.WalmartPlusSff,
        WmSecAccessToken = "eyJraWQiOiIxNWNhNGIyYi0yODVjLTQ0ZDUtYmExNC05ZDk1NTlkZmUwNjgiLCJlbmMiOiJBMjU2R0NNIiwiYWxnIjoiZGlyIn0....",
        WmQosCorrelationId = "b3261d2d-028a-4ef7-8602-633c23200af6",
        WmSvcName = "Walmart Marketplace",
        WmMarket = WmMarket.Us,
        FileName = Array.Empty<byte>(),
    });
    // TODO: Handle 'response' of type V3FeedsFeedTypeProgramActionsRequestTypeWalmartPlusSffResponse
}
catch (ApiException<WalmartPlusEnrollmentError> ex)
{
    if (ex.Error.TryGetV3FeedsFeedTypeProgramActionsRequestTypeWalmartPlusSff400Error1(out var error))
    {
        // TODO: Handle 'error' of type V3FeedsFeedTypeProgramActionsRequestTypeWalmartPlusSff400Error1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[WalmartPlusEnrollmentRequest](src/WalmartApIs/Requests/WalmartSellerFulfilled/WalmartPlusEnrollmentRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[V3FeedsFeedTypeProgramActionsRequestTypeWalmartPlusSffResponse](src/WalmartApIs/Models/V3FeedsFeedTypeProgramActionsRequestTypeWalmartPlusSffResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[WalmartPlusEnrollmentError](src/WalmartApIs/Errors/WalmartPlusEnrollmentError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

