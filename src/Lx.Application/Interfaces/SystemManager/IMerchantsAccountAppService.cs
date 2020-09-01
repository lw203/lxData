using Lx.Application.ViewModels.SystemManager;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lx.Application.Interfaces.SystemManager
{
    public interface IMerchantsAccountAppService : IDisposable
    {
        /// <summary>
        /// 商家登录
        /// </summary>
        MerchantsAccountViewModel MerchantsLogin(string LoginName, string PassWord);
        IEnumerable<MerchantsAccountViewModel> GetAll();
        MerchantsAccountViewModel GetById(Guid id);
        IEnumerable<MerchantsAccountViewModel> GetByPage(int pageSize, int pageIndex, string nickName, string phone, string email, string startDate, string endDate);
        int GetCount(string nickName, string phone, string email, string startDate, string endDate);

        /// <summary>
        /// 获取商户列表
        /// </summary>
        /// <param name="nickName">昵称</param>
        /// <param name="phone">手机号</param>
        /// <param name="email">邮箱</param>
        /// <param name="startDate">时间范围->开始时间</param>
        /// <param name="endDate">时间范围->结束时间</param>
        /// <returns></returns>
        Task<List<MerchantsAccountViewModel>> GetData(string nickName, string phone, string email, DateTime startDate, DateTime endDate);

        void Add(MerchantsAccountViewModel model);

        void Update(MerchantsAccountViewModel model);

        void AddLoginRecord(LoginRecordViewModel model);
    }
}
