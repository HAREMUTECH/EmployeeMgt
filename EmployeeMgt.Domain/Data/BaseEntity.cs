namespace EmployeeMgt.Domain.Data
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTimeOffset Datecreated { get; set; }
        public DateTimeOffset DateModified { get; set; }
    }

}
