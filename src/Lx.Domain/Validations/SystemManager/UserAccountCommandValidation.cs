using Lx.Domain.Commands.SystemManager;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lx.Domain.Validations.SystemManager
{
    /// <summary>
    /// 商家账户注册验证
    /// </summary>
    public class AddUserAccountCommandValidation : UserAccountValidation<AddUserAccountCommand>
    {
        public AddUserAccountCommandValidation()
        {
            ValidateUserName();
            ValidatePassWord();
            ValidatePhone();
            ValidateEmail();
        }
    }

    /// <summary>
    /// 商家账户更新验证
    /// </summary>
    public class UpdateUserAccountCommandValidation : UserAccountValidation<UpdateUserAccountCommand>
    {
        public UpdateUserAccountCommandValidation()
        {
            ValidateId();
            ValidateUserName();
            ValidatePassWord();
            ValidatePhone();
            ValidateEmail();
        }
    }

    /// <summary>
    /// 商家账户删除验证
    /// </summary>
    public class DeleteUserAccountCommandValidation : UserAccountValidation<DeleteUserAccountCommand>
    {
        public DeleteUserAccountCommandValidation()
        {
            ValidateId();
        }
    }
}
