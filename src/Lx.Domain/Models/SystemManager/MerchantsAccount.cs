using Lx.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lx.Domain.Models.SystemManager
{
    /// <summary>
    /// 商家账户
    /// </summary>
    [Table("MERCHANT_ACCOUNT")]
    public class MerchantsAccount : Entity
    {
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; private set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; private set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; private set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; private set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar { get; private set; }
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime CreateTime { get; private set; }

        public MerchantsAccount()
        {

        }

        public MerchantsAccount(Guid id, string nickName,string phone,string email,string passWord,string avatar,DateTime createTime)
        {
            this.Id = id;
            this.NickName = nickName;
            this.Phone = phone;
            this.Email = email;
            this.PassWord = passWord;
            this.Avatar = avatar;
            this.CreateTime = createTime;
        }
    }
}
