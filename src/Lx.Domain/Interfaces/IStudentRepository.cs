using Lx.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lx.Domain.Interfaces
{
    /// <summary>
    /// IStudentRepository接口
    /// 领域对象
    /// </summary>
    public interface IStudentRepository : IRepository<Student>
    {
        //一些Student独有的接口
        Student GetByEmail(string email);
    }
}
