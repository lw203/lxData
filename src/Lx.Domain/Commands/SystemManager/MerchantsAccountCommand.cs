using Lx.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lx.Domain.Commands.SystemManager
{
    public abstract class MerchantsAccountCommand : Command
    {
        public Guid Id { get; protected set; }
        public string NickName { get; protected set; }
        public string Phone { get; protected set; }
        public string Email { get; protected set; }
        public string PassWord { get; protected set; }
        public string Avatar { get; protected set; }
        public DateTime CreateTime { get; protected set; }
    }
}
