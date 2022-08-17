using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BadlionClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await WaveClient.StartUp(siticoneProgressBar1, label2);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (siticoneProgressBar1.Value != 100)
            {
                WaveClient.AddValue(siticoneProgressBar1, 1);
            }
            else
            {
                timer1.Stop();
                label2.Text = "Status: Done! Loading BLCFR now!";
                Hide();
                new BLCFR().Show();
            }
        }

        private void siticoneImageButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"The Badlion Client For Roblox\n\n\nThe Badlion Client's purpose is to give you *little* visual advantages in combat, like ESP, and motionblur. Although BLCFR is not directly made for cheating, you still *CAN* infact, cheat on BedWars or any other game.\n\n\nIf you get banned with BLCFR, We Are NOT responsible. Most likely, you used cheats, which is, infact, against the TOS of roblox AND games.\n\n\n                Best of luck, {Environment.UserName}");
        }
    }
}
