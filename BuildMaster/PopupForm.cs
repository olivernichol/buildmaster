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
    public partial class PopupForm : Form
    {
        public PopupForm(string PopupText) //Literally just a popup telling you what's going on. Basically just a overcomplicated dialog box.
        {
            InitializeComponent();
            Utilities.colourManager.colourDefinition(this, Properties.Settings.Default.BackColour, Properties.Settings.Default.ForeColour);
            label1.Text = PopupText;
        }
    }
}
