using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lx.Application.ViewModels.DataManager
{
    public class PeopleDetailViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid PeopleId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Content { get; set; }
        public Guid CreateId { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
