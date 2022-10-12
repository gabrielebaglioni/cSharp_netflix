using System;
namespace cSharp_netflix.Models
{
    public class Feature
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MediaInfo> MediaInfos { get; set; }

        public Feature()
        {
            MediaInfos = new List<MediaInfo>();
        }
    }
}

