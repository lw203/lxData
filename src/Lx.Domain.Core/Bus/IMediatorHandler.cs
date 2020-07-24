using Lx.Domain.Core.Commands;
using Lx.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lx.Domain.Core.Bus
{
    /// <summary>
    /// 中介处理程序接口
    /// </summary>
    public interface IMediatorHandler
    {
        /// <summary>
        /// 发布命令，将命令模型发布到中介者模块
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="command">命令模型</param>
        /// <returns></returns>
        Task SendCommand<T>(T command) where T : Command;

        /// <summary>
        /// 引发事件，通过总线，发布事件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="event"></param>
        /// <returns></returns>
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
