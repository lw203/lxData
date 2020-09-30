using JiebaNet.Segmenter;
using JiebaNet.Segmenter.PosSeg;
using Lx.Application.Interfaces.DataManager;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lx.Application.Services.DataManager
{
    public class WordCloudAppService : IWordCloudAppService
    {
        PosSegmenter _posSegmenter = new PosSegmenter();


        //public WordCloudAppService(JiebaSegmenter jiebaSegmenter)
        //{
        //    _jiebaSegmenter = jiebaSegmenter;
        //}

        public IEnumerable<Pair> Cut(string text)
        {
            return _posSegmenter.Cut(text);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
