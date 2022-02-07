using DemoRepository.Interfaces;
using DemoRepository.Models;
using DemoRepository.Models.ViewModels;
using DemoServices.Helper;
using DemoServices.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoServices.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<List<CustomerDetails>> GetCustomers()
        {
            var customers = await _customerRepository.GetCustomers();
            return customers;
        }
        public async Task<int> AddCustomer(CustomerDetails customerDetailsModel)
        {

            var customerAddress = (customerDetailsModel).MapProperties<CustomerAddress>();
            var customerAddressId = await _customerRepository.AddCustomerAddress(customerAddress);
            var customerProfession = (customerDetailsModel).MapProperties<CustomerProfession>();
            var customerProfessionId = await _customerRepository.AddCustomerProfession(customerProfession);
            var customerInformation = (customerDetailsModel).MapProperties<CustomerInformation>();
            customerInformation.CustomerAddressId = customerAddressId;
            customerInformation.CustomerProfessionId = customerProfessionId;
            var customerInformationId = await _customerRepository.AddCustomerInformation(customerInformation);
            return customerInformationId;
        }
    }
}
