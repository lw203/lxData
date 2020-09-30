using Lx.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lx.Domain.Events.SystemManager
{
    public class AddUserAccoutEvent : Event
    {
        public AddUserAccoutEvent(Guid id, string userName, string phone, string email, string passWord)
        {
            Id = id;
            UserName = userName;
            Phone = phone;
            Email = email;
            PassWord = passWord;
        }
        public Guid Id { get; set; }
        public string UserName { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public string PassWord { get; private set; }
    }

    public class UpdateUserAccoutEvent : Event
    {
        public UpdateUserAccoutEvent(Guid id, string userName, string phone, string email, string passWord)
        {
            Id = id;
            UserName = userName;
            Phone = phone;
            Email = email;
            PassWord = passWord;
        }
        public Guid Id { get; set; }
        public string UserName { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public string PassWord { get; private set; }
    }
}
