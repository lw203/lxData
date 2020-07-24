using Lx.Domain.Core.Bus;
using Lx.Domain.Core.Commands;
using Lx.Domain.Core.Notifications;
using Lx.Domain.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lx.Domain.CommandHandlers
{
    /// <summary>
    /// 领域命令处理程序
    /// </summary>
    public class CommandHandler
    {
        //注入工作单元
        private readonly IUnitOfWork _uow;
        //注入中介处理接口
        private readonly IMediatorHandler _bus;
        // 注入缓存，用来存储错误信息（目前是错误方法，以后用领域通知替换）
        private IMemoryCache _cache;

        public CommandHandler(IUnitOfWork uow,IMediatorHandler bus,IMemoryCache cache)
        {
            _uow = uow;
            _bus = bus;
            _cache = cache;
        }

        //将领域命令中的验证错误信息收集
        //目前用的是缓存方法（以后通过领域通知替换）
        protected void NotifyValidationErrors(Command message)
        {
            List<string> errorInfo = new List<string>();
            foreach (var error in message.ValidationResult.Errors)
            {
                errorInfo.Add(error.ErrorMessage);

                //将错误信息提交到事件总线，派发出去
                _bus.RaiseEvent(new DomainNotification("", error.ErrorMessage));
            }
        }

        public bool Commit()
        {
            if (_uow.Commit())
                return true;
            return false;
        }
    }
}
