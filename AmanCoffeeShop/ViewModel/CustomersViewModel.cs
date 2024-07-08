using AmanCoffeeShop.Command;
using AmanCoffeeShop.Data;
using AmanCoffeeShop.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AmanCoffeeShop.ViewModel.CustomersViewModel;

namespace AmanCoffeeShop.ViewModel
{
    public class CustomersViewModel : ViewModelBase
    {
        private readonly ICustomerDataProvider _customerDataProvider;

        public DelegateCommand AddCommand { get; }
        public DelegateCommand MoveCommand { get; }
        public DelegateCommand DeleteCommand { get; }


        private CustomerItemViewModel _selectedCustomer;
        private NavigationSides navigationSide;

        public CustomersViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerDataProvider = customerDataProvider;
            AddCommand = new DelegateCommand(Add);
            MoveCommand = new DelegateCommand(MoveNavigation);
            DeleteCommand = new DelegateCommand(Delete, CanDelete);
        }

        public ObservableCollection<CustomerItemViewModel> Customers { get; } = new ObservableCollection<CustomerItemViewModel>();

        public CustomerItemViewModel SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                RaisePropertyChanged(nameof(SelectedCustomer));
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        public NavigationSides NavigationSide
        {
            get => navigationSide;
            private set
            {
                navigationSide = value;
                RaisePropertyChanged("NavigationSide");
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

        public void Add(object parameter)
        {
            var customer = new Customer { FirstName = "New" };
            var viewmodel = new CustomerItemViewModel(customer);
            Customers.Add(viewmodel);
            SelectedCustomer = viewmodel;
        }

        private void Delete(object obj)
        {
            if(SelectedCustomer != null)
            {
                Customers.Remove(SelectedCustomer);
                SelectedCustomer = null;
            }
        }

        private bool CanDelete(object arg)
        {
            return SelectedCustomer != null;
        }

        internal void MoveNavigation(object parameter)
        {
            NavigationSide = NavigationSide == NavigationSides.Left ? NavigationSides.Right : NavigationSides.Left;
        }

        public enum NavigationSides
        {
            Left,Right 
        }
    }
}
