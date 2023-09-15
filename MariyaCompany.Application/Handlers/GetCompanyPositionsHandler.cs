using MariyaCompany.Application.Abstractions.Database;
using MariyaCompany.Application.Abstractions.Entity;
using MariyaCompany.Application.Abstractions.Requests;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace MariyaCompany.Application.Handlers
{
    public class GetCompanyPositionsHandler : IRequestHandler<GetCompanyPositionsRequest, CompanyPosition[]>
    {
        private readonly IRepository<CompanyPosition> _repositoryCompanyPositions;

        public GetCompanyPositionsHandler(IRepository<CompanyPosition> repositoryCompanyPositions)
        {
            _repositoryCompanyPositions = repositoryCompanyPositions;
        }

        public async Task<CompanyPosition[]> Handle(GetCompanyPositionsRequest request, CancellationToken cancellationToken)
        {
            var employees = _repositoryCompanyPositions.GetAll().ToArray();

            return employees;
        }
    }
}
