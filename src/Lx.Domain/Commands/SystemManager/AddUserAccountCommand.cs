using Lx.Domain.Validations.SystemManager;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lx.Domain.Commands.SystemManager
{
    public class AddUserAccountCommand : UserAccountCommand
    {
        // set 受保护，只能通过构造函数方法赋值
        public AddUserAccountCommand(string userName, string email,  string phone, string passWord)
        {
            UserName = userName;
            Email = email;
            Phone = phone;
            PassWord = passWord;
        }
        public override bool IsValid()
        {
            ValidationResult = new AddUserAccountCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class UpdateUserAccountCommand : UserAccountCommand
    {
        // set 受保护，只能通过构造函数方法赋值
        public UpdateUserAccountCommand(Guid id, string userName, string email, string phone, string passWord)
        {
            Id = id;
            UserName = userName;
            Email = email;
            Phone = phone;
            PassWord = passWord;
        }
        public override bool IsValid()
        {
            ValidationResult = new UpdateUserAccountCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class DeleteUserAccountCommand : UserAccountCommand
    {
        // set 受保护，只能通过构造函数方法赋值
        public DeleteUserAccountCommand(Guid id)
        {
            Id = id;
        }
        public override bool IsValid()
        {
            ValidationResult = new DeleteUserAccountCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
