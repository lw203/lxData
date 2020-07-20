using Lx.Domain.Validations.Student;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lx.Domain.Commands.Student
{
    /// <summary>
    /// 注册一个添加 Student 命令
    /// 基础抽象学生命令模型
    /// </summary>
    public class RegisterStudentCommand : StudentCommand
    {
        // set 受保护，只能通过构造函数方法赋值
        public RegisterStudentCommand(string name, string email, DateTime birthDate, string phone, string province, string city, string county, string street)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Phone = phone;
            Province = province;
            City = city;
            County = county;
            Street = street;
        }
        public override bool IsValid()
        {
            ValidationResult = new RegisterStudentCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
