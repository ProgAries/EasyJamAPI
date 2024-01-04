using EasyJamDAL.Entities;
using EasyJamDAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyJamBLL.DTO
{
    public class JamDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }

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
        public bool IsRandom { get; set; }
        public SessionState State { get; set; }
        public string SessionTime { get; set; }
        public JamDTO(JamSession j)
        {
            Id = j.Id;
            Name = j.Name;
            Mic1 = j.Mic1;
            Mic2 = j.Mic2;
            Drum = j.Drum;
            Bass = j.Bass;
            Gtr1 = j.Gtr1;
            Gtr2 = j.Gtr2;
            Keys = j.Keys;
            Other1 = j.Other1;
            Other2 = j.Other2;
            Other3 = j.Other3;
            IsRandom = j.IsRandom;
            State = j.State;
            SessionTime = j.SessionTime;
        }
    }
}
