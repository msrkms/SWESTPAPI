using Microsoft.EntityFrameworkCore;
using SWESTPAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWESTPAPI.Data
{
    public class SWESTPDBContext:DbContext
    {
        public SWESTPDBContext(DbContextOptions<SWESTPDBContext> options)
            : base(options)
        {
        }
    
        public DbSet<AppUser> appUsers { get; set; }
    
        public DbSet<Profile> Profile { get; set; }
    }
}
