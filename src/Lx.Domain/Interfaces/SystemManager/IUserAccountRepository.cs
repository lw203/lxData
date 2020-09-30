using Lx.Domain.Models.SystemManager;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lx.Domain.Interfaces.SystemManager
{
    public interface IUserAccountRepository : IRepository<UserAccount>
    {
        /// <summary>
        /// 商户登录
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <param name="passWord">密码</param>
        /// <returns></returns>
        UserAccount UserLogin(string loginName, string passWord);

        UserAccount GetByUserName(string userName);

        UserAccount GetByPhone(string phone);

        UserAccount GetByEmail(string email);

        void AddLoginRecord(LoginRecord model);
    }
}
