using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lx.Domain.Core.Events
{
    /// <summary>
    /// 事件模型
    /// 中介者模式中的 发布/订阅模式
    /// </summary>
    public abstract class Event : INotification
    {
        //时间戳
        public DateTime Timestap { get; private set; }

        protected Event()
        {
            Timestap = DateTime.Now;
        }
    }
}
