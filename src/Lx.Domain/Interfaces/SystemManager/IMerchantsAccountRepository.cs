using Lx.Domain.Models.SystemManager;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lx.Domain.Interfaces.SystemManager
{
    public interface IMerchantsAccountRepository : IRepository<MerchantsAccount>
    {
        /// <summary>
        /// 商户登录
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <param name="passWord">密码</param>
        /// <returns></returns>
        MerchantsAccount MerchantsLogin(string loginName, string passWord);

        MerchantsAccount GetByNickName(string nickName);

        MerchantsAccount GetByPhone(string phone);

        MerchantsAccount GetByEmail(string email);

        /// <summary>
        /// 获取商户列表
        /// </summary>
        /// <param name="nickName">昵称</param>
        /// <param name="phone">手机号</param>
        /// <param name="email">邮箱</param>
        /// <param name="startDate">时间范围->开始时间</param>
        /// <param name="endDate">时间范围->结束时间</param>
        /// <returns></returns>
        Task<List<MerchantsAccount>> GetData(string nickName, string phone, string email, DateTime startDate, DateTime endDate);
    }
}
