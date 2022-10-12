using System;
using System.ComponentModel.DataAnnotations;

namespace cSharp_netflix.Models
{
    public class Actor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Il nome dell'attore e' necessario")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Il cognome dell' attore e' necessario")]
        public string Surname { get; set; }
        public List<MediaInfo> MediaInfos { get; set; }

        public Actor()
        {
            MediaInfos = new List<MediaInfo>();
        }

    }
}

