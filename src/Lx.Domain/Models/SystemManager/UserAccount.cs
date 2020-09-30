using Lx.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lx.Domain.Models.SystemManager
{
    /// <summary>
    /// 用户信息
    /// </summary>
    [Table("USER_ACCOUNT")]
    public class UserAccount : Entity
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; private set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; private set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; private set; }
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

        public virtual ICollection<LoginRecord> LoginRecord { get; set; }

        public UserAccount()
        {

        }

        public UserAccount(Guid id, string userName, string phone, string email, string nickName, string passWord, string avatar, DateTime createTime)
        {
            this.Id = id;
            this.UserName = userName;
            this.Phone = phone;
            this.Email = email;
            this.NickName = nickName;
            this.PassWord = passWord;
            this.Avatar = avatar;
            this.CreateTime = createTime;
        }
    }
}
