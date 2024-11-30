using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agilize
{
    public class Projects
    {
        public String projectOwner {get; set;}
        public String projectName {get; set;}
        public List<Users> arrayProjectUsers { get; set; }

        public BindingList<Tasks> arrayTasks { get; set; }
        public Projects() { }

        public Projects(string projectOwner, String projectName, List<Users> arrayProjectUsers, BindingList<Tasks> arrayTasks)
        {
            arrayTasks = new BindingList<Tasks>();
            this.projectOwner = projectOwner;
            this.projectName = projectName;
            this.arrayProjectUsers = arrayProjectUsers;
            this.arrayTasks = arrayTasks;
        }
    }
}
