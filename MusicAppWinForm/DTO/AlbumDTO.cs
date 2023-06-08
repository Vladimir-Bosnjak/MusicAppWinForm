using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.DTO
{
    public class AlbumDTO
    {
        public string Album_Title { get; set; }
        public string Artist { get; set; }
        public int Year { get; set; }
        public string Image_URL { get; set; }
        public string Description { get; set; }
    }
}
