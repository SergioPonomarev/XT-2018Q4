using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FinalTask.PhotoAlbum.Entities
{
    public class Image
    {
        public int ImageId { get; set; }

        public string MimeType { get; set; }

        public string ImageDate { get; set; }

        public DateTime ImageDateOfUpload { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
    }
}
