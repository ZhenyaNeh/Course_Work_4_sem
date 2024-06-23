using artTech.Models.Specification;
using artTech.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using artTech.Data;
using artTech.Models.Peeson;

namespace artTech.ViewModels
{
    public class ComputerCase_ViewModel : ViewModelBase
    {
        private readonly ObservableCollection<Specification> _Specification;
        private readonly ObservableCollection<Specification> _Comment;

        public IEnumerable<Specification> Specifications => _Specification;
        public IEnumerable<Specification> Comments => _Comment;


        public ComputerCase_ViewModel(ComputerCase computerCase)
        {
            string support = "";
            foreach(var item in computerCase.ComputerCase_SupportedMotherboards)
                support += (item + ", ");


            _Specification = new ObservableCollection<Specification>()
            {
                new("Supported Motherboards", support),
            };


            List<Comment> list_Comment = new List<Comment>();

            using (var context = new ConfigPCContext())
            {
                list_Comment = context.Comments.Where(x => x.ComputerCaseId == computerCase.Id).ToList();

            }

            _Comment = new ObservableCollection<Specification>();
            foreach (var item in list_Comment)
            {
                _Comment.Add(new Specification(item.NamePerson, item.CommentString));
            }
        }
    }
}
