using Models;
using PresentationLayer.Common;
using PresentationLayer.EventArguments;
using ServiceLayer;

namespace PresentationLayer.Presenters
{
    //This Presenter class is for the main view.
    //Assuming each view has its own presenter.

    public class MusicFormPresenter : IMusicFormPresenter
    {
        private readonly IMusicFormView _musicFormView;
        private readonly IAlbumRepository _albumRepository;
        private IEnumerable<Album>? _albumList;
        private readonly BindingSource _albumBindingSource;
        private readonly BindingSource _columnNamesBindingsource;

        //--------------------------------------------------------------

        public MusicFormPresenter(IMusicFormView mainView, IAlbumRepository albumRepository)
        {
            _albumBindingSource = new BindingSource();
            _columnNamesBindingsource = new BindingSource();
            _musicFormView = mainView;
            _albumRepository = albumRepository;
            AssociateEvents();
        }
        private void AssociateEvents()
        {
            _musicFormView.GetAll += OnGetAll;
            _musicFormView.SearchInAlbumsEvent += OnSearchInAlbums;
            _musicFormView.AddEvent += OnAdd;
            _musicFormView.UpdateAlbumEvent += OnUpdate;
            _musicFormView.GetColumnNamesFromAlbumTableEvent += OnGetColumnNamesFromTable;
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
                _musicFormView.Message = validation.GetFormattedValidationResults();
                _musicFormView.CRUD_IsSuccessful = false;
                _musicFormView.RowsAffected = 0;
            }
            else //data validated
            {
                _musicFormView.RowsAffected = _albumRepository.AddAlbum(theAlbum);

                //Query has been executed but nothing was added
                if (_musicFormView.RowsAffected == 0)
                {
                    _musicFormView.Message =
                        "No records were affected. Did you try to add an album with the same ID?";
                    _musicFormView.CRUD_IsSuccessful = false;
                }
                else
                {
                    _musicFormView.CRUD_IsSuccessful = true;
                }
            }
        }

        //--

        public void OnUpdate(object? sender, AlbumDataEventArgs album)
        {
            Album theAlbum = new()
            {
                ID = album.ID,
                Album_Title = album.Album_Title,
                Artist = album.Artist,
                Year = album.Year
            };
            ;
            theAlbum.Image_URL = album.Image_URL;
            theAlbum.Description = album.Description;

            ModelValidator<Album> validation = new();

            if (validation.ValidateModel(theAlbum) == false) //validation failed
            {
                _musicFormView.Message = validation.GetFormattedValidationResults();
                _musicFormView.CRUD_IsSuccessful = false;
                _musicFormView.RowsAffected = 0;
            }
            else //validation success
            {
                _musicFormView.CRUD_IsSuccessful = true;
                _musicFormView.RowsAffected = _albumRepository.Edit(theAlbum);
            }
        }

        //--

        public void OnGetAll(object? sender, EventArgs e)
        {
            _albumList = _albumRepository.GetAll();
            _musicFormView.RowsAffected = _albumList.Count();
            SetGridViewBindingSource();
        }

        //--

        public void OnSearchInAlbums(object? sender, SearchEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.SearchColumn))
            {
                _albumList = _albumRepository.GetAlbumsByValue(e.SearchPhrase, e.SearchColumn);
                _musicFormView.RowsAffected = _albumList.Count();
                SetGridViewBindingSource();
            }
            else
            {
                _musicFormView.Message =
                    "Saerch was HALTED: the table name was NULL or EMPTY (no table name)";
                _musicFormView.RowsAffected = 0;
            }
        }

        public void OnGetColumnNamesFromTable(object? sender, EventArgs e)
        {
            //In Application Settings
            string tableName = Properties.Settings.Default.TableName;

            _columnNamesBindingsource.DataSource = _albumRepository.
                GetTableColumns(tableName);
            _musicFormView.SetAlbumColumnNamesBindingSource(_columnNamesBindingsource);
        }

        //------------------helpers / utilities ------------------------

        private void SetGridViewBindingSource()
        {
            _albumBindingSource.DataSource = _albumList;
            _musicFormView.SetAlbumsBindingSource(_albumBindingSource);
        }

    }
}