﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AutoVerhuurKantoor_DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RentalsEntities : DbContext
    {
        public RentalsEntities()
            : base("name=RentalsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Agency> Agencies { get; set; }
        public virtual DbSet<Agency_Car> Agency_Car { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Rental> Rentals { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}