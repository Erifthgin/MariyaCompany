using MariyaCompany.Application.Abstractions.Objects;
using MediatR;

namespace MariyaCompany.Application.Abstractions.Requests
{
    public class GetDepartmentsRequest : IRequest<DepartmentDetails[]>
    {
    }
}
