using System;
using System.Collections.Generic;
using System.Text;

namespace Lx.Application.ViewModels.DataManager
{
    public class TagViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ParentId { get; set; }
       public List<TagViewModel> ChildTags { get; set; }
    }

    public class TagAddViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ParentId { get; set; }
        public Guid CreateId { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
