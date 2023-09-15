using MariyaCompany.Application.Abstractions.Entity;
using MediatR;

namespace MariyaCompany.Application.Abstractions.Requests
{
    public class GetEmployeesRequest : IRequest<Employee[]>
    {
        public string Surname { get; set; }

        public int? AgeTo { get; set; }

        public int? AgeFrom { get; set; }

        public int? DepartmentId { get; set; }

        public int? CompanyPositionId { get; set; }

        public bool? IsAsc { get; set; }

        public int? SortType { get; set; }
    }
}
