using EasyExploits;
using KrnlAPI;
using sxlib;
using sxlib.Specialized;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BadlionClient
{
    public partial class BLCFR : Form
    {
        public static SxLibWinForms synXlib;
        public BLCFR()
        {
            InitializeComponent();
            if (File.Exists("isSynapse.txt"))
            {
                synX.Checked = true;
                krnl.Enabled = false;
                EX.Enabled = false;
                synX.Enabled = false;

                if (!File.Exists(Application.StartupPath + "\\Synapse Launcher.exe"))
                {
                    MessageBox.Show("You are going Synapse Mode but there is sadly no Synapse Launcher in your current folder. You must drag all Wave Client files into your syn folder for SynX mode to work.", "oops", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Application.Exit();
                }
                synXlib = SxLib.InitializeWinForms(this, Application.StartupPath);

                synXlib.LoadEvent += (Event, obj) => { BLCFRstatus.Text = " - " + Event.ToString(); };
                synXlib.AttachEvent += (Event, obj) => { BLCFRstatus.Text = " - " + Event.ToString(); };
                Thread.Sleep(200);
                synXlib.Load();
                WaveClient.isSynapse = true;
            }
            else
            {
                MainAPI.Load();
                synX.Enabled = false;
                WaveClient.attachingUtility = "ex";
            }
        }

        private void attach_Click(object sender, EventArgs e)
        {
            if (synX.Checked)
            {
                synXlib.Attach();
            }
            else
            {
                WaveClient.LaunchExternalAttachingUtility();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (WaveClient.module.isEasyReady() == false)
            {
                BLCFRstatus.Text = " - Not Ready";
            }
            else
            {
                BLCFRstatus.Text = " - Ready!";
            }
        }

        private void UpdMotionBlur_Click(object sender, EventArgs e)
        {
            WaveClient.LaunchGlobalVariableInteger("blurness", siticoneSlider1.Value);
        }

        private void siticoneOSToggleSwith1_CheckedChanged(object sender, EventArgs e)
        {
            if (siticoneOSToggleSwith1.Checked == true)
            {
                WaveClient.LaunchGlobalVariableBool("MBlur", true);
            }
            else
            {
                WaveClient.LaunchGlobalVariableBool("MBlur", false);
            }
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            if (synX.Checked)
            {
                if (synXlib.Ready())
                {
                    synXlib.Execute("loadstring(game:HttpGet('https://raw.githubusercontent.com/Storm99999/BLC_old/main/blc3.lua'))()");
                }
                else
                {
                    synXlib.Attach();
                    Thread.Sleep(3000);
                    synXlib.Execute("loadstring(game:HttpGet('https://raw.githubusercontent.com/Storm99999/BLC_old/main/blc3.lua'))()");
                }
            }
            else
            {
                WaveClient.LoadForDevTesting();
            }
        }

        private void siticoneOSToggleSwith2_CheckedChanged(object sender, EventArgs e)
        {
            if (siticoneOSToggleSwith2.Checked == true)
            {
                WaveClient.ExecuteCommand("game.Players.LocalPlayer.PlayerGui['BLCFR_keystrokes'].BLCFR_client.Visible = true");
            }
            else
            {
                WaveClient.ExecuteCommand("game.Players.LocalPlayer.PlayerGui['BLCFR_keystrokes'].BLCFR_client.Visible = false");
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UpdBright_Click(object sender, EventArgs e)
        {
            var Val = double.Parse(siticoneRoundedTextBox1.Text);
            WaveClient.ExecuteCommand($"game.Lighting.ColorCorrection.Brightness = {Val}");
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            var Val = double.Parse(siticoneRoundedTextBox2.Text);
            WaveClient.ExecuteCommand($"game.Lighting.ColorCorrection.Contrast = {Val}");
        }

        private void siticoneOSToggleSwith3_CheckedChanged(object sender, EventArgs e)
        {
            if (siticoneOSToggleSwith2.Checked == true)
            {
                WaveClient.ExecuteCommand("game.Players.LocalPlayer.PlayerGui['FPS'].clientFrame.Visible = true");
            }
            else
            {
                WaveClient.ExecuteCommand("game.Players.LocalPlayer.PlayerGui['FPS'].clientFrame.Visible = false");
            }
        }

        private void updTOD_DoubleClick(object sender, EventArgs e)
        {

        }

        private void updTOD_Click(object sender, EventArgs e)
        {
            var doubleButItsParsed = double.Parse(time.Text);
            WaveClient.ExecuteCommand($"game.Lighting.ClockTime = {doubleButItsParsed}");
        }

        private void updZoom_Click(object sender, EventArgs e)
        {
            var theKey = keytozoom.Text;
            WaveClient.LaunchGlobalVariableString("ZoomKey", theKey.ToLower());
        }

        private void siticoneImageButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("WCFR currently supports 3 External Attaching Utilities:\n-EasyEx (Default)\n-KrnlAttacher\n-Synapse Utilities X", "BLCFR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void siticoneOSToggleSwith4_CheckedChanged(object sender, EventArgs e)
        {
            if (xyzPos.Checked == true)
            {
                WaveClient.ExecuteCommand("game.Players.LocalPlayer.PlayerGui.PosGui.Frame.Visible = true");
            }
            else
            {
                WaveClient.ExecuteCommand("game.Players.LocalPlayer.PlayerGui.PosGui.Frame.Visible = false");
            }
        }

        private void siticoneTileButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void siticoneTileButton2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void UpdCross_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Warning!\n\nTo continue the swapping of cursors, Wave Client has to modify some of your roblox files. Close your Wave Client IMMEDIEATELY if you don't want to proceed, otherwise, click OK.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            // this aint no roblox ingame execution shit, this is actual cursor swappin.
            WaveClient.MoveFile($@"C:\Users\{Environment.UserName}\AppData\Local\Roblox\Versions\{rblxpathVer.Text}\content\textures\Cursors\KeyboardMouse\ArrowCursor.png", Application.StartupPath + "\\data\\badrblxCursorHahaXD.png");
            WaveClient.MoveFile($@"C:\Users\{Environment.UserName}\AppData\Local\Roblox\Versions\{rblxpathVer.Text}\content\textures\Cursors\KeyboardMouse\ArrowFarCursor.png", Application.StartupPath + "\\data\\badcursor2.png");
            WaveClient.CopyFile(cstmCursorPath.Text, Application.StartupPath + "\\data\\custom.png");
            WaveClient.CopyFile(Application.StartupPath + "\\data\\custom.png", $@"C:\Users\{Environment.UserName}\AppData\Local\Roblox\Versions\{rblxpathVer.Text}\content\textures\Cursors\KeyboardMouse\ArrowCursor.png");
            WaveClient.CopyFile(Application.StartupPath + "\\data\\custom.png", $@"C:\Users\{Environment.UserName}\AppData\Local\Roblox\Versions\{rblxpathVer.Text}\content\textures\Cursors\KeyboardMouse\ArrowFarCursor.png");
        }

        private void krnl_CheckedChanged(object sender, EventArgs e)
        {
            if (krnl.Checked)
            {
                WaveClient.attachingUtility = "krnl";
                EX.Checked = false;
            }
        }

        private void EX_CheckedChanged(object sender, EventArgs e)
        {
            if (EX.Checked)
            {
                WaveClient.attachingUtility = "ex";
                krnl.Checked = false;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Cosmetica_Click(object sender, EventArgs e)
        {
            cos1.Visible = true;
            cos1.Show();
        }
    }
}
