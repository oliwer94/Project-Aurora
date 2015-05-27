using AutomatedTellerMachine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutomatedTellerMachine.Services
{
    public class CheckingAccountService
    {
        private IApplicationDbContext db;

        public CheckingAccountService(IApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        public void CreateCheckingAccount(string firstName, string lastName, string userId, string nickname, string email, string dob )
        {     
            var checkingAccount = new CheckingAccount
            {
                FirstName = firstName, LastName = lastName, ApplicationUserId = userId, Nickname = nickname, Email = email, Dob = dob
            };
           
            db.CheckingAccounts.Add(checkingAccount);
            db.SaveChanges();
        }

        public void DeleteCheckingAccount(string id)
        {
            var user = db.CheckingAccounts.Where(c => c.ApplicationUserId == id).First();
            db.CheckingAccounts.Remove(user);
            db.SaveChanges();
        }


    }
}