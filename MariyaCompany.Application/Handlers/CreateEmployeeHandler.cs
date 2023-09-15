using MariyaCompany.Application.Abstractions.Database;
using MariyaCompany.Application.Abstractions.Entity;
using MariyaCompany.Application.Abstractions.Requests;
using MariyaCompany.Application.Abstractions.Responses;
using MediatR;
using System.Threading.Tasks;
using System.Threading;

namespace MariyaCompany.Application.Handlers
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeRequest, CreateEmployeeResponse>
    {
        private readonly IRepository<Employee> _repositoryEmployees;

        public CreateEmployeeHandler(IRepository<Employee> repositoryEmployees)
        {
            _repositoryEmployees = repositoryEmployees;
        }

        public async Task<CreateEmployeeResponse> Handle(CreateEmployeeRequest request, CancellationToken cancellationToken)
        {
            var employee = new Employee
            {
                Birthday = request.Birthday,
                EmploymentDate = request.EmploymentDate,
                FirstName = request.FirstName,
                LastName = request.LastName,
                MiddleName = request.MiddleName,
                DepartmentId = request.DepartmentId.Value,
                CompanyPositionId = request.CompanyPositionId.Value
            };

            var isCreate = _repositoryEmployees.Create(employee);

            return isCreate
                ? new CreateEmployeeResponse() { EmployeeId = employee.Id }
                : new CreateEmployeeResponse() { IsSuccess = false, ErrorMessage = "Пользователь не создался" };
        }
    }
}