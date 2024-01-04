using EasyJamBLL.DTO;
using EasyJamDAL.Context;
using EasyJamDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EasyJamBLL.Services
{
    public class LoginService
    {
        private EasyJamContext _context;

        public LoginService(EasyJamContext context)
        {
            _context = context;
        }

        public AdminDTO Login(AdminLoginDTO adminLogin)
        {
            Admin? admin = _context.Admins.FirstOrDefault(u => u.Email == adminLogin.Email);
            if (admin is null)
            {
                throw new Exception("E-Mail or Password are incorrect");
            }
            if (!admin.EncodedPassword.SequenceEqual(SHA512.HashData(Encoding.UTF8.GetBytes(adminLogin.Password + admin.Salt))))
            {
                throw new Exception("E-Mail or Password are incorrect");
            }
            return new AdminDTO(admin);
        }

    }
}
