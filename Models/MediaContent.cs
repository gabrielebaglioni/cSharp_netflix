using System;
namespace cSharp_netflix.Models
{
    public class MediaContent
    {
        public int Id { get; set; }
        public string Title { get; set; }
        //definita in minuti
        public int Durata { get; set; }
        public string Description { get; set; }
        public int VisualisationCount { get; set; }

    }
}

