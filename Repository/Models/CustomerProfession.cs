using System.Collections.Generic;

#nullable disable

namespace DemoRepository.Models
{
    public partial class CustomerProfession
    {
        public CustomerProfession()
        {
            CustomerInformations = new HashSet<CustomerInformation>();
        }

        public int Id { get; set; }
        public string JobTitle { get; set; }
        public string JobDetail { get; set; }
        public string CompanyName { get; set; }
        public string EmployeeId { get; set; }

        public virtual ICollection<CustomerInformation> CustomerInformations { get; set; }
    }
}
