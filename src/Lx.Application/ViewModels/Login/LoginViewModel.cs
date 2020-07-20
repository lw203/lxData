using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lx.Application.ViewModels
{
    public class LoginViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string LoginName { get; set; }
        public string PassWord { get; set; }
        public string NiceName { get; set; }
        public int Lock { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
