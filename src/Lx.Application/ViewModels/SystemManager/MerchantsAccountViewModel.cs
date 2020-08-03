using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lx.Application.ViewModels.SystemManager
{
    public class MerchantsAccountViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string PassWord { get; set; }
        public string NiceName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public DateTime CreateTime { get; set; }
    }

    /// <summary>
    /// 商家账户查询条件
    /// </summary>
    public class MerchantsAccountSelect
    {
        public string Phone { get; set; }
        public string Email { get; set; }
        public string NickName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
