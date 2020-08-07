using Lx.Domain.Validations.SystemManager;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lx.Domain.Commands.SystemManager
{
    public class AddMerchantsAccountCommand : MerchantsAccountCommand
    {
        // set 受保护，只能通过构造函数方法赋值
        public AddMerchantsAccountCommand(string nickName, string email,  string phone, string passWord)
        {
            NickName = nickName;
            Email = email;
            Phone = phone;
            PassWord = passWord;
        }
        public override bool IsValid()
        {
            ValidationResult = new AddMerchantsAccountCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class UpdateMerchantsAccountCommand : MerchantsAccountCommand
    {
        // set 受保护，只能通过构造函数方法赋值
        public UpdateMerchantsAccountCommand(Guid id, string nickName, string email, string phone, string passWord)
        {
            Id = id;
            NickName = nickName;
            Email = email;
            Phone = phone;
            PassWord = passWord;
        }
        public override bool IsValid()
        {
            ValidationResult = new UpdateMerchantsAccountCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class DeleteMerchantsAccountCommand : MerchantsAccountCommand
    {
        // set 受保护，只能通过构造函数方法赋值
        public DeleteMerchantsAccountCommand(Guid id)
        {
            Id = id;
        }
        public override bool IsValid()
        {
            ValidationResult = new DeleteMerchantsAccountCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
