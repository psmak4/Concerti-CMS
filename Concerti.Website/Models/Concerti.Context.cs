﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Concerti.Website.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ConcertiEntities : DbContext
    {
        public ConcertiEntities()
            : base("name=ConcertiEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<SettingOption> SettingOptions { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<Page> Pages { get; set; }
        public virtual DbSet<BlogPost> BlogPosts { get; set; }
    }
}
