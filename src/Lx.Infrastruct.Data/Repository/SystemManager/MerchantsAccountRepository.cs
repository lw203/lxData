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

        public MerchantsAccount GetByEmail(string email)
        {
            return DbSet.AsNoTracking().FirstOrDefault(t => t.Email == email);
        }

        public MerchantsAccount GetByNickName(string nickName)
        {
            return DbSet.AsNoTracking().FirstOrDefault(t => t.NickName == nickName);
        }

        public MerchantsAccount GetByPhone(string phone)
        {
            return DbSet.AsNoTracking().FirstOrDefault(t => t.Phone == phone);
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

        public MerchantsAccount MerchantsLogin(string loginName, string passWord)
        {
            return DbSet.AsNoTracking().FirstOrDefault(t => 
                (t.NickName == loginName & t.PassWord == passWord) ||
                (t.Phone == loginName & t.PassWord == passWord) ||
                (t.Email == loginName & t.PassWord == passWord)
                );
        }
        public void AddLoginRecord(LoginRecord loginRecord)
        {
            var data = DbSet.AsNoTracking().Include(b => b.LoginRecord).First();
            Console.WriteLine(Db.Entry(data).State);
            //var data = DbSet.AsNoTracking().FirstOrDefault(t => t.Id == loginRecord.MerchantId);
            Db.Attach(data);
            data.LoginRecord = new List<LoginRecord>();
            data.LoginRecord.Add(loginRecord);
            Console.WriteLine(Db.Entry(data).State);
            Db.SaveChanges();
        }
    }
}
