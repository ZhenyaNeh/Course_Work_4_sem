using artTech.Data;
using artTech.Models;
using artTech.Models.Peeson;
using artTech.Models.Specification;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace artTech.ViewModels
{
    public class SSD_ViewModel : ViewModelBase
    {
        private readonly ObservableCollection<Specification> _Specification;
        private readonly ObservableCollection<Specification> _Comment;

        public IEnumerable<Specification> Specifications => _Specification;
        public IEnumerable<Specification> Comments => _Comment;


        public SSD_ViewModel(SSD ssd)
        {
            _Specification = new ObservableCollection<Specification>()
            {
                new("FormFactor", ssd.SSD_FormFactor),
                new("Size", ssd.SSD_Size),
            };

            List<Comment> list_Comment = new List<Comment>();

            using (var context = new ConfigPCContext())
            {
                list_Comment = context.Comments.Where(x => x.SSDId == ssd.Id).ToList();

            }

            _Comment = new ObservableCollection<Specification>();
            foreach (var item in list_Comment)
            {
                _Comment.Add(new Specification(item.NamePerson, item.CommentString));
            }
        }
    }
}
