using MariyaCompany.Application.Abstractions.Database;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using MariyaCompany.Application.Abstractions.Requests;
using MariyaCompany.Application.Abstractions.Entity;
using System.Linq;
using MariyaCompany.Application.Abstractions.Objects.Enums;
using System;
using MariyaCompany.Application.Abstractions.Objects;
using AutoMapper;

namespace MariyaCompany.Application.Handlers
{
    internal class GetEmployeesHandler : IRequestHandler<GetEmployeesRequest, EmployeeDetails[]>
    {
        private readonly IRepository<Employee> _repositoryEmployees;
        private readonly IMapper _mapper;

        public GetEmployeesHandler(IRepository<Employee> repositoryEmployees, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryEmployees = repositoryEmployees;
        }

        public async Task<EmployeeDetails[]> Handle(GetEmployeesRequest request, CancellationToken cancellationToken)
        {
            var employees = _repositoryEmployees.GetAllWithSelectVirtual("CompanyPosition");

            employees = Filter(employees, request.Surname, request.AgeTo, request.AgeFrom, request.DepartmentId, request.CompanyPositionId);

            employees = Sort(employees, request.IsAsc, request.SortType);

            return _mapper.Map<EmployeeDetails[]>(employees.ToArray());
        }

        /// <summary>
        /// фильтрация
        /// </summary>
        public IQueryable<Employee> Filter(IQueryable<Employee> employees, string surname, int? ageTo, int? ageFrom, int? departmentId, int? companyPositionId)
        {
            if (!string.IsNullOrEmpty(surname))
            {
                employees = employees.Where(e => e.LastName == surname);
            }

            var dtNowYear = new DateTime().Year;

            if (ageTo != null)
            {
                employees = employees.Where(e => (dtNowYear - e.Birthday.Year) < ageTo);
            }

            if (ageFrom != null)
            {
                employees = employees.Where(e => (dtNowYear - e.Birthday.Year) > ageFrom);
            }

            if (departmentId != null)
            {
                employees = employees.Where(e => e.DepartmentId == departmentId);
            }

            if (companyPositionId != null)
            {
                employees = employees.Where(e => e.CompanyPositionId == companyPositionId);
            }

            return employees;
        }

        /// <summary>
        /// сортировка
        /// </summary>
        public IQueryable<Employee> Sort(IQueryable<Employee> employees, bool? isAscNull, int? sortTypeInt)
        {
            var sortType = GetSortType(sortTypeInt);

            var isAsc = isAscNull != null && isAscNull.Value;

            switch (sortType)
            {
                case SortType.Department:
                    return isAsc ? employees.OrderBy(e => e.DepartmentId) : employees.OrderByDescending(e => e.DepartmentId);
                case SortType.Surname:
                    return isAsc ? employees.OrderBy(e => e.FirstName) : employees.OrderByDescending(e => e.FirstName);
                case SortType.Birthday:
                    return isAsc ? employees.OrderBy(e => e.Birthday) : employees.OrderByDescending(e => e.Birthday);
                case SortType.EmployementDate:
                    return isAsc ? employees.OrderBy(e => e.EmploymentDate) : employees.OrderByDescending(e => e.EmploymentDate);
                case SortType.CompanyPosition:
                    return isAsc ? employees.OrderBy(e => e.CompanyPositionId) : employees.OrderByDescending(e => e.CompanyPositionId);
            }

            return employees;
        }

        /// <summary>
        /// маппинг типа с фронта
        /// </summary>
        private SortType GetSortType(int? sortType)
        {
            if (sortType == null)
            {
                return SortType.None;
            }

            return (SortType)sortType;
        }
    }
}
