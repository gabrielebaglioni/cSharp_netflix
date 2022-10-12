using System;
namespace cSharp_netflix.Models
{
    public class MediaInfo
    {
        public int MediaInfoId { get; set; }
        public string Year { get; set; }
        public bool IsNew { get; set; }

        public int? MovieId { get; set; }
        public Movie Movie { get; set; }

        public int? TvSeriesId { get; set; }
        public TvSeries Serie { get; set; }
        public List<Actor> Cast { get; set; }

        public List<Genre> Genres { get; set; }
        public List<Feature> Features { get; set; }


    }
}

