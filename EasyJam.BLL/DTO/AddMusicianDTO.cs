
using System.ComponentModel.DataAnnotations;
using EasyJamDAL.Entities.Enums;

namespace EasyJamBLL.DTO
{
    public class AddMusicianDTO
    {
        [Required, MinLength(3), MaxLength(25)]
        public string? Name { get; set; }
        public string? Instrument1 { get; set; }
        public string? Instrument2 { get; set; }
        public string? Instrument3 { get; set; }
        public bool IsAvailable { get; set; }
    }
}
