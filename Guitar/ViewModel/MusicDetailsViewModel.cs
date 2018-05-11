using Guitar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Guitar.ViewModel
{
    public class MusicDetailsViewModel
    {
        public Users Us { set; get; }
        public MusicScore MScore { set; get; }
        public MusicScoreStatistics MSStatistics { get; set; }
        public IEnumerable<MusicScore> MScore1 { get; set; }
        //public IEnumerable<MusicScoreStatistics> MSStatistics { get; set; }
        //public IEnumerable<MusicViewModel> MusicViewModel1 { get; set; }

    }
}