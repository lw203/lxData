using Lx.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lx.Domain.Models.DataManager
{
    /// <summary>
    /// 诗词内容
    /// </summary>
    public class PoetryDetail : Entity
    {
        public string Content { get; set; }
        public Guid? PoetryId { get; set; }
        public virtual Poetry Poetry { get; set; }
    }
}
