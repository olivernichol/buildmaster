using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuildMaster
{
    public partial class Log : Form
    {
        public Log() //Just a form for the log files that come out of butler. Proved very useful for checking progress and debugging.
        {
            InitializeComponent();
            Utilities.colourManager.colourDefinition(this, Properties.Settings.Default.BackColour, Properties.Settings.Default.ForeColour);
        }
    }
}
