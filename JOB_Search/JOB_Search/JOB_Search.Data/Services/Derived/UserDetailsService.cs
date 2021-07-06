using JOB_Search.Common.Models;
using JOB_Search.Data.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JOB_Search.Data.Services.Derived
{
    public class UserDetailsService : UserDetails
    {
        readonly JobSearchContext db = new JobSearchContext();

        public override int AddUser(Users users)
        {
            db.Users.Add(users);
            int recordInserted = db.SaveChanges();
            return recordInserted;
        }

        public override List<Users> GetallUsers()
        {
            return db.Users.ToList();
        }


    }
}
