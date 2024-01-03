using MariyaCompany.Application.Abstractions.Database;
using MariyaCompany.Application.Abstractions.Entity;
using MariyaCompany.Application.Abstractions.Requests;

using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using MariyaCompany.Application.Abstractions.Objects;
using AutoMapper;

namespace MariyaCompany.Application.Handlers
{
    public class GetDepartmentsHandler : IRequestHandler<GetDepartmentsRequest, DepartmentDetails[]>
    {
        private readonly IRepository<Department> _repositoryDepartment;
        private readonly IMapper _mapper;

        public GetDepartmentsHandler(IRepository<Department> repositoryDepartment, IMapper mapper)
        {
            _repositoryDepartment = repositoryDepartment;
            _mapper = mapper;
        }

        public async Task<DepartmentDetails[]> Handle(GetDepartmentsRequest request, CancellationToken cancellationToken)
        {
            var departments = _repositoryDepartment.GetAll().ToArray();

            return _mapper.Map<DepartmentDetails[]>(departments);
        }
    }
}

