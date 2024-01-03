using MariyaCompany.Application.Abstractions.Database;
using MariyaCompany.Application.Abstractions.Entity;
using MariyaCompany.Application.Abstractions.Requests;
using MariyaCompany.Application.Abstractions.Responses;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using AutoMapper;

namespace MariyaCompany.Application.Handlers
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeRequest, CreateEmployeeResponse>
    {
        private readonly IRepository<Employee> _repositoryEmployees;
        private readonly IMapper _mapper;

        public CreateEmployeeHandler(IRepository<Employee> repositoryEmployees, IMapper mapper)
        {
            _repositoryEmployees = repositoryEmployees;
            _mapper = mapper;
        }

        public async Task<CreateEmployeeResponse> Handle(CreateEmployeeRequest request, CancellationToken cancellationToken)
        {
            var employee = _mapper.Map<Employee>(request);

            var isCreate = _repositoryEmployees.Create(employee);

            return isCreate
                ? new CreateEmployeeResponse() { EmployeeId = employee.Id }
                : new CreateEmployeeResponse() { IsSuccess = false, ErrorMessage = "Пользователь не создался" };
        }
    }
}