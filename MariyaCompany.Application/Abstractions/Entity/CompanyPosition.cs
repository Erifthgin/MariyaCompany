namespace MariyaCompany.Application.Abstractions.Entity
{
    /// <summary>
    /// Список должностей
    /// </summary>
    public class CompanyPosition : DpEntity
    {
        public string Name { get; set; }

        public decimal Salary { get; set; }
    }
}