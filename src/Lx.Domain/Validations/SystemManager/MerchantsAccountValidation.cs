using FluentValidation;
using Lx.Domain.Commands.SystemManager;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lx.Domain.Validations.SystemManager
{
    public abstract class MerchantsAccountValidation<T>: AbstractValidator<T> where T : MerchantsAccountCommand
    {
        protected void ValidateNickName()
        {
            RuleFor(t => t.NickName)
                .NotEmpty().WithMessage("昵称不能为空")
                .Length(2,20).WithMessage("昵称在2-20个字符之间");
        }

        protected void ValidatePassWord()
        {
            RuleFor(t => t.PassWord)
                .NotEmpty().WithMessage("密码不能为空");
        }

        //验证邮箱
        protected void ValidateEmail()
        {
            RuleFor(c => c.Email)
                .EmailAddress().WithMessage("邮箱格式不正确");
        }

        //验证手机号
        protected void ValidatePhone()
        {
            RuleFor(c => c.Phone)
                .NotEmpty().WithMessage("手机号不能为空")
                .Must(HavePhone).WithMessage("手机号格式不正确");
        }

        //验证Guid
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        // 表达式
        protected static bool HavePhone(string phone)
        {
            return string.IsNullOrWhiteSpace(phone) ? false : phone.Length == 11;
        }
    }
}
