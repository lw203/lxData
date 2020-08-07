using Lx.Domain.Commands.SystemManager;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lx.Domain.Validations.SystemManager
{
    /// <summary>
    /// 商家账户注册验证
    /// </summary>
    public class AddMerchantsAccountCommandValidation : MerchantsAccountValidation<AddMerchantsAccountCommand>
    {
        public AddMerchantsAccountCommandValidation()
        {
            ValidateNickName();
            ValidatePassWord();
            ValidatePhone();
            ValidateEmail();
        }
    }

    /// <summary>
    /// 商家账户更新验证
    /// </summary>
    public class UpdateMerchantsAccountCommandValidation : MerchantsAccountValidation<UpdateMerchantsAccountCommand>
    {
        public UpdateMerchantsAccountCommandValidation()
        {
            ValidateId();
            ValidateNickName();
            ValidatePassWord();
            ValidatePhone();
            ValidateEmail();
        }
    }

    /// <summary>
    /// 商家账户删除验证
    /// </summary>
    public class DeleteMerchantsAccountCommandValidation : MerchantsAccountValidation<DeleteMerchantsAccountCommand>
    {
        public DeleteMerchantsAccountCommandValidation()
        {
            ValidateId();
        }
    }
}
