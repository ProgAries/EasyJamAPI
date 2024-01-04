using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyJamDAL.Entities
{
    public class Admin
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public byte[] EncodedPassword { get; set; } = Array.Empty<byte>();
        public Guid Salt { get; set; }
    }
}
