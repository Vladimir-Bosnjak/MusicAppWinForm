using PresentationLayer.Views.EventArguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Presenters
{
    public interface IPresenter
    {
        int AddNew(object? sender, AddOrEditEventArgs e);
        void GetAll(object? sender, EventArgs e);
        void SearchInAlbums(object? sender, string phraseToLookFor);
        void SetBindingSource();
    }
}
