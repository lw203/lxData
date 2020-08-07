using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lx.Infrastruct.Data.EFCoreLog
{
    public class EFLogger : ILogger
    {
        private readonly string _CategoryName;

        public EFLogger(string categoryName)
        {
            this._CategoryName = categoryName;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            //拿到日志
            var logContent = formatter(state, exception);
            //接下来你想怎么玩这个日志就怎么玩
            //if (DataModel.Dic.ContainsKey(this._CategoryName))
            //{
            //    DataModel.Dic[this._CategoryName].Add(logContent);
            //}
            //else
            //{
            //    DataModel.Dic.Add(this._CategoryName, new List<string>() { logContent });
            //}

            //ef core执行数据库查询时的categoryName为Microsoft.EntityFrameworkCore.Database.Command,日志级别为Information
            if (this._CategoryName == "Microsoft.EntityFrameworkCore.Database.Command" && logLevel == LogLevel.Information)
            {
                //xxx
                Console.WriteLine(logContent);
            }
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
    }

}
