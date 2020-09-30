using Lx.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lx.Domain.Models.DataManager
{
    /// <summary>
    /// 标签
    /// </summary>
    [Table("TAG")]
    public class Tag : Entity
    {
        public string Name { get; set; }
        public Guid? ParentId { get; set; }
    }
}
