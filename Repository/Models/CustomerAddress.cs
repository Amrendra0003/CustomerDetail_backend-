using System.Collections.Generic;

#nullable disable

namespace DemoRepository.Models
{
    public partial class CustomerAddress
    {
        public CustomerAddress()
        {
            CustomerInformations = new HashSet<CustomerInformation>();
        }

        public int Id { get; set; }
        public string Address { get; set; }
        public string StreetNo { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

        public virtual ICollection<CustomerInformation> CustomerInformations { get; set; }
    }
}
