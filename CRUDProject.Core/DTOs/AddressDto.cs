namespace CRUDProject.Core.DTOs
{
    public class AddressDto : BaseDto
    {
        public string Name { get; set; }
        public string City { get; set; }
        public byte Type { get; set; }
        public int CustomerId { get; set; }
    }
}
