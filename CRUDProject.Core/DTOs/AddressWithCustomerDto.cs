using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDProject.Core.DTOs
{
    public class AddressWithCustomerDto : AddressDto
    {
        public CustomerDto Customer { get; set; }
    }
}
