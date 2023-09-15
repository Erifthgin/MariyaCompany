using MariyaCompany.Application.Abstractions.Database;
using MariyaCompany.Application.Abstractions.Entity;
using MariyaCompany.Application.Abstractions.Requests;
using MariyaCompany.Application.Abstractions.Responses;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace MariyaCompany.Application.Handlers
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeRequest, BaseResponce>
    {
        private readonly IRepository<Employee> _repositoryEmployees;

        public UpdateEmployeeHandler(IRepository<Employee> repositoryEmployees)
        {
            _repositoryEmployees = repositoryEmployees;
        }

        public async Task<BaseResponce> Handle(UpdateEmployeeRequest request, CancellationToken cancellationToken)
        {

            var employee = _repositoryEmployees.FindById(request.Id);

            if (employee == null)
            {
                return new CreateEmployeeResponse() { IsSuccess = false, ErrorMessage = "Пользователя нет в системе" };
            }

            var updateEmployee = UpdateItem(employee, request.FirstName, request.MiddleName, request.LastName, request.Birthday, request.EmploymentDate, request.DepartmentId, request.CompanyPositionId);

            var isUpdate = _repositoryEmployees.Update(updateEmployee);

            return isUpdate
                ? new CreateEmployeeResponse() { EmployeeId = employee.Id }
                : new CreateEmployeeResponse() { IsSuccess = false, ErrorMessage = "Пользователь не обновился" };
        }

        private Employee UpdateItem(Employee employee, string firstName, string middleName,string lastName,DateTime? birthday,DateTime? employmentDate,int? departmentId,int? companyPositionId)
        {
            if (!string.IsNullOrEmpty (firstName))
            {
                employee.FirstName = firstName;
            }

            if (!string.IsNullOrEmpty(middleName))
            {
                employee.MiddleName = middleName;
            }

            if (!string.IsNullOrEmpty(lastName))
            {
                employee.LastName = lastName;
            }

            if (birthday != null)
            {
                employee.Birthday = birthday.Value;
            }

            if (employmentDate != null)
            {
                employee.EmploymentDate = employmentDate.Value;
            }

            if (departmentId != null)
            {
                employee.DepartmentId = departmentId.Value;
            }

            if (companyPositionId != null)
            {
                employee.CompanyPositionId = companyPositionId.Value;
            }

            return employee;
        }
    }
}