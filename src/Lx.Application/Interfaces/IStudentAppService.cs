﻿using Lx.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lx.Application.Interfaces
{
    /// <summary>
    /// 定义 IStudentAppService 服务接口
    /// 并继承IDisposable，显式释放资源
    /// 注意这里我们使用的对象，是视图对象模型
    /// </summary>
    public interface IStudentAppService : IDisposable
    {
        void Register(StudentViewModel StudentViewModel);

        IEnumerable<StudentViewModel> GetAll();

        StudentViewModel GetById(Guid id);

        StudentViewModel GetByEmail(string email);

        void Update(StudentViewModel StudentViewModel);

        void Remove(Guid id);

        //IList<StudentHistoryData> GetAllHistory(Guid id);
    }
}
