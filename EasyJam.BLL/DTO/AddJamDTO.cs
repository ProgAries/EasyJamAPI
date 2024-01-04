using EasyJamDAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyJamBLL.DTO
{
    public class AddJamDTO
    {
        public string? Mic1 { get; set; }
        public string? Mic2 { get; set; }
        public string? Drum { get; set; }
        public string? Bass { get; set; }
        public string? Gtr1 { get; set; }
        public string? Gtr2 { get; set; }
        public string? Keys { get; set; }
        public string? Other1 { get; set; }
        public string? Other2 { get; set; }
        public string? Other3 { get; set; }
        public bool IsRandom { get; set; } = false;

    }
}
