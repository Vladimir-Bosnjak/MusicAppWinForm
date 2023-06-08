namespace Models
{
    public interface IAlbum
    {
        string Album_Title { get; set; }
        string Artist { get; set; }
        string Description { get; set; }
        int ID { get; set; }
        string Image_URL { get; set; }
        int Year { get; set; }
    }
}