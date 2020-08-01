using Lx.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lx.Domain.Models.SystemManager
{
    /// <summary>
    /// 商家角色
    /// </summary>
    [Table("LX_MERCHANTS_ROLE")]
    public class MerchantsRole :  Entity
    {
        /// <summary>
        /// 角色名
        /// </summary>
        public string RoleName { get; private set; }
        /// <summary>
        /// 是否管理员
        /// </summary>
        public bool IsAdmin { get; private set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsUse { get; private set; }

        public MerchantsRole()
        {

        }

        public MerchantsRole(string roleName, bool isAdmin, bool isUse)
        {
            this.RoleName = roleName;
            this.IsAdmin = IsAdmin;
            this.IsUse = IsUse;
        }
    }
}
