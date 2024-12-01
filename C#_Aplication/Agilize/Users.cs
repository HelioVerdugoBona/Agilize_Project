using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agilize
{
    public class Users
    {
        public String name {  get; set; }

        public String surname { get; set; }

        public String password { get; set; }

        public String email { get; set; }

        public String nickname {  get; set; }

        public BindingList<String> projectsList { get; set; }
        public Users() { }

        public Users(string name, string surname, string password, string email, string nickname, BindingList<String> projectsList)
        {
            projectsList = new BindingList<String>();
            this.name = name;
            this.surname = surname;
            this.password = password;
            this.email = email;
            this.nickname = nickname;
            this.projectsList = projectsList;
        }
    }
}
