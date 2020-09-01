using System;
using System.Collections.Generic;
using System.Text;

namespace Lx.Application.ViewModels.SystemManager
{
    public class LoginRecordViewModel
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Ip地址
        /// </summary>
        public string Ip { get; set; }
        /// <summary>
        /// 地区
        /// </summary>
        public string Area { get; set; }
        /// <summary>
        /// 浏览器
        /// </summary>
        public string Brower { get; set; }
        /// <summary>
        /// 操作系统
        /// </summary>
        public string Os { get; set; }
        /// <summary>
        /// 登录时间
        /// </summary>
        public string CreateTime { get; set; }

        public Guid MerchantId { get; set; }
        public string MerchantNickName { get; set; }

        public LoginRecordViewModel()
        {

        }

        public LoginRecordViewModel(Guid id, string ip, string area, string brower, string os, string loginTime, Guid merchantId,string merchantNickName)
        {
            this.Id = id;
            this.Ip = ip;
            this.Area = area;
            this.Brower = brower;
            this.Os = os;
            this.CreateTime = loginTime;
            this.MerchantId = merchantId;
            this.MerchantNickName = merchantNickName;
        }
    }
}
