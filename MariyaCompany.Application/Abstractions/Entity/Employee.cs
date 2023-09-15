using System;

namespace MariyaCompany.Application.Abstractions.Entity
{
    public class Employee : DpEntity
    {
        /// <summary>
        /// имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// отчество
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// фамилия
        /// </summary>
        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        public DateTime EmploymentDate { get; set; }

        public int DepartmentId { get; set; }

        public int CompanyPositionId { get; set; }

        public virtual Department Department { get; set; }

        public virtual CompanyPosition CompanyPosition { get; set; }
    }
}
