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

        //------------------------------------------------------------

        public Presenter(IMainView mainView, IAlbumRepository albumRepository)
        {
            _albumBindingSource = new BindingSource();
            _mainView = mainView;
            _albumRepository = albumRepository;
            AssociateEvents();
        }

        //--

        private void AssociateEvents()
        {
            _mainView.GetAll += GetAll;
            _mainView.SearchInAlbums += SearchInAlbums;
            _mainView.Add += AddNew;
        }

        //--------------- main functionality --------------------------

        public int AddNew(object? sender, AlbumDTO albumDTO)
        {
            Album theAlbum = new();
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
                _mainView.CRUD_IsSuccessful = true;
                return _albumRepository.AddAlbum(theAlbum);
            }
        }

        //--

        public void GetAll(object? sender, EventArgs e)
        {
            _albumList = _albumRepository.GetAll();
            SetBindingSource();
        }

        public void SearchInAlbums(object? sender, string phraseToLookFor)
        {
            _albumList = _albumRepository.GetAlbumsByValue(phraseToLookFor);
            SetBindingSource();
        }

        //------------------helpers / utilities ------------------------

        public void SetBindingSource()
        {
            _albumBindingSource.DataSource = _albumList;
            _mainView.SetAlbumsBindingSource(_albumBindingSource);
        }
    }
}