using Lx.Domain.Interfaces.SystemManager;
using Lx.Domain.Models.SystemManager;
using Lx.Infrastruct.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Lx.Infrastruct.Data.Repository.SystemManager
{
    public class LoginRecordRepository : Repository<LoginRecord>, ILoginRecordRepository
    {
        public LoginRecordRepository(LxContext context) : base(context)
        {
            
        }

        public void addLoginRecoid(LoginRecord model)
        {
            MerchantsAccountRepository merchantsAccountRepository = new MerchantsAccountRepository(Db);
            model.MerchantsAccount = merchantsAccountRepository.GetById(model.MerchantId);
            Console.WriteLine(Db.Entry(model).State);
            Db.Attach(model.MerchantsAccount);
            Console.WriteLine(Db.Entry(model).State);
            Db.Entry(model.MerchantsAccount).State = EntityState.Modified;
            Console.WriteLine(Db.Entry(model.MerchantsAccount).State);
            Add(model);
            Db.SaveChanges();
        }
        public IQueryable<LoginRecord> GetByPage<Tkey>(int pageSize, int pageIndex, Expression<Func<LoginRecord, bool>> whereLambda, Func<LoginRecord, Tkey> orderbyLambda, bool isAsc)
        {
            if (isAsc)
            {
                if (pageSize > 0)
                {
                    var temp = Db.Set<LoginRecord>().Include(t => t.MerchantsAccount).Where(whereLambda)
                                 .OrderBy<LoginRecord, Tkey>(orderbyLambda)
                                 .Skip(pageIndex)
                                 .Take(pageSize);
                    return temp.AsQueryable();
                }
                else
                {
                    var temp = Db.Set<LoginRecord>().Include(t => t.MerchantsAccount).Where(whereLambda)
                                 .OrderBy<LoginRecord, Tkey>(orderbyLambda);
                    return temp.AsQueryable();
                }
            }
            else
            {
                if (pageSize > 0)
                {
                    var temp = Db.Set<LoginRecord>().Include(t => t.MerchantsAccount).Where(whereLambda)
                           .OrderByDescending<LoginRecord, Tkey>(orderbyLambda)
                           .Skip(pageIndex)
                           .Take(pageSize);
                    return temp.AsQueryable();
                }
                else
                {
                    var temp = Db.Set<LoginRecord>().Include(t => t.MerchantsAccount).Where(whereLambda)
                           .OrderByDescending<LoginRecord, Tkey>(orderbyLambda);
                    return temp.AsQueryable();
                }
            }
        }
    }
}
