using Lx.Domain.Core.Models;
using Lx.Domain.Shared.DataManager;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lx.Domain.Models.DataManager
{
    /// <summary>
    /// 诗词
    /// </summary>
    [Table("POETRY")]
    public class Poetry : Entity
    {
        public string Title { get; set; }

        public virtual ICollection<PoetryDetail> PoetryDetails { get; set; }

        public Guid? PeopleId { get; set; }

        public string PeopleName { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }

        [NotMapped]
        public Status PoetryStatus
        {
            get
            {
                return (Status)Convert.ToInt32(Status);
            }
            set
            {
                Status = Convert.ToInt32(value).ToString();
            }
        }

        /// <summary>
        /// 审核人
        /// </summary>
        public Guid? CheckId { get; set; }

        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime? CheckTime { get; set; }
    }
}
