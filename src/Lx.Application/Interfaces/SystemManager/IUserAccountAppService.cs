using Lx.Application.ViewModels.SystemManager;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lx.Application.Interfaces.SystemManager
{
    public interface IUserAccountAppService : IDisposable
    {
        /// <summary>
        /// 商家登录
        /// </summary>
        UserAccountViewModel UserLogin(string LoginName, string PassWord);
        IEnumerable<UserAccountViewModel> GetAll();
        UserAccountViewModel GetById(Guid id);
        IEnumerable<UserAccountViewModel> GetByPage(int pageSize, int pageIndex, string UserName, string phone, string email, string startDate, string endDate);
        int GetCount(string UserName, string phone, string email, string startDate, string endDate);

        void Add(UserAccountViewModel model);

        void Update(UserAccountViewModel model);

        void AddLoginRecord(LoginRecordViewModel model);
    }
}
