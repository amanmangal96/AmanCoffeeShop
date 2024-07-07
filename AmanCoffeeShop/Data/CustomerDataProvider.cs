using AmanCoffeeShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmanCoffeeShop.Data
{
    public interface ICustomerDataProvider
    {
        Task<IEnumerable<Customer>> GetAllAsync();
    }
    internal class CustomerDataProvider : ICustomerDataProvider
    {
        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            await Task.Delay(100);
            return new List<Customer> 
            { 
              new Customer { Id=1 , FirstName="Aman", LastName="mangal", IsDeveloper=true},
              new Customer { Id=2 , FirstName="Ayush", LastName="mangal", IsDeveloper=true},
              new Customer { Id=3 , FirstName="Arun", LastName="Singh", IsDeveloper=false},
              new Customer { Id=4 , FirstName="Ram", LastName="Bansal", IsDeveloper=false},
              new Customer { Id=5 , FirstName="Rahul", LastName="Sharma", IsDeveloper=false},
              new Customer { Id=6 , FirstName="Vivek", LastName="Tyagi", IsDeveloper=false},
            };
        }
    }
}
