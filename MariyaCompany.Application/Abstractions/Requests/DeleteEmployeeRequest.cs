using MariyaCompany.Application.Abstractions.Responses;
using MediatR;

namespace MariyaCompany.Application.Abstractions.Requests
{
    public class DeleteEmployeeRequest : IRequest<BaseResponce>
    {
        public DeleteEmployeeRequest(int employeeId)
        {
            EmployeeId = employeeId;
        }

        public int EmployeeId { get; set; }
    }
}
