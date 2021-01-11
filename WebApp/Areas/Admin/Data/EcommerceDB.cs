using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApp.Areas.Admin.Models;

namespace WebApp.Areas.Admin.Data
{
    public class EcommerceDB:DbContext
    {
        public EcommerceDB(DbContextOptions<EcommerceDB> options)
   : base(options)
        {

        }

        public DbSet<SanPham> SanPham { get; set; }
        public DbSet<LoaiSP> LoaiSP { get; set; }
        public DbSet<Member> Member { get; set; }
    }

}
