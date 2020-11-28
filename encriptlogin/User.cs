using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace encriptlogin
{
    class User
    {
        private string id;
        private string parola;

        public string getId()
        {
            return this.id;
        }

        public string getParola()
        {
            return this.parola;
        }

        public void setId(string id)
        {
            this.id = id;
        }

        public void setParola(string parola)
        {
            this.parola = parola;
        }

    }
}
