using HumanusHospital.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace HumanusHospital.DAL
{
    public class HospitalContext : DbContext
    {



        public HospitalContext() : base("HospitalContext")
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); //prevents table names from being pluralized
            modelBuilder.Entity<Patient>().HasKey(x => x.PersonIDNr); //expression to set primary key to non-conventionally named property
            //modelBuilder.Entity<Patient>().HasOptional(p => p.Room).WithMany(r => r.Patient).Map(t => t.MapKey("PersonIDNr").MapKey("RoomID").ToTable("PatientRoom")); //testing a thing ignore this
            base.OnModelCreating(modelBuilder);
        }
    }
}

