using EasyJamDAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EasyJamDAL.Configurations
{
    internal class AdminConfig : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            Guid saltGuid = Guid.NewGuid();
            builder.HasData(new Admin
            {
                Id = Guid.NewGuid(),
                FirstName = "Rocco",
                LastName = "Pasanisi",
                Email = "Test@test.com",
                Salt = saltGuid,
                EncodedPassword = SHA512.HashData(Encoding.UTF8.GetBytes("jams1234" + saltGuid.ToString())),
            });
        }
    }
}
