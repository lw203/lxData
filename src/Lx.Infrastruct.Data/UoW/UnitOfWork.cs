using Lx.Domain.Interfaces;
using Lx.Infrastruct.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lx.Infrastruct.Data.UoW
{
    /// <summary>
    /// 工作单元类
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        //数据库上下文
        private readonly LxContext _context;
        //构造函数
        public UnitOfWork(LxContext context)
        {
            _context = context;
        }
        //上下文提交
        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }
        //手动提交
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
