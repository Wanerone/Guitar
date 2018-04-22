using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class UsersDal
    {
        GuitarEntities dbContext = new GuitarEntities();
        public int Add(Users user)
        {
            dbContext.Users.Add(user);
            return dbContext.SaveChanges();
        }
    }
}
