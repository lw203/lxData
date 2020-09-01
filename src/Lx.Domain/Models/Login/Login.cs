using Lx.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lx.Domain.Models
{
    [Table("LX_LOGIN_USER")]
    public class Login : Entity
    {
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; private set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; private set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NiceName { get; private set; }
        /// <summary>
        /// 是否锁定
        /// </summary>
        public int Lock { get; private set; }

        public Login()
        {

        }
        public Login(Guid id, string loginName,string passWord,string niceName,int _lock,DateTime createTime)
        {
            this.Id = id;
            this.LoginName = loginName;
            this.PassWord = passWord;
            this.NiceName = niceName;
            this.Lock = _lock;
            this.CreateTime = createTime;
        }
    }
}
