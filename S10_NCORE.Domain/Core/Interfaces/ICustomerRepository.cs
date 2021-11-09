using System.Collections.Generic;
using System.Threading.Tasks;
using S10_NCORE.Domain.Core.Entities;

namespace S10_NCORE.Domain.Core.Interfaces
{
    public interface ICustomerRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer> GetCustomersById(int id);
        Task Insert(Customer customer);
        Task<bool> Update(Customer customer);
    }
}