using MariyaCompany.Application.Abstractions.Responses;
using MediatR;
using System;

namespace MariyaCompany.Application.Abstractions.Requests
{
    public class CreateEmployeeRequest : IRequest<CreateEmployeeResponse>
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        public DateTime EmploymentDate { get; set; }

        public int? DepartmentId { get; set; }

        public int? CompanyPositionId { get; set; }
    }
}
