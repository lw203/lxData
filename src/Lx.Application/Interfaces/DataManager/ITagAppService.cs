using Lx.Application.ViewModels.DataManager;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lx.Application.Interfaces.DataManager
{
    public interface ITagAppService : IDisposable
    {
        List<TagViewModel> GetAll();
        void Add(TagAddViewModel model);
    }
}
