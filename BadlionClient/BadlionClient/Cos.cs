﻿using KrnlAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BadlionClient
{
    public partial class Cos : UserControl
    {
        public Cos()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            if (WaveClient.isSynapse)
            {
                if (!BLCFR.synXlib.Ready())
                {
                    MessageBox.Show("Please Attach First!");
                }
                else
                {

                    Thread.Sleep(3000);
                    BLCFR.synXlib.Execute("loadstring(game:HttpGet('https://pastebin.com/raw/qCdCWmQW'))()");
                }
            }
            else
            {
                if (WaveClient.attachingUtility == "krnl")
                {
                    MainAPI.Execute($"loadstring(game:HttpGet('https://pastebin.com/raw/qCdCWmQW'))()");
                }
                else
                {
                    WaveClient.module.ExecuteScript($"loadstring(game:HttpGet('https://pastebin.com/raw/qCdCWmQW'))()");
                }
            }
        }

        private void Cos_Load(object sender, EventArgs e)
        {
            if (new WebClient().DownloadString("https://pastebin.com/raw/epZyxaku").Contains(Environment.UserName))
            {
                wcStatus.Text = "owned";
                equipWC.Enabled = true;
            }

            if (new WebClient().DownloadString("https://pastebin.com/raw/7wYyZz0T").Contains(Environment.UserName))
            {
                statusSyn.Text = "owned";
                synEquip.Enabled = true;
            }

            if (new WebClient().DownloadString("https://pastebin.com/raw/70WMjRCC").Contains(Environment.UserName))
            {
                krnlStatus.Text = "owned";
                equipKrnl.Enabled = true;
            }

            if (new WebClient().DownloadString("https://pastebin.com/Ew3r8gcV").Contains(Environment.UserName))
            {
                swStatus.Text = "owned";
                swEquip.Enabled = true;
            }
        }

        private void synEquip_Click(object sender, EventArgs e)
        {
            if (WaveClient.isSynapse)
            {
                if (!BLCFR.synXlib.Ready())
                {
                    MessageBox.Show("Please Attach First!");
                }
                else
                {
                    Thread.Sleep(3000);
                    BLCFR.synXlib.Execute("loadstring(game:HttpGet('https://pastebin.com/raw/2fRXgjwE'))()");
                }
            }
            else
            {
                if (WaveClient.attachingUtility == "krnl")
                {
                    MainAPI.Execute($"loadstring(game:HttpGet('https://pastebin.com/raw/2fRXgjwE'))()");
                }
                else
                {
                    WaveClient.module.ExecuteScript($"loadstring(game:HttpGet('https://pastebin.com/raw/2fRXgjwE'))()");
                }
            }
        }

        private void swEquip_Click(object sender, EventArgs e)
        {
            if (WaveClient.isSynapse)
            {
                if (!BLCFR.synXlib.Ready())
                {
                    MessageBox.Show("Please Attach First!");
                }
                else
                {
                    Thread.Sleep(3000);
                    BLCFR.synXlib.Execute("loadstring(game:HttpGet('https://pastebin.com/raw/DD935wPX'))()");
                }
            }
            else
            {
                if (WaveClient.attachingUtility == "krnl")
                {
                    MainAPI.Execute($"loadstring(game:HttpGet('https://pastebin.com/raw/DD935wPX'))()");
                }
                else
                {
                    WaveClient.module.ExecuteScript($"loadstring(game:HttpGet('https://pastebin.com/raw/DD935wPX'))()");
                }
            }
        }

        private void siticoneButton1_Click_1(object sender, EventArgs e)
        {
            Hide();
        }

        private void equipKrnl_Click(object sender, EventArgs e)
        {
            if (WaveClient.isSynapse)
            {
                if (!BLCFR.synXlib.Ready())
                {
                    MessageBox.Show("Please Attach First!");
                }
                else
                {

                    Thread.Sleep(3000);
                    BLCFR.synXlib.Execute("loadstring(game:HttpGet('https://pastebin.com/raw/A3VRVaSB'))()");
                }
            }
            else
            {
                if (WaveClient.attachingUtility == "krnl")
                {
                    MainAPI.Execute($"loadstring(game:HttpGet('https://pastebin.com/raw/A3VRVaSB'))()");
                }
                else
                {
                    WaveClient.module.ExecuteScript($"loadstring(game:HttpGet('https://pastebin.com/raw/A3VRVaSB'))()");
                }
            }
        }
    }
}
