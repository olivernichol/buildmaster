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
    public partial class QuickPushMenu : Form
    {
        reader Reader = new reader();
        public string folderPathe; //Why does this have an e on the end? I wrote this during lockdown. I was bored.
        public QuickPushMenu(string folderPath)
        {
            InitializeComponent(); //On opening of quick push, assign theme, grab the folder path from the dialog box taht showed before, and read all the neccesary user data.
            Utilities.colourManager.colourDefinition(this, Properties.Settings.Default.BackColour, Properties.Settings.Default.ForeColour);
            folderPathe = folderPath;
            Reader.accountRead(null);
            Reader.gameRead(null, new ComboBox[] { gameSelector });
            Reader.channelRead(null, new ComboBox[] { channelSelector });
            Reader.triggerRead(null, trigInput);

        }

        private void quickPushButton_Click(object sender, EventArgs e) //When button pushed, load all the data into the main window. It's waiting for this data to come back from quick push.
        {
            quickPushData.folderPath = folderPathe;
            quickPushData.game = gameSelector.SelectedItem.ToString();
            quickPushData.channel = channelSelector.SelectedItem.ToString();
            quickPushData.version = custVerInput.Text;
            quickPushData.trigger = trigInput.SelectedItem.ToString();
            quickPushData.v1 = v1Input.Text;
            quickPushData.v2 = v2Input.Text;
            quickPushData.v3 = v3Input.Text;
            quickPushData.devlog = devlogCheck.Checked;
            this.Close();
        }
    }
}
