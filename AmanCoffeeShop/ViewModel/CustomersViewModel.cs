using AmanCoffeeShop.Data;
using AmanCoffeeShop.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmanCoffeeShop.ViewModel
{
    public class CustomersViewModel
    {
        private readonly ICustomerDataProvider _customerDataProvider;
        public CustomersViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerDataProvider = customerDataProvider;
        }
        public ObservableCollection<Customer> Customers { get; } = new ObservableCollection<Customer>();

        public async Task LoadAllAsync()
        {
            if(Customers != null)
            {
                return;
            }
            var customer = await _customerDataProvider.GetAllAsync();
            foreach(var item in customer)
            {
                Customers.Add(item);
            }
        }
    }
}
