using AmanCoffeeShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmanCoffeeShop.ViewModel
{
    public class CustomerItemViewModel : ViewModelBase
    {
        private readonly Customer _model;
        public CustomerItemViewModel(Customer model)
        {
            _model = model;
        }

        public int Id => _model.Id;

        public string FirstName
        {
            get { return _model.FirstName; }
            set { _model.FirstName = value;
                RaisePropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get { return _model.LastName; }
            set
            {
                _model.LastName = value;
                RaisePropertyChanged("LastName");
            }
        }

        public bool IsDeveloper
        {
            get { return _model.IsDeveloper; }
            set
            {
                _model.IsDeveloper = value;
                RaisePropertyChanged("IsDeveloper");
            }
        }

    }
}
