using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lx.Application.ViewModels.SystemManager
{
    public class UserAccountViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string PassWord { get; set; }
        public string UserName { get; set; }
        public string NickName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
