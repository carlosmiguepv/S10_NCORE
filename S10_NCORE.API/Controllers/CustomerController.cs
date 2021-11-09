using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using S10_NCORE.Domain.Core.DTOs;
using S10_NCORE.Domain.Core.Entities;
using S10_NCORE.Domain.Core.Interfaces;

namespace S10_NCORE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        private readonly IMapper _mapper;

        public CustomerController(ICustomerRepository customerRepository, IMapper mapper)          
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
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
            //var customers = await _customerRepository.GetCustomers();
            //var customersList = new List<CustomerCountryDTO>();
            //foreach (var item in customers)
            //{
            //    var customerDTO = new CustomerCountryDTO()
            //    {
            //        Id = item.Id,
            //        LastName = item.LastName,
            //        Country = item.Country
            //    };
            //    customersList.Add(customerDTO);
            //}


            //ACA USAMOS EL MAPPING
            var customers = await _customerRepository.GetCustomers();
            var customersList = _mapper.Map<IEnumerable<CustomerDTO>>(customers);

            return Ok(customersList);
        }

        //Buscar
        [HttpGet]
        [Route("GetCustomerById/{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _customerRepository.GetCustomersById(id);
            if (customer == null)
                return NotFound();
            var customerDTO = _mapper.Map<CustomerDTO>(customer);
            return Ok(customerDTO);
        }

        //Agregar
        [HttpPost]
        [Route("PostCustomer")]
        public async Task<IActionResult> PostCustomer(CustomerPostDTO customerDTO)
        {
            var customer = _mapper.Map<Customer>(customerDTO);
            await _customerRepository.Insert(customer);
            return Ok(customer);
        }

        //Actualizar
        [HttpPut]
        [Route("PutCustomer")]
        public async Task<IActionResult> PutCustomer(CustomerDTO customerDTO)
        {
            var customer = _mapper.Map<Customer>(customerDTO);
            await _customerRepository.Update(customer);
            return Ok(customer);
        }

        //Eliminar
        [HttpDelete]
        [Route("DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var result = await _customerRepository.Delete(id);
            if (!result)
                return NotFound();
            return NoContent();
        }
    }
}
