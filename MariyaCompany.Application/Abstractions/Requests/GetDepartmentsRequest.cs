using MariyaCompany.Application.Abstractions.Entity;
using MediatR;

namespace MariyaCompany.Application.Abstractions.Requests
{
    public class GetDepartmentsRequest : IRequest<Department[]>
    {
    }
}
