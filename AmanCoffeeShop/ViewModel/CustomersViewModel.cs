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
    public class CustomersViewModel : ViewModelBase
    {
        private readonly ICustomerDataProvider _customerDataProvider;
        private CustomerItemViewModel _selectedCustomer;
        private int navigationColumn;

        public CustomersViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerDataProvider = customerDataProvider;
        }
        public ObservableCollection<CustomerItemViewModel> Customers { get; } = new ObservableCollection<CustomerItemViewModel>();

        public CustomerItemViewModel SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                RaisePropertyChanged(nameof(SelectedCustomer));
            }
        }

        public async Task LoadAllAsync()
        {
            var customer = await _customerDataProvider.GetAllAsync();
            foreach (var item in customer)
            {
                Customers.Add(new CustomerItemViewModel(item));
            }
        }

        public void Add()
        {
            var customer = new Customer { FirstName = "New" };
            var viewmodel = new CustomerItemViewModel(customer);
            Customers.Add(viewmodel);
            SelectedCustomer = viewmodel;
        }

        public int NavigationColumn
        {
            get => navigationColumn;
            private set 
            { 
                navigationColumn = value;
                RaisePropertyChanged("NavigationColumn"); 
            }
        }

        internal void MoveNavigation()
        {
            NavigationColumn = NavigationColumn == 0 ? 2 : 0;
        }
    }
}
