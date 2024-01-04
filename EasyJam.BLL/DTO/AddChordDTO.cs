using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyJamBLL.DTO
{
    public class AddChordDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Chord { get; set; } = string.Empty;
    }
}
