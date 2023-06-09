﻿using PresentationLayer.EventArguments;

namespace PresentationLayer.Presenters
{
    public interface IMusicFormPresenter
    {
        void OnAdd(object? sender, AlbumDataEventArgs album);
        void OnUpdate(object? sender, AlbumDataEventArgs album);
        void OnGetAll(object? sender, EventArgs e);
        void OnSearchInAlbums(object? sender, SearchEventArgs e);
    }
}
