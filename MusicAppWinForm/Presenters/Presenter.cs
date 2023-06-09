using Models;
using PresentationLayer.Common;
using PresentationLayer.DTO;
using ServiceLayer;

namespace PresentationLayer.Presenters
{
    //This Presenter class is for the main view.
    //Assuming each view has its own presenter.
    public class Presenter : IPresenter
    {
        private readonly IMainView _mainView;
        private readonly IAlbumRepository _albumRepository;
        private IEnumerable<IAlbum>? _albumList;
        private readonly BindingSource _albumBindingSource;
        private readonly BindingSource _columnNamesBindingsource;

        //--------------------------------------------------------------

        public Presenter(IMainView mainView, IAlbumRepository albumRepository)
        {
            _albumBindingSource = new BindingSource();
            _columnNamesBindingsource = new BindingSource();
            _mainView = mainView;
            _albumRepository = albumRepository;
            AssociateEvents();
        }


        //--------------- main functionality ---------------------------

        public int OnAdd(object? sender, AlbumDTO albumDTO)
        {
            Album theAlbum = new();

            theAlbum.ID = albumDTO.ID;
            theAlbum.Album_Title = albumDTO.Album_Title;
            theAlbum.Artist = albumDTO.Artist;
            theAlbum.Year = albumDTO.Year;
            theAlbum.Image_URL = albumDTO.Image_URL;
            theAlbum.Description = albumDTO.Description;

            ModelValidator<Album> validation = new();
            if (validation.ValidateModel(theAlbum) == false)
            {
                _mainView.Message = validation.GetFormattedValidationResults();
                _mainView.CRUD_IsSuccessful = false;
                return 0;
            }
            else
            {
                int recordsAffected = _albumRepository.AddAlbum(theAlbum);
                if (recordsAffected == 0)
                {
                    _mainView.Message =
                        "No records were affected. Did you try to add an album with the same ID?";
                    _mainView.CRUD_IsSuccessful = false;
                }
                else
                    _mainView.CRUD_IsSuccessful = true;

                return recordsAffected;
            }
        }

        //--

        public void OnGetAll(object? sender, EventArgs e)
        {
            _albumList = _albumRepository.GetAll();
            SetGridViewBindingSource();
        }

        //--

        public void OnSearchInAlbums(object? sender, string searchPhrase, string? tableName)
        {
            if (!string.IsNullOrEmpty(tableName))
            {
                _albumList = _albumRepository.GetAlbumsByValue(searchPhrase, tableName);
                SetGridViewBindingSource();
            }
            else
            {
                _mainView.Message =
                    "No records were affected: the table name was NULL or EMPTY (no table name)";
            }
        }

        //--

        public int OnUpdate(object? sender, AlbumDTO albumDTO)
        {
            Album theAlbum = new();

            theAlbum.ID = albumDTO.ID;
            theAlbum.Album_Title = albumDTO.Album_Title;
            theAlbum.Artist = albumDTO.Artist;
            theAlbum.Year = albumDTO.Year; ;
            theAlbum.Image_URL = albumDTO.Image_URL;
            theAlbum.Description = albumDTO.Description;

            ModelValidator<Album> validation = new();

            if (validation.ValidateModel(theAlbum) == false)
            {
                _mainView.Message = validation.GetFormattedValidationResults();
                _mainView.CRUD_IsSuccessful = false;
                return 0;
            }
            else
            {
                _mainView.CRUD_IsSuccessful = true;
                return _albumRepository.Edit(theAlbum);
            }
        }

        //--
        //!!!!!!!!!! Temporary, I'll think of later what to do with this !!!!!!!!!!!
        public void OnGetColumnNamesFromTable(object? sender, EventArgs e)
        {
            _columnNamesBindingsource.DataSource = _albumRepository.GetTableColumns("Albums");
            SetAlbumColumnNamesBindingSource();
        }

        //------------------helpers / utilities ------------------------

        private void SetGridViewBindingSource()
        {
            _albumBindingSource.DataSource = _albumList;
            _mainView.SetAlbumsBindingSource(_albumBindingSource);
        }
        private void SetAlbumColumnNamesBindingSource() =>
            _mainView.SetAlbumColumnNamesBindingSource(_columnNamesBindingsource);
        private void AssociateEvents()
        {
            _mainView.GetAll += OnGetAll;
            _mainView.SearchInAlbums += OnSearchInAlbums;
            _mainView.Add += OnAdd;
            _mainView.UpdateAlbumEvent += OnUpdate;
            _mainView.GetColumnNamesFromAlbumTable += OnGetColumnNamesFromTable;
        }
    }
}