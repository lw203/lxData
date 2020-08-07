using Lx.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lx.Domain.Events.SystemManager
{
    public class AddMerchantsAccoutEvent : Event
    {
        public AddMerchantsAccoutEvent(Guid id, string nickName, string phone, string email, string passWord)
        {
            Id = id;
            NickName = nickName;
            Phone = phone;
            Email = email;
            PassWord = passWord;
        }
        public Guid Id { get; set; }
        public string NickName { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public string PassWord { get; private set; }
    }

    public class UpdateMerchantsAccoutEvent : Event
    {
        public UpdateMerchantsAccoutEvent(Guid id, string nickName, string phone, string email, string passWord)
        {
            Id = id;
            NickName = nickName;
            Phone = phone;
            Email = email;
            PassWord = passWord;
        }
        public Guid Id { get; set; }
        public string NickName { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public string PassWord { get; private set; }
    }
}
