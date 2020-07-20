using Lx.Domain.Interfaces;
using Lx.Domain.Models;
using Lx.Infrastruct.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lx.Infrastruct.Data.Repository
{
    public class LoginRepository : Repository<Login>, ILoginRepository
    {
        public LoginRepository(LxContext context) : base(context)
        {

        }

        //对特例接口进行实现
        public Login Login(string loginName, string passWord)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.LoginName == loginName && c.PassWord == passWord);
        }
    }
}
