﻿using HumanusHospital.Models;
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); //prevents table names from being pluralized
            modelBuilder.Entity<Patient>().HasKey(x => x.PersonIDNr); //expression to set primary key to non-conventional named property
            base.OnModelCreating(modelBuilder);
        }
    }
}
