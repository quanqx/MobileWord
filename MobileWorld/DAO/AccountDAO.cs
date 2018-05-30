using MobileWorld.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileWorld.DAO
{
    public class AccountDAO
    {
        private Data data;

        public AccountDAO()
        {
            data = new Data();
        }

        public Boolean checkAccount(String Email, String Pass)
        {
            if(data.Accounts.SingleOrDefault(p => p.Email == Email && p.Pass == Pass) == null)
            {
                return false;
            }
            return true;
        }

        public Account getAccountByEmail(String Email)
        {
            return data.Accounts.SingleOrDefault(p => p.Email == Email);
        }

        public Boolean EmailIsExists(String Email)
        {
            if(data.Accounts.SingleOrDefault(p=>p.Email == Email) != null)
            {
                return true;
            }
            return false;
        }

        public void add(Account acc)
        {
            data.Accounts.Add(acc);
            data.SaveChanges();
        }
    }
}