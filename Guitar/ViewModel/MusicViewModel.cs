using Guitar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Guitar.ViewModel
{
    public class MusicViewModel
    {
        //public int Ms_id { set; get; }
        //public string Ms_title { set; get; }
        //public string Ms_img { set; get; }
        //public string Ms_label { set; get; }
        //public int ReadCount { set; get; }
        public MusicScore MScore { set; get; }
        public IEnumerable<MusicScore> MScore1 { get; set; }
        //public IEnumerable<MusicScoreStatistics> Statistics { get; set; }
    }
}