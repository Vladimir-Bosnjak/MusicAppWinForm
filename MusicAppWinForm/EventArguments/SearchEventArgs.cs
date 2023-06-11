

namespace PresentationLayer.EventArguments
{
    public class SearchEventArgs : EventArgs
    {
        public string SearchPhrase { get;  } = null!;
        public string SearchColumn { get; } = null!;

        public SearchEventArgs(string searchPhrase, string searchColumn)
        {
            SearchPhrase = searchPhrase;
            SearchColumn = searchColumn;
        }
    }
}
