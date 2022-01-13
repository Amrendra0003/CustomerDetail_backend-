using System;

#nullable disable

namespace DemoRepository.Models
{
    public partial class CustomerInformation
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool? Gender { get; set; }
        public string PhoneNumber { get; set; }
        public int? CustomerAddressId { get; set; }
        public int? CustomerProfessionId { get; set; }

        public virtual CustomerAddress CustomerAddress { get; set; }
        public virtual CustomerProfession CustomerProfession { get; set; }
    }
}
