using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using S10_NCORE.Domain.Core.DTOs;
using S10_NCORE.Domain.Core.Interfaces;

namespace S10_NCORE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)          
        {
            _customerRepository = customerRepository;
        }


        [HttpGet]
        [Route("GetCustomers")]
        public async Task<IActionResult> GetCustomers()
        {
            //Es la forma basica: Muesta la entidad "Customer"
            //var customers = await _customerRepository.GetCustomers();
            //return Ok(customers);

            //Muesta el DTO "CustomerDTO". Muesta todos los datos
            //var customers = await _customerRepository.GetCustomers();
            //var customersList = new List<CustomerDTO>();
            //foreach(var item in customers)
            //{
            //    var customerDTO = new CustomerDTO()
            //    {
            //        FirstName = item.FirstName,
            //        LastName = item.LastName,
            //        Country = item.Country,
            //        City = item.City,
            //        Phone = item.Phone
            //    };
            //    customersList.Add(customerDTO);
            //}
            //return Ok(customersList);


            //Muesta el DTO "CustomerDTO". Muesta los datos ID, country, lastname
            var customers = await _customerRepository.GetCustomers();
            var customersList = new List<CustomerCountryDTO>();
            foreach (var item in customers)
            {
                var customerDTO = new CustomerCountryDTO()
                {
                    Id = item.Id,
                    LastName = item.LastName,
                    Country = item.Country
                };
                customersList.Add(customerDTO);
            }
            return Ok(customersList);
        }
    }
}
