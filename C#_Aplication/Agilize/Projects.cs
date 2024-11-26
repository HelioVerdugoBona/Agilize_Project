using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agilize
{
    internal class Projects
    {
        public String projectOwner {get; set;}
        public List<Users> arrayProjectUsers { get; set; }

        public List<Tasks> arrayTasks { get; set; }
        public Projects() { }

        public Projects(string projectOwner, List<Users> arrayProjectUsers, List<Tasks> arrayTasks)
        {
            this.projectOwner = projectOwner;
            this.arrayProjectUsers = arrayProjectUsers;
            this.arrayTasks = arrayTasks;
        }
    }
}
