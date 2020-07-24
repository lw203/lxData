using Lx.Domain.Core.Bus;
using Lx.Domain.Core.Commands;
using Lx.Domain.Core.Events;
using MediatR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lx.Infrastruct.Data.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        //构造函数注入
        private readonly IMediator _mediator;
        //注入服务工厂
        private readonly ServiceFactory _serviceFactory;
        private static readonly ConcurrentDictionary<Type, object> _requestHandlers = new ConcurrentDictionary<Type, object>();

        public InMemoryBus(IMediator mediator,ServiceFactory serviceFactory)
        {
            _mediator = mediator;
            _serviceFactory = serviceFactory;
        }
        public Task SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }

        public Task RaiseEvent<T>(T @event) where T :Event
        {
            return _mediator.Publish(@event);
        }
    }
}
