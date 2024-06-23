using artTech.Controll;
using artTech.Models.Peeson;
using artTech.Models.Specification;
using Microsoft.Identity.Client.NativeInterop;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace artTech.ViewModels
{
    public class AdminPage_ViewModel : ViewModelBase
    {
        private readonly ObservableCollection<User> _Specification;

        public IEnumerable<User> Specifications => _Specification;

        public AdminPage_ViewModel()
        {
            _Specification = new ObservableCollection<User>();

            foreach(var use in Account_Control.Users)
            {
                _Specification.Add(new User(use.Id, use.Name, use.Email));
            }
        }
    }
}
