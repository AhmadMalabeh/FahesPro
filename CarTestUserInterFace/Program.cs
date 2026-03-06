using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using CarTestLogicalLayer;
namespace CarTestUserInterFace
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        public static string GetCpuId()
        {
            using (var searcher = new ManagementObjectSearcher(
                "SELECT ProcessorId FROM Win32_Processor"))
            {
                foreach (ManagementObject obj in searcher.Get())
                    return obj["ProcessorId"]?.ToString()?.Trim() ?? "";
            }
            return "";
        }

        public static string GetMotherboardSerial()
        {
            using (var searcher = new ManagementObjectSearcher(
                "SELECT SerialNumber FROM Win32_BaseBoard"))
            {
                foreach (ManagementObject obj in searcher.Get())
                    return obj["SerialNumber"]?.ToString()?.Trim() ?? "";
            }
            return "";
        }
        [STAThread]
        static void Main()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjGyl/VkR+XU9Ff1RDX3xKf0x/TGpQb19xflBPallYVBYiSV9jS3hTdEVmWH5dcHVdRWlcWU91XQ==");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            clsCoumputersInfo coumputersInfo = new clsCoumputersInfo();
            string cpuId = GetCpuId();
            string motherboardId = GetMotherboardSerial();

            if (!clsCoumputersInfo.IsValidComputer(cpuId, motherboardId))
            {
                MessageBox.Show("This computer is not authorized to run this application.", "Unauthorized Computer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // نخرج من البرنامج إذا لم يكن الكمبيوتر مصرحًا له
            }


            frmLogInScreen loginForm = new frmLogInScreen();

            // نستخدم ShowDialog ليبقى البرنامج ينتظر نتيجة هذه الشاشة
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // 2. إذا نجح الدخول، نمرر بيانات المستخدم للشاشة الرئيسية ونبدأ البرنامج بها
                Application.Run(new MainScreen(loginForm.LoggedInUser));
            }
            else
            {
                // إذا أغلق المستخدم شاشة الدخول دون دخول ناجح، ينتهي البرنامج هنا
                Application.Exit();
            }
        }
    }
}
