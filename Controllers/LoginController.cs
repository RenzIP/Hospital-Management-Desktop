using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management.Controllers
{
    public class LoginController
    {
        public bool PerformLogin(string username, string password)
        {
            // Hardcoded Logic for now
            if (username == "admin" && password == "admin")
            {
                return true;
            }
            return false;
        }
    }
}
