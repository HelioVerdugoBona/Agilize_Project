using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agilize
{
    internal class Tasks
    {
        public DateTimePicker dateCreation {  get; set; }

        public DateTimePicker deadLine { get; set; }

        public Enum currentState { get; set; }

        public int sprint {  get; set; }

        public String estimatedTime { get; set; }

        public Tasks()
        {

        }

        public Tasks(DateTimePicker dateCreation, DateTimePicker deadLine, Enum currentState, int sprint, string estimatedTime)
        {
            this.dateCreation = dateCreation;
            this.deadLine = deadLine;
            this.currentState = currentState;
            this.sprint = sprint;
            this.estimatedTime = estimatedTime;
        }
    }
}
