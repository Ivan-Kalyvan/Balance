using Balance.Entities.DbSet;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balance.DataService.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public virtual DbSet<Slider> Sliders { get; set; }
        public virtual DbSet<InfoCard> InfoCards { get; set; }
        public virtual DbSet<Workout> Workouts { get; set; }
        public virtual DbSet<Certificate> Certificates { get; set; }
        public virtual DbSet<Fact> Facts { get; set; }
        public virtual DbSet<PhotoURL> PhotosURL { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {

        }
    }
}
