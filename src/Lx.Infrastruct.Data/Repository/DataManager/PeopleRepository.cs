using Lx.Domain.Interfaces.DataManager;
using Lx.Domain.Models.DataManager;
using Lx.Domain.Shared.DataManager;
using Lx.Infrastruct.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lx.Infrastruct.Data.Repository.DataManager
{
    public class PeopleRepository : Repository<People>, IPeopleRepository
    {
        public PeopleRepository(LxContext context) : base(context)
        {

        }

        public override IQueryable<People> GetByPage<Tkey>(int pageSize, int pageIndex, Expression<Func<People, bool>> whereLambda, Func<People, Tkey> orderbyLambda, bool isAsc)
        {
            if (isAsc)
            {
                if (pageSize > 0)
                {
                    var temp = Db.Set<People>().Include(t => t.PeopleDetails).Where(whereLambda)
                                 .OrderBy<People, Tkey>(orderbyLambda)
                                 .Skip(pageIndex)
                                 .Take(pageSize);
                    return temp.AsQueryable();
                }
                else
                {
                    var temp = Db.Set<People>().Include(t => t.PeopleDetails).Where(whereLambda)
                                 .OrderBy<People, Tkey>(orderbyLambda);
                    return temp.AsQueryable();
                }
            }
            else
            {
                if (pageSize > 0)
                {
                    var temp = Db.Set<People>().Include(t => t.PeopleDetails).Where(whereLambda)
                           .OrderByDescending<People, Tkey>(orderbyLambda)
                           .Skip(pageIndex)
                           .Take(pageSize);
                    return temp.AsQueryable();
                }
                else
                {
                    var temp = Db.Set<People>().Include(t => t.PeopleDetails).Where(whereLambda)
                           .OrderByDescending<People, Tkey>(orderbyLambda);
                    return temp.AsQueryable();
                }
            }
        }
    }
}
