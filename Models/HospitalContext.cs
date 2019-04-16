using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace parkingApp.Models
{
    public class HospitalContext : DbContext
    {
        public DbSet<Parking> Parkings { get; set; }
        public DbSet<ParkingAdmin> ParkingAdmins { get; set; }
    }
}