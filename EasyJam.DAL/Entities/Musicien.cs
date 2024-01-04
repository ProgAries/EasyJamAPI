using EasyJamDAL.Entities.Enums;
using EasyJamDAL.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyJamDAL.Entities
{
    public class Musicien : IMusicien
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Instrument1 { get; set; }
        public string? Instrument2 { get; set; }
        public string? Instrument3 { get; set; }
        public bool IsAvailable { get; set; } = false;
    }
}
