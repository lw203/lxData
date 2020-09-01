using Lx.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lx.Domain.Models.SystemManager
{
    /// <summary>
    /// 登录记录
    /// </summary>
    [Table("LOGIN_RECORD")]
    public class LoginRecord: Entity
    {
        /// <summary>
        /// Ip地址
        /// </summary>
        public string Ip { get; private set; }
        /// <summary>
        /// 地区
        /// </summary>
        public string Area { get; private set; }
        /// <summary>
        /// 浏览器
        /// </summary>
        public string Brower { get; private set; }
        /// <summary>
        /// 操作系统
        /// </summary>
        public string Os { get; private set; }
        public Guid MerchantId { get; private set; }
        public virtual MerchantsAccount MerchantsAccount { get; set; }

        public LoginRecord()
        {

        }

        public LoginRecord(Guid id, string ip, string area, string brower, string os, DateTime createTime, string lastUpdateTime,Guid mechantId, MerchantsAccount merchantsAccount )
        {
            this.Id = id;
            this.Ip = ip;
            this.Area = area;
            this.Brower = brower;
            this.Os = os;
            this.CreateTime = createTime;
            this.LastUpdateTime = lastUpdateTime;
            this.MerchantId = mechantId;
            this.MerchantsAccount = merchantsAccount;
        }
    }
}
