using Microsoft.EntityFrameworkCore;
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
    {
    }
}
