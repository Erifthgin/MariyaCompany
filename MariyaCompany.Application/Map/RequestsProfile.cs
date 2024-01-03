using AutoMapper;
using MariyaCompany.Application.Abstractions.Entity;
using MariyaCompany.Application.Abstractions.Objects;
using MariyaCompany.Application.Abstractions.Requests;

namespace MariyaCompany.Application.Map
{
    public class RequestsProfile : Profile
    {
        public RequestsProfile()
        {
            CreateMap<CreateEmployeeRequest, Employee>();

            CreateMap<Employee, EmployeeDetails>();
            CreateMap<Department, DepartmentDetails>();
            CreateMap<CompanyPosition, CompanyPositionDetails>();
        }
    }
}
