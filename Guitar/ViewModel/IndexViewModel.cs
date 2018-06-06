using Guitar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Guitar.ViewModel
{
    public class IndexViewModel
    {
        public MusicScore MScore { set; get; }
        public IEnumerable<Users> Us { set; get; }
        public IEnumerable<MusicScore> MScore1 { get; set; }
        public IEnumerable<MusicViewModel> MusicViewModel1 { get; set; }
        public IEnumerable<Video> Videos { get; set; }
    }
}