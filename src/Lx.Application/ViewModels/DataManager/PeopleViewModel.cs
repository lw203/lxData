using Lx.Domain.Shared.DataManager;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lx.Application.ViewModels.DataManager
{
    public class PeopleViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string PeopleName { get; set; }
        public string Dynasty { get; set; }
        public string Explain { get; set; }
        public List<PeopleDetailViewModel> peopleDetails { get; set; }
    }

    public class PeopleAddViewModel: PeopleViewModel
    {
        public Guid CreateId { get; set; }
        public DateTime CreateTime { get; set; }

        public string Sort { get; set; } = "0";

        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; } = "0";
    }
}
