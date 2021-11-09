using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using S10_NCORE.Domain.Core.Entities;
using S10_NCORE.Domain.Infraestructure.Data;

namespace S10_NCORE.Domain.Infraestructure.Repositories
{
    class CustomerRepository
    {
        private readonly SalesContext _context;

        public CustomerRepository(SalesContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            //using var data = new SalesContext();
            return await _context.Customer.ToListAsync();

        }
        public async Task<Customer> GetCustomersById(int id)
        {
            return await _context.Customer.Where(x=> x.Id==id).FirstOrDefaultAsync();

        }

        public async Task Insert(Customer customer)
        {
            await _context.Customer.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Update(Customer customer)
        {
            var cutomerNow = await _context.Customer.FindAsync(customer.Id);
            cutomerNow.FirstName = customer.FirstName;
            cutomerNow.LastName = customer.LastName;
            cutomerNow.Country = customer.Country;
            cutomerNow.City = customer.City;
            cutomerNow.Phone = customer.Phone;

            int countRow = await _context.SaveChangesAsync();
            return (countRow > 0);
        }

        public async Task<bool> Delete(int id)
        {
            var customerNow = await _context.Customer.FindAsync(id);
            if (customerNow == null)
                return false;
            _context.Customer.Remove(customerNow);
            int coutRows = await _context.SaveChangesAsync();
            return (coutRows > 0);
        }
    }
}
