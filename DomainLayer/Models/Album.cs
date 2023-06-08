using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Album : IAlbum
    {
        [Key]
        public int ID { get; set; }

        [MinLength(1) ,StringLength(100), Required (ErrorMessage = "An Album Title is required (max 100 char).")]       
        public string Album_Title { get; set; } = null!;

        [MinLength(1), StringLength(100), Required(AllowEmptyStrings = false, 
            ErrorMessage = "An Artist Name is required (max 50 char).")]
        public string Artist { get; set; } = null!;

        [Required(ErrorMessage = "A Year (album release) is required")]
        [Range(1900, 2100, ErrorMessage = "The year must be between 1900 and 2200.")]
        public int Year { get; set; }

        [Url, Required(ErrorMessage = "An URL to an image of the Album is required.")]
        public string Image_URL { get; set; } = null!;

        [MinLength(20), Required(AllowEmptyStrings = false, 
            ErrorMessage = "A description of the Album is required with a minimum of 20 characters.")]
        public string Description { get; set; } = null!;

        //TODO: add a List<Track>() later.
    }
}