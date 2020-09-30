using Lx.Domain.Commands.SystemManager;
using Lx.Domain.Core.Bus;
using Lx.Domain.Core.Notifications;
using Lx.Domain.Events.SystemManager;
using Lx.Domain.Interfaces;
using Lx.Domain.Interfaces.SystemManager;
using Lx.Domain.Models.SystemManager;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lx.Domain.CommandHandlers.SystemManager
{
    public class UserAccountCommandHandler : CommandHandler,
        IRequestHandler<AddUserAccountCommand, Unit>,
        IRequestHandler<UpdateUserAccountCommand, Unit>,
        IRequestHandler<DeleteUserAccountCommand, Unit>
    {
        //注入仓储接口
        private readonly IUserAccountRepository _repository;
        //注入总线
        private readonly IMediatorHandler _bus;
        private IMemoryCache _cache;

        public UserAccountCommandHandler(IUserAccountRepository repository, IUnitOfWork uow, IMediatorHandler bus, IMemoryCache cache)
            : base(uow, bus, cache)
        {
            _repository = repository;
            _bus = bus;
            _cache = cache;
        }

        public Task<Unit> Handle(AddUserAccountCommand message, CancellationToken cancellationToken)
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
            var model = new UserAccount(message.Id, message.UserName, message.Phone, message.Email, message.NickName, message.PassWord, message.Avatar, message.CreateTime);

            if (_repository.GetByUserName(model.UserName) != null)
            {
                //引发错误事件
                _bus.RaiseEvent(new DomainNotification("", "该昵称已经被使用！"));
                return Task.FromResult(new Unit());
            }

            if (_repository.GetByPhone(model.Phone) != null)
            {
                //引发错误事件
                _bus.RaiseEvent(new DomainNotification("", "该手机号已经被使用！"));
                return Task.FromResult(new Unit());
            }

            if (!string.IsNullOrWhiteSpace(model.Email) && _repository.GetByEmail(model.Email) != null)
            {
                //引发错误事件
                _bus.RaiseEvent(new DomainNotification("", "该邮箱已经被使用！"));
                return Task.FromResult(new Unit());
            }

            //持久化
            _repository.Add(model);

            //统一提交
            if (Commit())
            {
                // 提交成功后，这里需要发布领域事件
                // 比如欢迎用户注册邮件呀，短信呀等

                _bus.RaiseEvent(new AddUserAccoutEvent(model.Id, model.UserName, model.Phone, model.Email, model.PassWord));
            }
            return Task.FromResult(new Unit());
        }

        public Task<Unit> Handle(UpdateUserAccountCommand message, CancellationToken cancellationToken)
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
            var model = new UserAccount(message.Id, message.UserName, message.Phone, message.Email, message.NickName, message.PassWord, message.Avatar, message.CreateTime);

            var data = _repository.GetById(model.Id);
            if (data == null)
            {
                //引发错误事件
                _bus.RaiseEvent(new DomainNotification("", "用户不存在！"));
                return Task.FromResult(new Unit());
            }

            data = _repository.GetByUserName(model.UserName);
            if (data != null && data.Id != model.Id)
            {
                //引发错误事件
                _bus.RaiseEvent(new DomainNotification("", "该昵称已经被使用！"));
                return Task.FromResult(new Unit());
            }
            data = _repository.GetByPhone(model.Phone);
            if (data != null && data.Id != model.Id)
            {
                //引发错误事件
                _bus.RaiseEvent(new DomainNotification("", "该手机号已经被使用！"));
                return Task.FromResult(new Unit());
            }
            data = _repository.GetByEmail(model.Email);
            if (!string.IsNullOrWhiteSpace(model.Email) && data != null && data.Id != model.Id)
            {
                //引发错误事件
                _bus.RaiseEvent(new DomainNotification("", "该邮箱已经被使用！"));
                return Task.FromResult(new Unit());
            }

            //持久化
            _repository.Update(model);

            //统一提交
            if (Commit())
            {
                // 提交成功后，这里需要发布领域事件
                // 比如欢迎用户注册邮件呀，短信呀等

                _bus.RaiseEvent(new UpdateUserAccoutEvent(model.Id, model.UserName, model.Phone, model.Email, model.PassWord));
            }
            return Task.FromResult(new Unit());
        }

        public Task<Unit> Handle(DeleteUserAccountCommand message, CancellationToken cancellationToken)
        {
            //命令验证
            if (!message.IsValid())
            {
                // 错误信息收集
                NotifyValidationErrors(message);
                // 返回，结束当前线程
                return Task.FromResult(new Unit());
            }
            _repository.Remove(message.Id);

            //统一提交
            if (Commit())
            {
                //_bus.RaiseEvent(new AddUserAccoutEvent(message.Id));
            }
            return Task.FromResult(new Unit());
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
