using System;

namespace DemoRepository.Models.ViewModels
{
    public class CustomerDetails
    {
        public readonly object Convertable;

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool? Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string JobTitle { get; set; }
        public string JobDetail { get; set; }
        public string CompanyName { get; set; }
        public string EmployeeId { get; set; }
        public string Address { get; set; }
        public string StreetNo { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }
}
