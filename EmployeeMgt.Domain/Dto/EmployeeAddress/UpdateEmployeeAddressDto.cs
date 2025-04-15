namespace EmployeeMgt.Domain.Dto.EmployeeAddress
{
    public class UpdateEmployeeAddressDto
    {
        public Guid Id { get; set; }
        public string PostalCode { get; set; }
        public string HomeAddress { get; set; }
        public string LocalGovernment { get; set; }
        public bool IsDefault { get; set; }
    }
}
