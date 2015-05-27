﻿using AutomatedTellerMachine.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AutomatedTellerMachine.Models
{
    public interface IApplicationDbContext
    {
         IDbSet<CheckingAccount> CheckingAccounts { get; set; }
         IDbSet<GameInfo> GamesInfos { get; set; }
         IDbSet<NewsModel> NewsModels { get; set; }
       


        int SaveChanges();
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
            base.OnModelCreating(modelBuilder);
        }

        public IDbSet<CheckingAccount> CheckingAccounts { get; set; }
        public IDbSet<GameInfo> GamesInfos { get; set; }
        public IDbSet<NewsModel> NewsModels { get; set; }

        public IDbSet<ForumModel> ForumModels { get; set; }

        public IDbSet<CommentModel> CommentModels { get; set; }

      //  public System.Data.Entity.DbSet<AutomatedTellerMachine.Models.ApplicationUser> ApplicationUsers { get; set; }

    }

}