using JiebaNet.Segmenter.PosSeg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lx.Application.Interfaces.DataManager
{
    public interface IWordCloudAppService : IDisposable
    {
        public IEnumerable<Pair> Cut(string text);
    }
}
