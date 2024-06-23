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
    public class CPU_ViewModel : ViewModelBase
    {
        private readonly ObservableCollection<Specification> _Specification;
        private readonly ObservableCollection<Specification> _Comment;
        public IEnumerable<Specification> Specifications => _Specification;
        public IEnumerable<Specification> Comments => _Comment;

        public CPU_ViewModel(CPU cpu)
        {
            _Specification = new ObservableCollection<Specification>()
            {
                new("Manufacturer", cpu.CPU_Manufacturer),
                new("Socket", cpu.CPU_Socket),
                new("Memory Support", cpu.CPU_MemorySupport),
                new("Integrated Graphics", cpu.CPU_IntegratedGraphics),
                new("TDP", cpu.CPU_TDP.ToString()+"W"),
            };

            List<Comment> list_Comment = new List<Comment>();

            using (var context = new ConfigPCContext())
            {
                list_Comment = context.Comments.Where(x => x.CPUId == cpu.Id).ToList();

            }

            _Comment = new ObservableCollection<Specification>();
            foreach (var item in list_Comment)
            {
                _Comment.Add(new Specification(item.NamePerson, item.CommentString));
            }
        }
    }
}
