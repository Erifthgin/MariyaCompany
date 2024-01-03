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
    public class GetCompanyPositionsHandler : IRequestHandler<GetCompanyPositionsRequest, CompanyPositionDetails[]>
    {
        private readonly IRepository<CompanyPosition> _repositoryCompanyPositions;
        private readonly IMapper _mapper;

        public GetCompanyPositionsHandler(IRepository<CompanyPosition> repositoryCompanyPositions, IMapper mapper)
        {
            _repositoryCompanyPositions = repositoryCompanyPositions;
            _mapper = mapper;
        }

        public async Task<CompanyPositionDetails[]> Handle(GetCompanyPositionsRequest request, CancellationToken cancellationToken)
        {
            var companies = _repositoryCompanyPositions.GetAll().ToArray();

            return _mapper.Map<CompanyPositionDetails[]>(companies);
        }
    }
}
