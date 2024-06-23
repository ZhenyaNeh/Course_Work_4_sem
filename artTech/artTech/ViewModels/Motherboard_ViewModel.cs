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
    public class Motherboard_ViewModel : ViewModelBase
    {
        private readonly ObservableCollection<Specification> _Specification;
        private readonly ObservableCollection<Specification> _Comment;

        public IEnumerable<Specification> Specifications => _Specification;
        public IEnumerable<Specification> Comments => _Comment;


        public Motherboard_ViewModel(Motherboard motherboard)
        {
            _Specification = new ObservableCollection<Specification>()
            {
                new("CPU Spport", motherboard.Motherboard_CPU_Spport),
                new("Socket", motherboard.Motherboard_Socket),
                new("Formfactor", motherboard.Motherboard_FormFactor),
                new("Memory Support", motherboard.Motherboard_MemorySupport),
                new("Number Of RAM Slots", motherboard.Motherboard_NumberOf_RAM_Slots.ToString()),
                new("Maximum RAM Capacity", motherboard.Motherboard_Maximum_RAM_Capacity.ToString()),
                new("Maximum RAM Frequency", motherboard.Motherboard_Maximum_RAM_Frequency.ToString()),
                new("Number Of M2 Slots", motherboard.Motherboard_NumberOf_M2_Slots.ToString()),
                new("Number Of SATA3 Slots", motherboard.Motherboard_NumberOf_SATA3_Slots.ToString()),
            };

            List<Comment> list_Comment = new List<Comment>();

            using (var context = new ConfigPCContext())
            {
                list_Comment = context.Comments.Where(x => x.MotherboardId == motherboard.Id).ToList();

            }

            _Comment = new ObservableCollection<Specification>();
            foreach (var item in list_Comment)
            {
                _Comment.Add(new Specification(item.NamePerson, item.CommentString));
            }
        }
    }
}
