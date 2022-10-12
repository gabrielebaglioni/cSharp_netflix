using System;
using System.ComponentModel.DataAnnotations;

namespace cSharp_netflix.Models
{
    public class Actor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Inserisci il nome")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Inserisci il cognome")]
        public string Surname { get; set; }
        public List<MediaInfo> MediaInfos { get; set; }

        public Actor()
        {
            MediaInfos = new List<MediaInfo>();
        }

    }
}

