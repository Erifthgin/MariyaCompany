using System;

namespace MariyaCompany.Application.Abstractions.Objects
{
    public class EmployeeDetails
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime EmploymentDate { get; set; }
        public int DepartmentId { get; set; }
        public int CompanyPositionId { get; set; }
        public virtual DepartmentDetails Department { get; set; }
        public virtual CompanyPositionDetails CompanyPosition { get; set; }
    }
}
