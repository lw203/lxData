using Lx.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lx.Domain.Interfaces
{
    public interface ILoginRepository : IRepository<Login>
    {
        Login Login(string loginName, string passWord);
    }
}
