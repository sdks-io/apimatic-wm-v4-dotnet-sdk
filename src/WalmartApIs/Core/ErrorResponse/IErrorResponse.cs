using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Core.ErrorResponse;

internal interface IErrorResponse<TError>
{
    Task<TError> Map(ResponseContext context, CancellationToken cancellationToken);
}