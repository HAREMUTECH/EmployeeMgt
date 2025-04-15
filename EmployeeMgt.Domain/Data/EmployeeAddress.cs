namespace EmployeeMgt.Domain.Data
{
    public class EmployeeAddress : BaseEntity
    {
        public string PostalCode { get; set; }
        public string HomeAddress { get; set; }
        public string LocalGovernment { get; set; }
        public bool IsDefault { get; set; }
    }

}
