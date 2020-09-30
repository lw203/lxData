using Lx.Application.ViewModels.DataManager;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lx.Application.Interfaces.DataManager
{
    public interface IPeopleAppService : IDisposable
    {
        IEnumerable<PeopleViewModel> GetAll();

        IEnumerable<PeopleViewModel> GetByPage(int pageSize, int pageIndex, string dynasty);

        int GetCount(string dynasty);

        void Add(PeopleAddViewModel model);
    }
}
