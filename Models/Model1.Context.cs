﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace App_mobile.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class API_MOBILEEntities1 : DbContext
    {
        public API_MOBILEEntities1()
            : base("name=API_MOBILEEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<learn> learns { get; set; }
        public virtual DbSet<login> logins { get; set; }
        public virtual DbSet<word> words { get; set; }
        public virtual DbSet<favourite> favourites { get; set; }
        public virtual DbSet<topic> topics { get; set; }
    }
}
