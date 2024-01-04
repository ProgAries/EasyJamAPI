using EasyJamDAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyJamBLL.DTO
{
    public class EditMusiDTO
    {
        public string? Instrument1 { get; set; }
        public string? Instrument2 { get; set; }
        public string? Instrument3 { get; set; }
        public bool IsAvailable { get; set; }
    }
}
