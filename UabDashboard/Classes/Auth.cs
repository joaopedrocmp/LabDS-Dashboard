using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UabDashboard.Classes
{
    class Auth
    {
        string Password { get; set; }
        int Numero { get; set; }

        public Auth(int numero, string password)
        {
            this.Numero = numero;
            this.Password = password;
        }

        public int GetUser()
        {
            return this.Numero;
        }

        public string GetPassword()
        {
            return this.Password;
        }
    }
}
