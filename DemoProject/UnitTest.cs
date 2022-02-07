using Demo_Project_Backend.Controllers;
using DemoRepository.Interfaces;
using DemoRepository.Models;
using DemoRepository.Models.ViewModels;
using DemoRepository.Repository;
using DemoServices.Interfaces;
using DemoServices.Services;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DemoProject.Test
{
    public class UnitTest
    {

        private readonly CustomerController controller;
        private readonly ICustomerRepository _rep;
        private readonly ICustomerService _service;
        private readonly masterContext _master;
        //Using test database not actual
        public static string connectionString = "Server=localhost;Database=master;Trusted_Connection=True;";
        public static DbContextOptions<masterContext> dbContextOptions { get; }
        static UnitTest()
        {
            dbContextOptions = new DbContextOptionsBuilder<masterContext>()
.UseSqlServer(connectionString)
.Options;   

        }
        public UnitTest()
        {
            _master = new masterContext(dbContextOptions);
            _rep = new CustomerRepository(_master);
            _service = new CustomerService(_rep);
            controller = new CustomerController(_service);
        }
        [Fact]
        public async void Task_Add_ValidData_Return_OkResult()
        {
            _rep.delete();
            //Arrange  
            var customerDetailsModel = new CustomerDetails() { Id = 0, Address = "Test Address 2", StreetNo = "2", State = "Test State2", Country = "Test Country2", ZipCode = "12345", CompanyName = "Test Company2", FirstName = "Test Name2", Gender = true, DateOfBirth = Convert.ToDateTime("01/01/2022"), JobDetail = "Test Detail2", EmployeeId = "0", JobTitle = "Test Job Title2", LastName = "Test LastName2", PhoneNumber = "1234567891" };
          
            //Act  
            var data = await controller.AddCustomer(customerDetailsModel);

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }
        [Fact]
        public async void Task_GetPosts_MatchResult()
        {
            //Arrange  


            //Act  
            var data = await controller.GetCustomers();

            //Assert  
            Assert.IsType<OkObjectResult>(data);

            var okresult = data.Should().BeOfType<OkObjectResult>().Subject;
            var customer = okresult.Value.Should().BeAssignableTo<List<CustomerDetails>>().Subject;

            Assert.Equal("Test Name2", customer[0].FirstName);
            Assert.Equal("Test LastName2", customer[0].LastName);
            Assert.Equal("Test Address 2", customer[0].Address);
            Assert.Equal("1234567891", customer[0].PhoneNumber);
            Assert.Equal("Test Company2", customer[0].CompanyName);
            Assert.Equal("Test Job Title2", customer[0].JobTitle);
            Assert.Equal("Test Detail2", customer[0].JobDetail);
            Assert.Equal("Test Country2", customer[0].Country);
            Assert.Equal("Test State2", customer[0].State);
            Assert.Equal("12345", customer[0].ZipCode);
            Assert.Equal("2", customer[0].StreetNo);
        }
        
    }
}
