using EasyExploits;
using KrnlAPI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BadlionClient
{
    internal class WaveClient
    {
        public static Module module = new Module();
        public static string attachingUtility = "";
        public static bool isSynapse = false;

        public static void AddValue(Siticone.UI.WinForms.SiticoneProgressBar bar, int howMuchToAdd)
        {
            bar.Value += howMuchToAdd;
        }

        public static void LaunchExternalAttachingUtility()
        {
            if (attachingUtility == "ex")
            {
                new WebClient().DownloadFile("https://cdn.discordapp.com/attachments/998553456484810842/998553531860668456/BLCInjector.exe", Application.StartupPath + "\\client\\BLCInjector.exe");
                new WebClient().DownloadFile("https://cdn.discordapp.com/attachments/831620170366582837/998554065443225661/EasyExploits.dll", Application.StartupPath + "\\client\\EasyExploits.dll");
                Thread.Sleep(2000);
                Process.Start(Application.StartupPath + "\\client\\BLCInjector.exe");
            }
            if (attachingUtility == "krnl")
            {
                MainAPI.Inject();
            }
        }

        public static void LoadForDevTesting()
        {
            if (attachingUtility == "krnl")
            {
                MainAPI.Execute("loadstring(game:HttpGet('https://raw.githubusercontent.com/Storm99999/BLC_old/main/blc3.lua'))()");
            }
            if (attachingUtility == "ex")
            {
                module.ExecuteScript("loadstring(game:HttpGet('https://raw.githubusercontent.com/Storm99999/BLC_old/main/blc3.lua'))()");
            }
        }

        public static void ExecuteCommand(string s)
        {
            if (isSynapse) { BLCFR.synXlib.Execute(s); }
            else
            {
                if (attachingUtility == "krnl")
                {
                    MainAPI.Execute(s);
                }
                else
                {
                    module.ExecuteScript(s);
                }
            }
        }

        public async static Task StartUp(Siticone.UI.WinForms.SiticoneProgressBar spb, Label lbl)
        {
            // variable
            var b = lbl; // useless tbh // nvm
            // reset progress.
            // make sure we load that shit, cause its most effective now
            if (!Directory.Exists("client")) { Directory.CreateDirectory("client"); b.Text = "Status: Creating 'client' Directory.."; } else { lbl.Text = "Status: Checking 'client' Directory.."; }
            await Task.Delay(2000);
            if (!Directory.Exists("data")) { Directory.CreateDirectory("data"); b.Text = "Status: Creating 'data' Directory.."; } else { lbl.Text = "Status: Checking 'data' Directory.."; }
            await Task.Delay(2000);
            b.Text = "Status: Finishing Up...";
            // finish up
        }

        // Simple, but effective.
        // Edit: I should fr add this to StormUtilities (if it works that is, haven't tested yet.)
        public static void LaunchGlobalVariableBool(string _Gvar, bool FalseTrue)
        {
            if (isSynapse) { BLCFR.synXlib.Execute($"_G.{_Gvar} = {FalseTrue}"); }
            else
            {
                if (attachingUtility == "krnl")
                {
                    MainAPI.Execute($"_G.{_Gvar} = {FalseTrue}");
                    MainAPI.Execute($"print('Changed {_Gvar} to {FalseTrue}')");
                }
                else
                {
                    module.ExecuteScript($"_G.{_Gvar} = {FalseTrue}");
                    module.ExecuteScript($"print('Changed {_Gvar} to {FalseTrue}')");
                }
            }
        }

        public static void LaunchGlobalVariableString(string _Gvar, string value)
        {
            // horaaayyyyyyyy!!! no if statement??? IS THIS REAL
            if (isSynapse) { BLCFR.synXlib.Execute($"_G.{_Gvar} = {value}"); }
            else
            {
                if (attachingUtility == "krnl")
                {
                    MainAPI.Execute($"_G.{_Gvar} = {value}");
                    MainAPI.Execute($"print('Changed {_Gvar} to {value}')");
                }
                else
                {
                    module.ExecuteScript($"_G.{_Gvar} = {value}");
                    module.ExecuteScript($"print('Changed {_Gvar} to {value}')");
                }

            }
        }
        // eh, same with int, no if statement (saves me tones of tones of time but ok guys)
        public static void LaunchGlobalVariableInteger(string _Gvar, int value)
        {
            // goofy code
            if (isSynapse) { BLCFR.synXlib.Execute($"_G.{_Gvar} = {value}"); }
            else
            {
                if (attachingUtility == "krnl")
                {
                    MainAPI.Execute($"_G.{_Gvar} = {value}");
                    MainAPI.Execute($"print('Changed {_Gvar} to {value}')");
                }
                else
                {
                    module.ExecuteScript($"_G.{_Gvar} = {value}");
                    module.ExecuteScript($"print('Changed {_Gvar} to {value}')");
                }
            }
        }

        public static void CopyFile(string origin, string New)
        {
            File.Copy(origin, New, true);
        }

        public static void MoveFile(string origin, string New)
        {
            File.Move(origin,New);
        }
    }
}
