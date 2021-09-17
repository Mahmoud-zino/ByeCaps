using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ByeCaps
{
    public partial class MainForm : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool ExitWindowsEx(uint uFlags, uint dwReason);

        public static bool WindowsLogOff()
        {
            //force flag
            return ExitWindowsEx(0 | 0x00000004, 0);
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void BtnDisable_Click(object sender, System.EventArgs e)
        {
            Process regeditProcess = Process.Start("regedit.exe", $"{Path.Combine(Directory.GetCurrentDirectory(), "DisableCaps.reg")}");
            regeditProcess.WaitForExit();

            WindowsLogOff();
        }

        private void BtnEnable_Click(object sender, System.EventArgs e)
        {
            Process regeditProcess = Process.Start("regedit.exe", $"{Path.Combine(Directory.GetCurrentDirectory(), "EnableCaps.reg")}");
            regeditProcess.WaitForExit();

            WindowsLogOff();
        }
    }
}
