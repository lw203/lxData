using Lx.Application.ViewModels.SystemManager;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lx.Application.Interfaces.SystemManager
{
    public interface ILoginRecordAppService : IDisposable
    {
        void Add(LoginRecordViewModel model);
        IEnumerable<LoginRecordViewModel> GetByPage(int pageSize, int pageIndex, string startDate, string endDate);
        int GetCount(string startDate, string endDate);
    }
}
