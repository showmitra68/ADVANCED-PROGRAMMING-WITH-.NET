﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZeroHungerAssignment.DB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ZeroHungerEntities : DbContext
    {
        public ZeroHungerEntities()
            : base("name=ZeroHungerEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CollectRequest> CollectRequests { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<FoodDistribution> FoodDistributions { get; set; }
        public virtual DbSet<NGO> NGOs { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
    }
}
