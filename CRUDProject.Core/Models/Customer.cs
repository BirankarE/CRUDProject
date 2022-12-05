namespace CRUDProject.Core.Models
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
