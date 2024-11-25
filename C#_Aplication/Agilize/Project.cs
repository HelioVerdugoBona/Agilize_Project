using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agilize
{
    public partial class Project : Form
    {
        public Project()
        {
            InitializeComponent();
            SetAllLbls();
        }


        private void SetAllLbls()
        {
            homeLBL.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            manageMembersLBL.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            calendarLBL.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            projectFoldersLBL.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            acountLBL.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            SettingLBL.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
        }

        private void newProjectIMG_Click(object sender, EventArgs e)
        {

        }
    }
}
