using DemoRepository.Interfaces;
using DemoRepository.Models;
using DemoRepository.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DemoRepository.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        masterContext _db;
        public CustomerRepository(masterContext db)
        {
            _db = db;
        }
        public void delete()
        {
            _db.Database.ExecuteSqlRaw("delete from [CustomerInformation]");
            _db.Database.ExecuteSqlRaw("delete from [CustomerProfession]");
            _db.Database.ExecuteSqlRaw("delete from [CustomerAddress]");
        }
        public async Task<List<CustomerDetails>> GetCustomers()
        {
            if (_db != null)
            {
                return await (from a in _db.CustomerAddresses
                              from i in _db.CustomerInformations
                              from p in _db.CustomerProfessions
                              where (a.Id == i.CustomerAddressId && 
                               p.Id == i.CustomerProfessionId)
                              select new CustomerDetails
                              {
                                  Id = i.Id,
                                  FirstName = i.FirstName,
                                  LastName = i.LastName,
                                  DateOfBirth = i.DateOfBirth,
                                  Gender = i.Gender,
                                  PhoneNumber = i.PhoneNumber,
                                  JobTitle = p.JobTitle,
                                  JobDetail = p.JobDetail,
                                  CompanyName = p.CompanyName,
                                  EmployeeId = p.EmployeeId,
                                  Address = a.Address,
                                  StreetNo = a.StreetNo,
                                  State = a.State,
                                  Country = a.Country,
                                  ZipCode = a.ZipCode
                              }).ToListAsync();
            }

            return null;
        }
        public async Task<int> AddCustomerAddress(CustomerAddress customerAddress)
        {
            if (_db != null)
            {
                await _db.CustomerAddresses.AddAsync(customerAddress);
                await _db.SaveChangesAsync();
                return customerAddress.Id;
            }
            return 0;
        }
        public async Task<int> AddCustomerProfession(CustomerProfession customerProfession)
        {
            if (_db != null)
            {
                await _db.CustomerProfessions.AddAsync(customerProfession);
                await _db.SaveChangesAsync();
                return customerProfession.Id;
            }
            return 0;
        }
        public async Task<int> AddCustomerInformation(CustomerInformation customerInformation)
        {
            if (_db != null)
            {
                await _db.CustomerInformations.AddAsync(customerInformation);
                await _db.SaveChangesAsync();
                return customerInformation.Id;
            }
            return 0;
        }
    }
}
