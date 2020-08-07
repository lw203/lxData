using Lx.Domain.Commands.Student;
using Lx.Domain.Core.Bus;
using Lx.Domain.Core.Notifications;
using Lx.Domain.Events.Student;
using Lx.Domain.Interfaces;
using Lx.Domain.Models;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lx.Domain.CommandHandlers
{
    public class StudentCommandHandler : CommandHandler,
        IRequestHandler<RegisterStudentCommand, Unit>
    {
        //注入仓储接口
        private readonly IStudentRepository _studentRepository;
        //注入总线
        private readonly IMediatorHandler _bus;
        private IMemoryCache _cache;

        public StudentCommandHandler(IStudentRepository studentRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      IMemoryCache cache
                                      ) : base(uow, bus, cache)
        {
            _studentRepository = studentRepository;
            _bus = bus;
            _cache = cache;
        }

        public Task<Unit> Handle(RegisterStudentCommand message, CancellationToken cancellationToken)
        {
            //命令验证
            if (!message.IsValid())
            {
                // 错误信息收集
                NotifyValidationErrors(message);
                // 返回，结束当前线程
                return Task.FromResult(new Unit());
            }
            // 实例化领域模型，这里才真正的用到了领域模型
            // 注意这里是通过构造函数方法实现
            var address = new Address(message.Province, message.City,message.County, message.Street);
            var student = new Student(Guid.NewGuid(), message.Name, message.Email, message.Phone, message.BirthDate, address);

            if(_studentRepository.GetByEmail(student.Email)!=null)
            {
                //引发错误事件
                _bus.RaiseEvent(new DomainNotification("", "该邮箱已经被使用！"));
                return Task.FromResult(new Unit());
            }

            //持久化
            _studentRepository.Add(student);

            //统一提交
            if(Commit())
            {
                // 提交成功后，这里需要发布领域事件
                // 比如欢迎用户注册邮件呀，短信呀等

                _bus.RaiseEvent(new StudentRegisteredEvent(student.Id, student.Name, student.Email, student.BirthDate, student.Phone));
            }
            return Task.FromResult(new Unit());
        }
        public void Dispose()
        {
            _studentRepository.Dispose();
        }
    }
}
