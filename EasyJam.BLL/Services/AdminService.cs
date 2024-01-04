using EasyJamDAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyJamBLL.Services
{
    public class AdminService
    { 
        private readonly EasyJamContext _context;
        public AdminService(EasyJamContext context) 
        {
            _context = context;
        }


    }
}
