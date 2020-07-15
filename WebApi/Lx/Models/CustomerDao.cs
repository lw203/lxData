using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lx.UI.Web.Models
{
    /// <summary>
    /// 领域对象持久层
    /// </summary>
    public class CustomerDao
    {
        public static Customer GetCustomer(string id)
        {
            return new Customer() { Id = "1", Name = "Lx", Email = "Lx@123.com" };
        }

        public static string SaveCustomer(Customer customer)
        {
            return "保存成功";
        }
    }
}
