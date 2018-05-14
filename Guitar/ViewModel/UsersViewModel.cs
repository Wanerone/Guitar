using Guitar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Guitar.ViewModel
{
    public class UsersViewModel
    {
        public Users Us { set; get; }
        public IEnumerable<MusicScore> MS { set; get; }
        public IEnumerable<Post> PO { set; get; }
        public IEnumerable<Friend> FD { set; get; }
        public IEnumerable<Video> VO { set; get; }
    }
}