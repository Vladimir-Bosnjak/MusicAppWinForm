using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Album
    {
        [Key]
        public int ID { get; set; }
        public string AlbumName { get; set; } = null!;
        public string ArtistName { get; set; } = null!;
        public int Year { get; set; }
        [Url]
        public string ImageURL { get; set; } = null!;
        public string Description { get; set; } = null!;

        //TODO: add a List<Track>() later.
    }
}