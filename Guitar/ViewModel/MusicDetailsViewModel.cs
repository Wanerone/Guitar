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
        //public IEnumerable<Users> Us { set; get; }
        //public IEnumerable<MusicScoreStatistics> MSStatistics { get; set; }
        public IEnumerable<Users> Us2 { get; set; }
        public MusicScoreStatistics MSStatistics { get; set; }
        public IEnumerable<MusicScore> MScore1 { get; set; }
        public IEnumerable<MusicScore> MScore2 { get; set; }
        public IEnumerable<MusicScore> MScore3 { get; set; }
        public IEnumerable<MusicScore> MScore4 { get; set; }
        public IEnumerable<MusicScore> MScore5 { get; set; }
        public IEnumerable<MusicScoreComment> MSC { get; set; }
        public IEnumerable<MusicScoreReply> Msr { get; set; }
        public IEnumerable<MusicCommentReplyViewModel> MSR { get; set; }
        //public IEnumerable<MusicScoreStatistics> MSStatistics { get; set; }
        //public IEnumerable<MusicViewModel> MusicViewModel1 { get; set; }

    }
}