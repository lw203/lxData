using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JiebaNet.Segmenter;
using JiebaNet.Segmenter.Common;
using JiebaNet.Segmenter.PosSeg;
using Lx.Application.Interfaces.DataManager;
using Lx.Application.ViewModels.DataManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lx.Services.Api.Controllers.DataManager
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ApiController
    {
        private readonly IPeopleAppService _appService;
        //private readonly IWordCloudAppService _wordCloudAppService;

        public PeopleController(IPeopleAppService appService)
        {
            _appService = appService;
            //_wordCloudAppService = wordCloudAppService;
        }

        [HttpPost("add-people")]
        public IActionResult Post([FromBody]PeopleAddViewModel model)
        {
            if (!ModelState.IsValid) return CustomResponse(new Response(ErrorCode.失败, ModelState));

            _appService.Add(model);

            return CustomResponse(new Response(ErrorCode.成功, model));
        }

        [HttpGet("get-by-page")]
        public IActionResult GetByPage(int pageSize, int pageIndex, string dynasty)
        {
            var list = _appService.GetByPage(pageSize, pageIndex, dynasty);
            if (list == null || list.Count() < 1)
            {
                return CustomResponse(new Response(ErrorCode.查无数据));
            }
            int pageCount = _appService.GetCount(dynasty);

            var data = new { pageIndex, pageSize, pageCount, list };
            return CustomResponse(new Response(ErrorCode.成功, data));
        }

        [HttpGet("word-cloud")]
        public IActionResult WordCloud(string text)
        {
            var segmenter = new JiebaSegmenter();
            segmenter.LoadUserDict("userdict.txt");

            //词频统计
            var s = "蜀地雖遠天之涯，蜀人只隔一水巴。自從文翁建此學，此俗化爲齊魯家。泮林春風桑椹熟，集鼓坎坎聞晨撾。諸生堂奧分左右，相比以立如排衙。九牧之金充歲貢，搜出精礦遺其沙。卿雲褒武皆蜀秀，虎豹各自雄鬚牙。兩京得人廣數路，忍使丘中留子嗟。不然題名百許輩，無一顯者何謂耶。我亦典學老從事，試向坐中尋孟嘉。";
            var freqs = new Counter<string>(segmenter.Cut(s));
            foreach (var pair in freqs.MostCommon(5))
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }

            var data = new { s };
            return CustomResponse(new Response(ErrorCode.成功, data));
        }
    }
}