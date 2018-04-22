using Model;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class UsersBll
    {
        private UsersDal dal = new UsersDal();
        public bool Add(Users t)
        {
            return dal.Add(t) > 0;
        }
    }
}
