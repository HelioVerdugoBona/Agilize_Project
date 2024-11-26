using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agilize
{
    internal class Users
    {
        public String name {  get; set; }

        public String surname { get; set; }

        public String password { get; set; }

        public String email { get; set; }

        public String nickname {  get; set; }

        public Users() { }

        public Users(string name, string surname, string password, string email, string nickname)
        {
            this.name = name;
            this.surname = surname;
            this.password = password;
            this.email = email;
            this.nickname = nickname;
        }
    }
}
