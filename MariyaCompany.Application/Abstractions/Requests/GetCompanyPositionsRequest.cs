using MariyaCompany.Application.Abstractions.Objects;
using MediatR;

namespace MariyaCompany.Application.Abstractions.Requests
{
    public class GetCompanyPositionsRequest : IRequest<CompanyPositionDetails[]>
    {
    }
}