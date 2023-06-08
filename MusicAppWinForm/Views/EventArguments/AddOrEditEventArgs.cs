
namespace PresentationLayer.Views.EventArguments
{
    public class AddOrEditEventArgs : EventArgs
    {
        public string AlbumTitle { get; }
        public string Artist { get; }
        public int Year { get; }
        public string ImageURL { get; }
        public string Description { get; }

        // Add more properties for other textboxes if needed

        public AddOrEditEventArgs(string albumTitle, string artist, int year, string imageURL, string description)
        {
            AlbumTitle = albumTitle;
            Artist = artist;
            Year = year;
            ImageURL = imageURL;
            Description = description;
        }
    }
}
