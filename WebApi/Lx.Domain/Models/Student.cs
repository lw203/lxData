using Lx.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;
using System.Text;

namespace Lx.Domain.Models
{
    [Table("STUDENT")]
    public class Student : Entity
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// 手机
        /// </summary>
        public string Phone { get; private set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime BirthDate { get; private set; }

        public Address Address { get; private set; }
        
        public Student()
        {

        }
        public Student(Guid id,string name,string email,string phone,DateTime birthDate,Address address)
        {
            this.Name = name;
            this.Email = email;
            this.Phone = phone;
            this.BirthDate = birthDate;
            this.Address = address;
        }
    }
}
