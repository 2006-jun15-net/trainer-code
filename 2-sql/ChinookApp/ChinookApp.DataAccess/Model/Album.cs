using System;
using System.Collections.Generic;

namespace ChinookApp.DataAccess.Model
{
    public partial class Album
    {
        public Album()
        {
            Track = new HashSet<Track>();
        }

        public int AlbumId { get; set; }
        public string Title { get; set; }
        public int ArtistId { get; set; } // foreign key column

        public virtual Artist Artist { get; set; } // navigation property
        public virtual ICollection<Track> Track { get; set; } // collection navigation property
    }
}
