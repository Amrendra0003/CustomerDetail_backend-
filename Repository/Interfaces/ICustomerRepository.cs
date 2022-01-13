using DemoRepository.Models;
using DemoRepository.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoRepository.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<CustomerDetails>> GetCustomers();
        Task<int> AddCustomerAddress(CustomerAddress customerAddress);
        Task<int> AddCustomerProfession(CustomerProfession customerProfession);
        Task<int> AddCustomerInformation(CustomerInformation customerInformation);
    }
}
