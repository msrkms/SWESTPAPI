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

        public DbSet<SweEvent> sweEvents { get; set; }

        public DbSet<Course> courses { get; set; }

        public DbSet<Slot> slots { get; set; }
        
        public DbSet<CourseOffer> courseOffers { get; set; }

        public DbSet<ClassRoutine> classRoutines { get; set; }

        public DbSet<ExamRoutine> examRoutines { get; set; }

        public DbSet<UserCourse> userCourses { get; set; }


        public DbSet<MyTask> myTasks { get; set; }

        public DbSet<CourseOfferSection> courseOfferSections { get; set; }

     }
}
