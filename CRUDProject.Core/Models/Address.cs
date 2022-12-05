namespace CRUDProject.Core.Models
{
    public class Address : BaseEntity
    {
        public string Name { get; set; }
        public string City { get; set; }
        public byte Type { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
