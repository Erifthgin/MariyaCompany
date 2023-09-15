using MariyaCompany.Application.Abstractions.Database;
using MariyaCompany.Application.Abstractions.Entity;
using MariyaCompany.Application.Abstractions.Requests;

using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace MariyaCompany.Application.Handlers
{
    public class GetDepartmentsHandler : IRequestHandler<GetDepartmentsRequest, Department[]>
    {
        private readonly IRepository<Department> _repositoryDepartment;

        public GetDepartmentsHandler(IRepository<Department> repositoryDepartment)
        {
            _repositoryDepartment = repositoryDepartment;
        }

        public async Task<Department[]> Handle(GetDepartmentsRequest request, CancellationToken cancellationToken)
        {
            var employees = _repositoryDepartment.GetAll().ToArray();

            return employees;
        }
    }
}

