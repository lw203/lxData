using Lx.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lx.Domain.Models.DataManager
{
    /// <summary>
    /// 人物详情
    /// </summary>
    [Table("PEOPLE_DETAIL")]
    public class PeopleDetail: Entity
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 副标题
        /// </summary>
        public string SubTitle { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 审核人
        /// </summary>
        public Guid? CheckId { get; set; }

        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime? CheckTime { get; set; }
        public Guid PeopleId { get; private set; }
        public virtual People People { get; set; }
    }
}
