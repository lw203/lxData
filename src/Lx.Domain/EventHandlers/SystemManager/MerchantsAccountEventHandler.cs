using Lx.Domain.Events.SystemManager;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lx.Domain.EventHandlers.SystemManager
{
    public class MerchantsAccountEventHandler : INotificationHandler<AddMerchantsAccoutEvent>, INotificationHandler<UpdateMerchantsAccoutEvent>
    {
        public Task Handle(AddMerchantsAccoutEvent message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(UpdateMerchantsAccoutEvent message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
