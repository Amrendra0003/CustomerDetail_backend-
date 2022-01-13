using DemoRepository.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoServices.Interfaces
{
    public interface ICustomerService
    {
        Task<List<CustomerDetails>> GetCustomers();
        Task<int> AddCustomer(CustomerDetails customerDetailsModel);
    }
}
