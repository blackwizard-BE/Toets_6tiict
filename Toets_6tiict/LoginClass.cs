using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEF1
{
    internal class LoginClass
    {
        private string username;
        private string password;
        public string toepassing { get; set; }

        public void Save(string user, string pass, string toep)
        {
            username = user;
            password = pass;
            toepassing = toep;

        }

        public string OphalenUser()
        {
            return username;
        }
        public string OphalenPass()
        {
            return password;
        }

    }
}
