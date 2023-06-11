using Models;
using PresentationLayer.Common;
using PresentationLayer.EventArguments;
using ServiceLayer;

namespace PresentationLayer.Presenters
{
    //This Presenter class is for the main view.
    //Assuming each view has its own presenter.

    public class Presenter : IPresenter
    {
        private readonly IMusicFormView _mainView;
        private readonly IAlbumRepository _albumRepository;
        private IEnumerable<IAlbum>? _albumList;
        private readonly BindingSource _albumBindingSource;
        private readonly BindingSource _columnNamesBindingsource;

        //--------------------------------------------------------------

        public Presenter(IMusicFormView mainView, IAlbumRepository albumRepository)
        {
            _albumBindingSource = new BindingSource();
            _columnNamesBindingsource = new BindingSource();
            _mainView = mainView;
            _albumRepository = albumRepository;
            AssociateEvents();
        }
        private void AssociateEvents()
        {
            _mainView.GetAll += OnGetAll;
            _mainView.SearchInAlbums += OnSearchInAlbums;
            _mainView.AddEvent += OnAdd;
            _mainView.UpdateAlbumEvent += OnUpdate;
            _mainView.GetColumnNamesFromAlbumTableEvent += OnGetColumnNamesFromTable;
        }

        //--------------- main functionality ---------------------------

        public void OnAdd(object? sender, AlbumDataEventArgs album)
        {
            Album theAlbum = new()
            {
                ID = album.ID,
                Album_Title = album.Album_Title,
                Artist = album.Artist,
                Year = album.Year,
                Image_URL = album.Image_URL,
                Description = album.Description
            };

            ModelValidator<Album> validation = new();
            if (validation.ValidateModel(theAlbum) == false) //validation failed
            {
                _mainView.Message = validation.GetFormattedValidationResults();
                _mainView.CRUD_IsSuccessful = false;
                _mainView.RowsAffected = 0;
            }
            else
            {
                _mainView.RowsAffected = _albumRepository.AddAlbum(theAlbum);

                //Query has been executed but nothing was added
                if (_mainView.RowsAffected == 0)
                {
                    _mainView.Message =
                        "No records were affected. Did you try to add an album with the same ID?";
                    _mainView.CRUD_IsSuccessful = false;
                }
                else
                {
                    _mainView.CRUD_IsSuccessful = true;
                }
            }
        }

        //--

        public void OnUpdate(object? sender, AlbumDataEventArgs album)
        {
            Album theAlbum = new();

            theAlbum.ID = album.ID;
            theAlbum.Album_Title = album.Album_Title;
            theAlbum.Artist = album.Artist;
            theAlbum.Year = album.Year; ;
            theAlbum.Image_URL = album.Image_URL;
            theAlbum.Description = album.Description;

            ModelValidator<Album> validation = new();

            if (validation.ValidateModel(theAlbum) == false) //validation failed
            {
                _mainView.Message = validation.GetFormattedValidationResults();
                _mainView.CRUD_IsSuccessful = false;
                _mainView.RowsAffected = 0;
            }
            else
            {
                _mainView.CRUD_IsSuccessful = true;
                _mainView.RowsAffected = _albumRepository.Edit(theAlbum);
            }
        }

        //--

        public void OnGetAll(object? sender, EventArgs e)
        {
            _albumList = _albumRepository.GetAll();
            _mainView.RowsAffected = _albumList.Count();
            SetGridViewBindingSource();
        }

        //--

        public void OnSearchInAlbums(object? sender, SearchEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.SearchColumn))
            {
                _albumList = _albumRepository.GetAlbumsByValue(e.SearchPhrase, e.SearchColumn);
                _mainView.RowsAffected = _albumList.Count();
                SetGridViewBindingSource();
            }
            else
            {
                _mainView.Message =
                    "Saerch was HALTED: the table name was NULL or EMPTY (no table name)";
                _mainView.RowsAffected = 0;
            }
        }

        //--

        //!!!!!!!!!! Temporary, I'll think of later what to do with this !!!!!!!!!!!
        public void OnGetColumnNamesFromTable(object? sender, EventArgs e)
        {
            _columnNamesBindingsource.DataSource = _albumRepository.GetTableColumns("Albums");
            _mainView.SetAlbumColumnNamesBindingSource(_columnNamesBindingsource);
        }

        //------------------helpers / utilities ------------------------

        private void SetGridViewBindingSource()
        {
            _albumBindingSource.DataSource = _albumList;
            _mainView.SetAlbumsBindingSource(_albumBindingSource);
        }

    }
}