using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lx.UI.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lx.UI.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="birthDdate"></param>
        public void saveCustomer(string id,string name,string email,string birthDdate)
        {
            Customer customer = CustomerDao.GetCustomer(id);
            if(customer == null)
            {
                customer = new Customer();
                customer.Id = id;
            }
            if(!string.IsNullOrWhiteSpace(name))
            {
                customer.Name = name;
            }
            CustomerDao.SaveCustomer(customer);
        }
    }
}