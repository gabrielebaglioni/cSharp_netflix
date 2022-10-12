using System;
namespace cSharp_netflix.Models
{
    public class Episode : MediaContent
    {

        public int SeasonNumber { get; set; }
        public int TvSeriesId { get; set; }
        public TvSeries TvSerie { get; set; }

    }
}

