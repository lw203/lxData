using Lx.Domain.Models.SystemManager;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lx.Domain.Interfaces.SystemManager
{
    public interface ILoginRecordRepository : IRepository<LoginRecord>
    {
        void addLoginRecoid(LoginRecord model);
    }
}
