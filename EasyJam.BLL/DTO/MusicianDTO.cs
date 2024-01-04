using EasyJamDAL.Entities;
using EasyJamDAL.Entities.Enums;
using EasyJamDAL.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyJam.BLL.DTO
{
    public class MusicianDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Instrument1 { get; set; }
        public string? Instrument2 { get; set; }
        public string? Instrument3 { get; set; }
        public bool ? IsAvailable { get; set; }
        public MusicianDTO(IMusicien m)
        {
            Id = m.Id;
            Name = m.Name;
            Instrument1 = m.Instrument1;
            Instrument2 = m.Instrument2;
            Instrument3 = m.Instrument3;
            IsAvailable = m.IsAvailable;

        }
    }

}
