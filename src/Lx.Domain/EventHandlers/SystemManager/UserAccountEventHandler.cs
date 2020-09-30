using Lx.Domain.Events.SystemManager;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lx.Domain.EventHandlers.SystemManager
{
    public class UserAccountEventHandler : INotificationHandler<AddUserAccoutEvent>, INotificationHandler<UpdateUserAccoutEvent>
    {
        public Task Handle(AddUserAccoutEvent message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(UpdateUserAccoutEvent message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
