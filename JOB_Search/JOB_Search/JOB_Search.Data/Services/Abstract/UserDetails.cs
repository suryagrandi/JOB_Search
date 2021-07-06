using JOB_Search.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace JOB_Search.Data.Services.Abstract
{
    public abstract class UserDetails
    {
        public abstract List<Users> GetallUsers();
        public abstract int AddUser(Users users);
    }
}
