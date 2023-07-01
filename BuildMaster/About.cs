using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace BuildMaster
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            Utilities.colourManager.colourDefinition(this, Properties.Settings.Default.BackColour, Properties.Settings.Default.ForeColour);
        }

        private void licenseLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo license = new ProcessStartInfo("https://github.com/itchio/butler/blob/master/LICENSE");
            Process.Start(license);
        }

        private void sourceLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo github = new ProcessStartInfo("https://github.com/olivernichol/buildmaster");
            Process.Start(github);
        }

        private void webLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo website = new ProcessStartInfo("https://olivernichol.co.uk/");
            Process.Start(website);
        }

        private void twitchLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo twitch = new ProcessStartInfo("https://www.twitch.tv/neoncoding");
            Process.Start(twitch);
        }
    }
}
