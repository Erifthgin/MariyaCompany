using MariyaCompany.Application.Abstractions.Database;
using MariyaCompany.Application.Abstractions.Entity;
using MariyaCompany.Application.Abstractions.Requests;
using MariyaCompany.Application.Abstractions.Responses;
using MediatR;
using System.Threading.Tasks;
using System.Threading;

namespace MariyaCompany.Application.Handlers
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeRequest, BaseResponce>
    {
        private readonly IRepository<Employee> _repositoryEmployees;

        public DeleteEmployeeHandler(IRepository<Employee> repositoryEmployees)
        {
            _repositoryEmployees = repositoryEmployees;
        }

        public async Task<BaseResponce> Handle(DeleteEmployeeRequest request, CancellationToken cancellationToken)
        {
            var employee =_repositoryEmployees.FindById(request.EmployeeId);

            if (employee == null)
            {
                return new CreateEmployeeResponse() { IsSuccess = false, ErrorMessage = "Данного пользователя нет в системе" };
            }

            var isRemove = _repositoryEmployees.Remove(employee);

            return isRemove
                ? new CreateEmployeeResponse() { EmployeeId = employee.Id }
                : new CreateEmployeeResponse() { IsSuccess = false, ErrorMessage = "Пользователь не удалился" };
        }
    }
}