using EasyJamDAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyJamBLL.DTO
{
    public class AdminDTO
    {
        public Guid Id { get; set; }

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string? LastName { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        public AdminDTO(Admin a)
        {
            Id = a.Id;
            FirstName = a.FirstName;
            LastName = a.LastName;
            Email = a.Email;
        }

    }
}
