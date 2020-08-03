using Lx.Domain.Interfaces.SystemManager;
using Lx.Domain.Models.SystemManager;
using Lx.Infrastruct.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lx.Infrastruct.Data.Repository.SystemManager
{
    public class MerchantsAccountRepository : Repository<MerchantsAccount>, IMerchantsAccountRepository
    {
        public MerchantsAccountRepository(LxContext context) : base(context)
        {

        }

        public Task<List<MerchantsAccount>> GetData(string nickName, string phone, string email, DateTime startDate, DateTime endDate)
        {
            return DbSet.AsNoTracking().Where(t =>
                    string.IsNullOrWhiteSpace(nickName) ? true : t.NickName == nickName &
                    string.IsNullOrWhiteSpace(phone) ? true : t.Phone == phone &
                    string.IsNullOrWhiteSpace(email) ? true : t.Email == email &
                    startDate == null || endDate == null ? true : (t.CreateTime >= startDate & t.CreateTime <= endDate)
                ).ToListAsync();
        }

        public Task<MerchantsAccount> MerchantsLogin(string loginName, string passWord)
        {
            return DbSet.AsNoTracking().FirstOrDefaultAsync(t => 
                (t.NickName == loginName & t.PassWord == passWord) ||
                (t.Phone == loginName & t.PassWord == passWord) ||
                (t.Email == loginName & t.PassWord == passWord)
                );
        }
    }
}
