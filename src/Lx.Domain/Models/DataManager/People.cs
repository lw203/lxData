using Lx.Domain.Core.Models;
using Lx.Domain.Shared.DataManager;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Text;

namespace Lx.Domain.Models.DataManager
{
    /// <summary>
    /// 人物
    /// </summary>
    [Table("PEOPLE")]
    public class People : Entity
    {
        /// <summary>
        /// 人物姓名
        /// </summary>
        public string PeopleName { get; set; }

        public string Dynasty { get; set; }

        /// <summary>
        /// 朝代
        /// </summary>
        [NotMapped]
        public DynastyCode DynastyCode
        {
            get
            {
                return (DynastyCode)Convert.ToInt32(Dynasty);
            }
            set
            {
                Dynasty = Convert.ToInt32(value).ToString();
            }
        }

        /// <summary>
        /// 所属分类
        /// </summary>
        public string Sort { get; set; }

        [NotMapped]
        public SortCode SortCode
        {
            get
            {
                return (SortCode)Convert.ToInt32(Sort);
            }
            set
            {
                Sort = Convert.ToInt32(value).ToString();
            }
        }

        /// <summary>
        /// 介绍
        /// </summary>
        public string Explain { get; set; }

        /// <summary>
        /// 详细介绍
        /// </summary>
        public virtual ICollection<PeopleDetail> PeopleDetails { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }

        [NotMapped]
        public Status PeopleStatus
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
