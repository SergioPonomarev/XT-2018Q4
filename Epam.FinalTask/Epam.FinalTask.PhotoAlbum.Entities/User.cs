using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FinalTask.PhotoAlbum.Entities
{
    public class User
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string UserRole { get; set; }

        public int UserAvatarId { get; set; }

        public IEnumerable<Image> UserImages { get; set; }
    }
}
