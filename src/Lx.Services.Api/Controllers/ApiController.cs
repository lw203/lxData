using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Lx.Services.Api.Controllers
{
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        private readonly ICollection<string> _errors = new List<string>();
        protected ActionResult CustomResponse(Response res, object result = null)
        {
            return Ok(res);
            //if (IsOperationValid())
            //{
            //    return Ok(res);
            //}

            //return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            //{
            //    { "Messages", _errors.ToArray() }
            //}));
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);
            foreach (var error in errors)
            {
                AddError(error.ErrorMessage);
            }

            return CustomResponse(new Response(1, "参数错误", _errors));
        }

        protected ActionResult CustomResponse(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                AddError(error.ErrorMessage);
            }

            return CustomResponse(new Response(1, "参数错误", _errors));
        }

        protected bool IsOperationValid()
        {
            return !_errors.Any();
        }

        protected void AddError(string erro)
        {
            _errors.Add(erro);
        }

        protected void ClearErrors()
        {
            _errors.Clear();
        }
    }
    public class Response
    {
        public int errcode { get; set; }
        public string errmsg { get; set; }
        public object data { get; set; }
        public Response(int ErrCode, string ErrMsg, object Data = null)
        {
            this.errcode = ErrCode;
            this.errmsg = ErrMsg;
            this.data = Data;
        }
        public Response(ErrorCode code, object data = null)
        {
            this.errcode = (int)code;
            this.errmsg = code.ToString();
            this.data = data;
        }
    }
    public enum ErrorCode
    {
        成功 = 0,
        失败 = 1,
        查无数据 = 400,
        账号和密码不能为空 = 1001,
        账号或密码错误 = 1002
    }
}